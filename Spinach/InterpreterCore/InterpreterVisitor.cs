/////////////////////////////////////////////////////////////////////////////////
// InterpreterVisitor.cs: Implements a vistor that interprets the syntax tree.
// 
// version: 1.6
// Description: part of the interpreter example for the visitor design
//  pattern.
// Language:    C++/CLI, Visual Studio 2008 .Net Framework 3.5             
// Platform:    Dell Inspiron 1525, Windows Vista Business, SP 1       
// Application: SPINACH Project, CSE 784, Spring 2009                              
// Authors:     Rajika Tandon (ratandon@syr.edu)
//              Sushma Thimmappa (skyasara@syr.edu)
//              Rucha Bapat (rmbapat@syr.edu)            
//              Srinivasan Sundararajan (ssunda04@syr.edu)
// Source:      Phil Pratt-Szeliga (pcpratts@syr.edu)
////////////////////////////////////////////////////////////////////////////////
/*
 * Module Operations
 * ================= 
 * This file provides functionalities which interprets the tree, according to the 
 * elements present in it, i.e. it performs compuatation of an expression involving
 * addition, multiplication and subtraction of int/doubles, as well as, addition, 
 * subtraction and multiplication of matrices. 
 * 
 * Similarly,it invokes variable, integer, 
 * double, string, assignment, matrix assignment, print, functions, if-else, structures, 
 * for-loop, parallel-for loop and for loop functionalities as and when these are 
 * encountered. 
 * 
 * Moreover, the plot object (received from InterpreterExec), commands and 
 * data, are set using setPlotObj() and VisitPlotFunctionElement() functions to be communicated 
 * to the Plotting team. 
 * The functionalities associated with these various operations, will 
 * further go into the tree to evaluate them.
 * 
 * Public Interface
 * ================
 * InterpreterVisitor interp_visitor = new InterpreterVisitor();  
 *                       // will create an instance of this class and allocate memory
 * 
 */
/*
 * Build Process
 * =============
 * Required Files:
 *   Front End Dlls
 * 
 * Maintenance History
 * ===================
 * ver 1.5 : 23 Nov 09
 *   - function handling added
 * ver 1.4 : 22 Nov 09
 *   - for loop handling added
 * ver 1.3 : 22 Nov 09
 *   - if-else modified to incorporate parallel case
 * ver 1.2 : 22 Nov 09
 *   - parallel-for code added
 * ver 1.1 : 12 Nov 09
 *   - completed if-else functionality based on the new grammar 
 * ver 1.0 : 10 Nov 09
 *   - first release
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;


namespace Spinach
{
    public class InterpreterVisitor : Visitor
    {
        PlotReceiver p;
        SwarmMemory smem;
        exec FE;
        int inParallelFor = 0;
        List<String> parallelVars;
        StringBuilder parallelString = new StringBuilder();
        StringBuilder parallelData = new StringBuilder();
        StringBuilder parallelResult = new StringBuilder();
        StringBuilder finalResult = new StringBuilder();
        StringWriter matStr;
        XmlTextWriter matXml;
        int parallelSwarm = 0;
        
        //
        string pdata, pbody, prange;
        int pstart, pstop;
        //
        public delegate void errorcoremsg(int code, string errormsg);
        public event errorcoremsg errorcore_;

        public delegate void executeParallel(string body, string data, int index, int index2);
        public event executeParallel parallelcore_;

        public delegate void getResults(List<string> results);
        public event getResults parallelresult_;

        public delegate void resultcore(string coremsg);
        public event resultcore rescore_;

        public void sendres(int code, string errormsg)
        {
            if (errorcore_ != null)
                errorcore_(code, errormsg);

        }

        public void result(string coremsg)
        {
            if (rescore_ != null)
                rescore_(coremsg);
        }

        public void execParallel(string body, string data, int start, int stop)
        {
            if (parallelcore_ != null)
            {
                parallelcore_(body, data, start, stop);
                
            }
            
        }

        public void getParallelResult(List<string> results)
        {
            if (parallelresult_ != null)
                parallelresult_(results);
        }
        public void setSwarmObject(SwarmMemory sm)
        {
            smem = sm;
           smem.parallelcore_+=new SwarmMemory.executeParallel(ParallelCore);
           smem.parallelresult_ += new SwarmMemory.getResults(ParallelRes);
           parallelSwarm = 1;
        }

        
        public void ParallelCore(string data, string body, int start, int stop,string range)
        {
            try
            {
                Thread.Sleep(5);
                pdata = data;
                pbody = body;
                pstart = start;
                pstop = stop;
                prange = range;
                Thread t = new Thread(new ThreadStart(convertParallel));
                t.Start();
                parallelSwarm = 1;
            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        public void ParallelRes(List<string> ParRes)
        {
            ProcessResults(ParRes);
        }
        public void setPlotObj(PlotReceiver pr)
        {
            p = pr;
            if (p != null)
                p.checklist();
        }

        public void setFE(exec fe)
        {
            FE = fe;
        }
        //To be called by Swarm
        public void setSwarm()
        {
            parallelSwarm = 1;
        }
        Hashtable mVariableMap;
        Stack<Hashtable> scope;
        Stack<Hashtable> funcCall;
        Stack<FunctionElement> func_def;
        List<Object> return_var;
        Stack<int> mStack;
        Stack<Object> mat_stack;
        List<int> mList;
        List<int> rcList;
        int local;
        int functionFlag;
        string rangeVar;

        // PrintVisitor print_visitor=new PrintVisitor(this);
        //List<Element> elements;

        public void clearMap()
        {
            mVariableMap.Clear();
            func_def.Clear();
            scope.Clear();
            scope.Push(mVariableMap);
            parallelData.Length = 0;
            parallelString.Length = 0;
            parallelResult.Length = 0;
        }
        public Hashtable getMap()
        {
            return mVariableMap;
        }
        public enum datatypes
        {
            IntElement = 1,
            DoubleElement = 2,
            Matrix = 3,
            Struct = 4,
            MatrixElement = 5,
            Variable = 6,
            Strings = 7,
            Subtraction = 8,
            VectorElement = 15,
            Vector = 16,
            Assignment = 9,
            func = 10,
            delete = 11,
            ret = 12,
            matref = 13,
            forstmt = 20,
            ifelse = 21,
            paraFor = 22

        }
        //Error codes: 110-120
        public InterpreterVisitor()
        {
            mVariableMap = new Hashtable();
            return_var = new List<Object>();
            scope = new Stack<Hashtable>();
            scope.Push(mVariableMap);
            funcCall = new Stack<Hashtable>();
            mStack = new Stack<int>();
            matStr = new StringWriter();
            matXml = new XmlTextWriter(matStr);
            parallelVars = new List<string>();
            func_def = new Stack<FunctionElement>();
            mList = new List<int>();
            rcList = new List<int>();
            mat_stack = new Stack<Object>();
            local = 0;
            functionFlag = 0;
            rangeVar = "";
        }

        public Object getTopOfStack_Matrix()
        {
            Object result = mat_stack.Peek();
            mat_stack.Pop();
            return result;
        }

        //public bool map_contains_matrix(string key)
        //{
        /* int flag = 0;
         for (int i = 0; i < scope.Peek().Count; i++)
         {
             if (scope.Peek().ContainsKey(key))
                 flag = 1;
         }
         if (flag == 1)
             return true;
         else
             return false;*/
        public bool map_contains_matrix(string key)
        {
            if (local == 0)
            {
                if (mVariableMap.Count != 0)
                {
                    for (int i = 0; i < mVariableMap.Count; i++)
                    {
                        if (mVariableMap.ContainsKey(key))
                            return true;
                    }
                }
                return false;
            }
            else if (functionFlag != 0)
            {
                int l = functionFlag;
                int k = scope.Count;
                foreach (Hashtable item in scope)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item.ContainsKey(key))
                            return true;
                    }
                    k--;
                    if (k == l)
                        break;
                }
                return false;
            }
            else
            {
                foreach (Hashtable item in scope)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item.ContainsKey(key))
                            return true;
                    }
                }
                return false;
            }
        }

        private void varData(string Var)
        {
            try
            {
                if (map_contains_matrix(Var) && !(parallelVars.Contains(Var))) //get the local hash table which contains key
                {
                    matXml.WriteStartElement("Variable");
                    matXml.WriteStartElement("name");
                    matXml.WriteValue(Var);
                    matXml.WriteEndElement();
                    if (local == 0)
                    {
                        if (mVariableMap[Var] is IntegerElement)
                        {
                            matXml.WriteStartElement("Integer");
                            matXml.WriteValue(((IntegerElement)mVariableMap[Var]).getText());
                            matXml.WriteEndElement();
                        }
                        else if (mVariableMap[Var] is DoubleElement)
                        {
                            matXml.WriteStartElement("Double");
                            matXml.WriteValue(((DoubleElement)mVariableMap[Var]).getText());
                            matXml.WriteEndElement();
                        }
                        else if (mVariableMap[Var] is StringElement)
                        {
                            matXml.WriteStartElement("String");
                            matXml.WriteValue(((StringElement)mVariableMap[Var]).getText());
                            matXml.WriteEndElement();
                        }
                    }
                    else
                    {
                        Hashtable hash = getHashTable(Var);
                        if (hash[Var] is IntegerElement)
                        {
                            matXml.WriteStartElement("Integer");
                            matXml.WriteValue(((IntegerElement)hash[Var]).getText());
                            matXml.WriteEndElement();
                        }
                        else if (hash[Var] is DoubleElement)
                        {
                            matXml.WriteStartElement("Double");
                            matXml.WriteValue(((DoubleElement)hash[Var]).getText());
                            matXml.WriteEndElement();
                        }
                        else if (hash[Var] is StringElement)
                        {
                            matXml.WriteStartElement("String");
                            matXml.WriteValue(((StringElement)hash[Var]).getText());
                            matXml.WriteEndElement();
                        }
                    }
                    matXml.WriteEndElement();
                    //matXml.Flush();
                    parallelData.Append(matStr.ToString());
                    parallelData.Append("\n");
                    if (!parallelVars.Contains(Var))
                        parallelVars.Add(Var);
                }
            }
            catch (Exception e) { sendres(112, "Parallel for : Error in Variable data\n"); e.GetType(); }
        }


        private Hashtable getHashTable(string key)
        {
            if (local == 0)
            {
                if (mVariableMap.Count != 0)
                {
                    for (int i = 0; i < mVariableMap.Count; i++)
                    {
                        if (mVariableMap.ContainsKey(key))
                            return mVariableMap;
                    }
                }
                return null;
            }
            else if (functionFlag != 0)
            {
                int l = functionFlag;
                int k = scope.Count;
                foreach (Hashtable item in scope)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item.ContainsKey(key))
                            return item;
                    }
                    k--;
                    if (k == l)
                        break;
                }
                return null;
            }
            else
            {
                foreach (Hashtable item in scope)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item.ContainsKey(key))
                            return item;
                    }
                }
                return null;
            }

        }

        private void writeIntResult(string matName, int row, int col, int val)
        {
            parallelResult.Append("<Matrix>");
            parallelResult.Append("<Name>");
            parallelResult.Append(matName);
            parallelResult.Append("</Name>");
            parallelResult.Append("<Row>");
            parallelResult.Append(row.ToString());
            parallelResult.Append("</Row>");
            parallelResult.Append("<Column>");
            parallelResult.Append(col.ToString());
            parallelResult.Append("</Column>");
            parallelResult.Append("<Value>");
            parallelResult.Append(val.ToString());
            parallelResult.Append("</Value>");
            parallelResult.Append("</Matrix>");
        }

        private void writeDoubleResult(string matName, int row, int col, double val)
        {
            parallelResult.Append("<Matrix>");
            parallelResult.Append("<Name>");
            parallelResult.Append(matName);
            parallelResult.Append("</Name>");
            parallelResult.Append("<Row>");
            parallelResult.Append(row.ToString());
            parallelResult.Append("</Row>");
            parallelResult.Append("<Column>");
            parallelResult.Append(col.ToString());
            parallelResult.Append("</Column>");
            parallelResult.Append("<Value>");
            parallelResult.Append(val.ToString());
            parallelResult.Append("</Value>");
            parallelResult.Append("</Matrix>");
        }

        //To be used by Swarm 
        public void convertParallel()
        {
            try
            {
                
                CreateData(pdata);
                StringBuilder stmt = new StringBuilder();
                stmt.Append("for(" + prange + "->");//o reserved as control variable for parallel-for
                stmt.Append(pstart.ToString() + " to " + pstop.ToString() + ")");
                stmt.Append("\n{");
                stmt.Append(pbody);
                stmt.Append("\n}");
                //Fe.VisitLine(stmt.ToString());
                FE.Visitline(stmt.ToString());
                scope.Pop();
                local--;

                smem.outgoingResult(pstart.ToString(), parallelResult.ToString());
                parallelResult.Length = 0;
            }
            catch (Exception e)
            {
                sendres(112, e.Message);
            }
            
        }

        private void CreateData(string data)
        {
            try
            {
                
                local++;
                Hashtable localTable = new Hashtable();
                scope.Push(localTable);
                int curElement = 0;
                StringReader readStr = new StringReader(data);
                XmlTextReader xf = new XmlTextReader(readStr);
                MatrixVariableDeclaration mat = null;
                VectorVariableDeclaration vec = null;
                string matElem = "";
                int currRow = 0;

                string type = "";
                int totalRows = 0;
                int totalCols = 0;
                int currCol = -1;
                int[,] elems = new int[10, 10];
                double[,] delems = new double[10, 10];
                List<int> vecElems = new List<int>();
                List<double> vecDelems = new List<double>();

                while (xf.Read())
                {
                    switch (xf.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                if (xf.Name == "Matrix")
                                {
                                    curElement = 1;
                                    mat = new MatrixVariableDeclaration();
                                    currRow = 0; currCol = -1;
                                }
                                if (xf.Name == "Vector")
                                {
                                    curElement = 2;
                                    vec = new VectorVariableDeclaration();
                                }
                                if (curElement == 2)
                                {
                                    if (xf.Name == "name")
                                        matElem = "name";

                                }
                                if (curElement == 1)
                                {
                                    if (xf.Name == "name")
                                        matElem = "name";
                                    if (xf.Name == "row")
                                        matElem = "row";
                                    if (xf.Name == "col")
                                        matElem = "column";
                                    if (xf.Name == "type")
                                        matElem = "type";
                                    if (xf.Name == "Elements")
                                    {
                                        if (mat.getType() == "int")
                                            elems = new int[totalRows, totalCols];
                                        else if (mat.getType() == "double")
                                            delems = new double[totalRows, totalCols];
                                    }
                                    if (xf.Name == "Element")
                                    {
                                        matElem = "elem";
                                        if (currCol == totalCols - 1 && currRow < totalRows - 1)
                                        {
                                            currRow += 1;
                                            currCol = 0;
                                        }
                                        else currCol += 1;
                                    }
                                }
                                if (curElement == 2)
                                {
                                    if (xf.Name == "name")
                                        matElem = "name";
                                    if (xf.Name == "count")
                                        matElem = "count";
                                    if (xf.Name == "type")
                                        matElem = "type";
                                    if (xf.Name == "Elements")
                                    {
                                        if (vec.getType() == "int")
                                            vecElems = new List<int>();
                                        if (vec.getType() == "double")
                                            vecDelems = new List<double>();
                                    }
                                    if (xf.Name == "Element")
                                    {
                                        matElem = "elem";
                                    }
                                }

                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                if (curElement == 1)
                                {
                                    if (matElem == "row")
                                    {
                                        IntegerElement row = new IntegerElement();
                                        totalRows = int.Parse(xf.Value.ToString());
                                        row.setText(xf.Value);
                                        mat.setRow(row);
                                    }
                                    if (matElem == "column")
                                    {
                                        IntegerElement col = new IntegerElement();
                                        totalCols = int.Parse(xf.Value.ToString());
                                        col.setText(xf.Value);
                                        mat.setColumn(col);
                                    }
                                    if (matElem == "name")
                                    {
                                        VariableElement val = new VariableElement();
                                        val.setText(xf.Value);
                                        mat.setVar(val);
                                    }
                                    if (matElem == "type")
                                    {
                                        type = xf.Value;
                                        mat.setType(type);
                                    }
                                    if (matElem == "elem")
                                    {
                                        if (type == "int")
                                            elems[currRow, currCol] = int.Parse(xf.Value.ToString());
                                        else if (type == "double")
                                            delems[currRow, currCol] = double.Parse(xf.Value.ToString());
                                    }
                                }
                                if (curElement == 2)
                                {
                                    if (matElem == "count")
                                    {
                                        IntegerElement count = new IntegerElement();

                                        count.setText(xf.Value);
                                        vec.setRange(count);
                                    }
                                    if (matElem == "name")
                                    {
                                        VariableElement val = new VariableElement();
                                        val.setText(xf.Value);
                                        vec.setText(val);
                                    }
                                    if (matElem == "type")
                                    {
                                        type = xf.Value;
                                        vec.setType(type);
                                    }
                                    if (matElem == "elem")
                                    {
                                        if (type == "int")
                                            vecElems.Add(int.Parse(xf.Value.ToString()));
                                        else if (type == "double")
                                            vecDelems.Add(double.Parse(xf.Value.ToString()));
                                    }
                                }
                                break;
                            }
                        case XmlNodeType.EndElement:
                            {
                                if (xf.Name == "Elements" && curElement == 1)
                                {
                                    if (mat.getType() == "int")
                                        mat.setIntMatrix(elems);
                                    else if (mat.getType() == "double")
                                        mat.setDoubleMatrix(delems);
                                    if (!scope.Peek().ContainsKey((mat.getVar().getText())))
                                        scope.Peek()[mat.getVar().getText()]= mat;
                                }
                                if (xf.Name == "Elements" && curElement == 2)
                                {
                                    bool a;
                                    if (vec.getType() == "int")
                                        a = vec.setIntVector(vecElems);
                                    else if (vec.getType() == "double")
                                        a = vec.setDoubleVector(vecDelems);
                                    if (!scope.Peek().ContainsKey((vec.getText().getText())))
                                        scope.Peek().Add(vec.getText().getText(), vec);
                                }
                                Console.Write("End:" + xf.Name);
                                break;
                            }
                        default:
                            {
                                Console.Write("\n");
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                sendres(112, e.Message);
            }
           // scope.Pop();
           // local--;
        }


        public override void VisitVariableElement(VariableElement element)
        {
            if (inParallelFor == 1)
            {
                if (parallelVars.Contains(element.getText()))
                {
                }
                else
                {
                    varData(element.getText());
                }
                parallelString.Append(element.getText());
            }
            else
            {
                if (map_contains_matrix(element.getText()))
                {
                    if (local == 0)
                    {
                        mat_stack.Push(mVariableMap[element.getText()]);
                    }
                    else
                    {
                        Hashtable hash = getHashTable(element.getText());
                        mat_stack.Push(hash[element.getText()]);
                    }
                }
                else
                {
                    sendres(112, "Variable not declared\n");
                }
            }
        }

        public override void VisitStructDeclaration(StructDeclaration element)
        {
            //throw new NotImplementedException();
            //struct s{int a;};
            if (element != null)
            {
                if (local == 0)
                {
                    if (mVariableMap.ContainsKey(element.getName().getText()))
                    {
                        sendres(112, "Variable declared\n");
                        Console.Write("Variable declared\n");
                    }
                    else
                        mVariableMap.Add(element.getName().getText(), element);
                }
                else
                {
                    if (scope.Peek().ContainsKey(element.getName().getText()))
                    {
                        sendres(112, "Variable declared\n");
                        Console.Write("Variable declared\n");
                    }
                    else
                        scope.Peek().Add(element.getName().getText(), element);
                }

            }
            else
                Console.Write("Null Structure element\n");
        }
        public override void VisitStructObject(StructObjectDeclaration element)
        {
            //throw new NotImplementedException();
            //s s1;
            if (element != null)
            {
                if (mVariableMap.ContainsKey(element.getStructName().getText()))
                {
                    Object name = mVariableMap[element.getStructName().getText()];
                    if (GetTypeOfElement((Element)(name)) == 4)
                    {
                        StructDeclaration temp = (StructDeclaration)name;
                        if (temp != null)
                        {
                            StructDeclaration obj = new StructDeclaration();
                            List<ScalarVariableDeclaration> l1 = new List<ScalarVariableDeclaration>();
                            l1 = temp.getVarType();
                            for (int i = 0; i < l1.Count; i++)
                                obj.setVarType(l1[i]);
                            obj.setName(element.getObjName());
                            mVariableMap.Add(element.getObjName().getText(), obj);
                        }
                        else
                        {
                            Console.Write("Variable name used\n");
                            sendres(112, "Variable name used\n");
                        }
                    }
                    else

                        Console.Write("Object not of type struct\n");
                }
                else
                    sendres(112, "Structure not found\n");
            }
            else
                Console.Write("Null struct object\n");
        }
        public override void VisitStructAssignment(StructAssignDeclaration element)
        {
            //throw new NotImplementedException();
            //s1.a=10;
            if (element != null)
            {
                //
            }
        }
        public override void VisitDotProductElement(DotProductElement element)
        {
            if (element.getLhs() != null && element.getRhs() != null)
            {
                VisitElement(element.getLhs());
                VisitElement(element.getRhs());
                Object obj_rhs = getTopOfStack_Matrix();
                Object obj_lhs = getTopOfStack_Matrix();
                // Object dot_prod = new Object();
                if (obj_rhs is VectorVariableDeclaration && obj_lhs is VectorVariableDeclaration)
                {
                    VectorVariableDeclaration rhs = (VectorVariableDeclaration)(obj_rhs);
                    VectorVariableDeclaration lhs = (VectorVariableDeclaration)(obj_lhs);
                    VectorVariableDeclaration final = new VectorVariableDeclaration();
                    if (rhs.getType() == lhs.getType())
                    {
                        if (rhs.getType() == "int")
                        {
                            List<int> rhs_elem = rhs.getintValue();
                            List<int> lhs_elem = lhs.getintValue();
                            List<int> result = new List<int>();

                            //  result.Count = rhs_elem.Count;
                            if (rhs_elem.Count == lhs_elem.Count)
                            {
                                final.setType(rhs.getType());
                                final.setRange(rhs.getRange());
                                for (int i = 0; i < rhs_elem.Count; i++)
                                {
                                    result.Add(lhs_elem[i] * rhs_elem[i]);
                                }
                                bool ans = final.setIntVector(result);
                            }
                            else
                                sendres(112, "Number of elements do not match.. ");
                        }
                        else if (rhs.getType() == "double")
                        {
                            List<double> rhs_elem = rhs.getdoubleValue();
                            List<double> lhs_elem = lhs.getdoubleValue();
                            List<double> result = new List<double>();
                            if (rhs_elem.Count == lhs_elem.Count)
                            {
                                final.setType(rhs.getType());
                                final.setRange(rhs.getRange());
                                for (int i = 0; i < rhs_elem.Count; i++)
                                {
                                    result.Add(lhs_elem[i] * rhs_elem[i]);
                                }
                                bool ans = final.setDoubleVector(result);
                            }
                            else
                                sendres(112, "Number of elements do not match.. ");
                        }
                        Object dot_prod = (Object)(final);
                        mat_stack.Push(dot_prod);
                    }
                    else
                        sendres(112, "Types mismatch.. ");
                }
                else
                    sendres(112, "Variable is not vector element.. ");
            }
        }
        public override void VisitMatrixTransposeElement(MatrixTranspose element)
        {
            if (element.getvariable() != null)
            {
                VisitElement(element.getvariable());
                Object obj_rhs = getTopOfStack_Matrix();
                //Object result = new Object();
                MatrixVariableDeclaration mat = (MatrixVariableDeclaration)(obj_rhs);
                MatrixVariableDeclaration transpose = new MatrixVariableDeclaration();
                transpose.setType(mat.getType());
                int rhs_type = GetTypeOfElement((Element)obj_rhs);
                if (rhs_type == 3)
                {
                    if (mat.getType() == "int")
                    {
                        int[,] mat_elem = mat.getintValue();

                        int row = int.Parse(((IntegerElement)(mat.getRow())).getText());
                        int col = int.Parse(((IntegerElement)(mat.getColumn())).getText());
                        int[,] trans_elem = new int[col, row];
                        transpose.setRow(mat.getColumn());
                        transpose.setColumn(mat.getRow());
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                                trans_elem[j, i] = mat_elem[i, j];
                        }
                        Console.Write("\n");
                        transpose.setIntMatrix(trans_elem);
                        int[,] trans = transpose.getintValue();
                        int trans_row = int.Parse(((IntegerElement)(transpose.getRow())).getText());
                        int trans_col = int.Parse(((IntegerElement)(transpose.getColumn())).getText());
                        Console.Write("Transpose of the given matrix is : \n\n");
                        //result("Transpose of the matrix\n");

                        for (int i = 0; i < trans_row; i++)
                        {
                            for (int j = 0; j < trans_col; j++)
                            {
                                Console.Write("\t" + trans[i, j]);
                                //      result("\t" + trans[i, j].ToString());
                            }
                            Console.Write("\n");
                            //result("\n");

                        }
                    }
                    else if (mat.getType() == "double")
                    {
                        double[,] mat_elem = mat.getdoubleValue();

                        int row = int.Parse(((IntegerElement)(mat.getRow())).getText());
                        int col = int.Parse(((IntegerElement)(mat.getColumn())).getText());
                        double[,] trans_elem = new double[col, row];
                        transpose.setRow(mat.getColumn());
                        transpose.setColumn(mat.getRow());
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                                trans_elem[j, i] = mat_elem[i, j];
                        }
                        Console.Write("\n");
                        //result("\n");

                        transpose.setDoubleMatrix(trans_elem);
                        double[,] trans = transpose.getdoubleValue();
                        int trans_row = int.Parse(((IntegerElement)(transpose.getRow())).getText());
                        int trans_col = int.Parse(((IntegerElement)(transpose.getColumn())).getText());
                        //result( "Transpose of the given matrix\n");
                        Console.Write("Transpose of the given matrix is : \n\n");
                        for (int i = 0; i < trans_row; i++)
                        {
                            for (int j = 0; j < trans_col; j++)
                            {
                                Console.Write("\t" + trans[i, j]);
                                //      result( "\t" + trans[i, j].ToString());

                            }
                            Console.Write("\n");
                            //result("\n");
                        }
                    }
                    Object result = (Object)(transpose);
                    mat_stack.Push(result);

                }
            }
            else
            {
                Console.Write("Matrix needs to be decalred first.. try again.. ");
                sendres(112, "Matrix needs to be declared first.. try again..\n");
            }
        }


        public override void VisitBracketElement(BracketElement element)
        {
            Element elem = element.getbracketexpression();
            VisitElement(elem);
            //throw new NotImplementedException();
        }
        /*public override void VisitDeclarationElement(DeclarationElement element)
        {
            //throw new NotImplementedException();
        }*/

        //Delete  from symbol table
        public override void VisitDeleteElement(DeleteVariable element)
        {
            if (map_contains_matrix(element.getVar().getText()))
            {
                if (local == 0)
                {
                    mVariableMap.Remove(element.getVar().getText());
                }
                else
                {
                    Hashtable hash = getHashTable(element.getVar().getText());
                    hash.Remove(element.getVar().getText());
                }
            }
            else
            {
                sendres(112, "Variable not declared, cannot be deleted\n");
            }
        }

        public override void VisitCommentElement(CommentElement element)
        {
            //throw new NotImplementedException();
        }
        public override void VisitMatrixReference(MatrixReference element)
        {
            //throw new NotImplementedException();
        }

        private void matrixData(string matrixVar)
        {
            try
            {
                if (map_contains_matrix(matrixVar) && !(parallelVars.Contains(matrixVar)))
                {
                    MatrixVariableDeclaration mat = null;
                    if (local == 0)
                        mat = (MatrixVariableDeclaration)mVariableMap[matrixVar];
                    else
                    {
                        Hashtable hash = getHashTable(matrixVar);
                        mat = (MatrixVariableDeclaration)hash[matrixVar];
                    }

                    matXml.WriteStartElement("Matrix");
                    matXml.WriteStartElement("name");
                    matXml.WriteValue(matrixVar);
                    matXml.WriteEndElement();
                    matXml.WriteStartElement("row");
                    matXml.WriteValue(mat.getRow().getText());
                    matXml.WriteEndElement();
                    matXml.WriteStartElement("col");
                    matXml.WriteValue(mat.getColumn().getText());
                    matXml.WriteEndElement();
                    int row = int.Parse(((IntegerElement)(mat.getRow())).getText());
                    int col = int.Parse(((IntegerElement)(mat.getColumn())).getText());
                    matXml.WriteStartElement("type");
                    matXml.WriteValue(mat.getType());
                    matXml.WriteEndElement();
                    if (mat.getType() == "int")
                    {
                        int[,] intElems = mat.getintValue();
                        matXml.WriteStartElement("Elements");
                        for (int i = 0; i < (row); i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                matXml.WriteStartElement("Element");
                                matXml.WriteValue(mat.getintValueat(i, j));
                                matXml.WriteEndElement();
                            }
                        }
                    }
                    else if (mat.getType() == "double")
                    {
                        double[,] doubleElems = mat.getdoubleValue();
                        matXml.WriteStartElement("Elements");
                        for (int i = 0; i < (row); i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                matXml.WriteStartElement("Element");
                                matXml.WriteValue(mat.getdoubleValueat(i, j));
                                matXml.WriteEndElement();
                            }
                        }
                    }
                    matXml.WriteEndElement();
                    matXml.WriteEndElement();
                    //matXml.Flush();
                    parallelData.Append(matStr.ToString());
                    parallelData.Append("\n");
                    parallelVars.Add(matrixVar);

                }
            }
            catch (Exception e) { e.GetType(); }
        }

        public override void VisitMatrixSingleElement(MatrixElement element)
        {
            try
            {
                MatrixElement temp = element;
                if (inParallelFor == 1)
                {
                    if (parallelVars.Contains(element.getVar().getText()))
                    {
                    }
                    else
                    {
                        matrixData(element.getVar().getText());
                    }
                    parallelString.Append(temp.getVar().getText());
                    parallelString.Append("[");
                    if (temp.getRow() is VariableElement)
                        parallelString.Append(((VariableElement)temp.getRow()).getText());
                    else if (temp.getRow() is IntegerElement)
                        parallelString.Append(((IntegerElement)temp.getRow()).getText());
                    parallelString.Append("]");
                    parallelString.Append("[");
                    if (temp.getColumn() is VariableElement)
                        parallelString.Append(((VariableElement)temp.getColumn()).getText());
                    else if (temp.getColumn() is IntegerElement)
                        parallelString.Append(((IntegerElement)temp.getColumn()).getText());
                    parallelString.Append("]");
                }
                else
                {
                    PerformMatrixSingleElementOperation(element);
                }
            }
            catch (Exception e) 
            {
                sendres(112,e.Message);
                sendres(112, "Error in matrix element\n"); e.GetType(); }

        }

        private int getMatrixRow(MatrixElement temp)
        {
            try
            {
                if (temp.getRow() is IntegerElement)
                {
                    string r = ((IntegerElement)temp.getRow()).getText();
                    return int.Parse(r);
                }
                else
                {
                    string r="";

                    if (local == 0)
                    {
                        r = ((IntegerElement)(mVariableMap[((VariableElement)temp.getRow()).getText()])).getText();
                    }
                    else
                    {
                        Hashtable hash = getHashTable(((VariableElement)temp.getRow()).getText());
                        r = ((IntegerElement)(hash[((VariableElement)temp.getRow()).getText()])).getText();
                    }
                    return int.Parse(r);
                }
            }
            catch (Exception e) { sendres(112, "Invalid row\n"); e.GetType(); return 0; }
        }

        private void ParallelMatrixElement(AssignmentOperationElement element)
        {
            MatrixElement temp = (MatrixElement)(element.getLhs());
            parallelString.Append(temp.getVar().getText());
            parallelString.Append("[");
            if (temp.getRow() is VariableElement)
                parallelString.Append(((VariableElement)temp.getRow()).getText());
            else if (temp.getRow() is IntegerElement)
                parallelString.Append(((IntegerElement)temp.getRow()).getText());
            parallelString.Append("]");
            parallelString.Append("[");
            if (temp.getColumn() is VariableElement)
                parallelString.Append(((VariableElement)temp.getColumn()).getText());
            else if (temp.getColumn() is IntegerElement)
                parallelString.Append(((IntegerElement)temp.getColumn()).getText());
            parallelString.Append("]");
            parallelString.Append("=");
            VisitElement(element.getRhs());

        }

        private int getMatrixCol(MatrixElement temp)
        {
            try
            {
                if (temp.getColumn() is IntegerElement)
                {
                    string s = ((IntegerElement)temp.getColumn()).getText();
                    return int.Parse(s);
                }
                else
                {
                    string r = "";

                    if (local == 0)
                    {
                        r = ((IntegerElement)(mVariableMap[((VariableElement)temp.getColumn()).getText()])).getText();
                    }
                    else
                    {
                        Hashtable hash = getHashTable(((VariableElement)temp.getColumn()).getText());
                        r = ((IntegerElement)(hash[((VariableElement)temp.getColumn()).getText()])).getText();
                    }
                    return int.Parse(r);
                }
            }
            catch (Exception e) { sendres(112, "Invalid column\n"); e.GetType(); return 0; }
        }



        private void PerformMatrixSingleElementOperation(MatrixElement temp)
        {
            if (map_contains_matrix(temp.getVar().getText()))
            {
                MatrixVariableDeclaration matTemp = null;
                if (temp != null)
                {
                    if (local == 0)
                        matTemp = (MatrixVariableDeclaration)mVariableMap[temp.getVar().getText()];
                    else
                    {
                        Hashtable hash = getHashTable(temp.getVar().getText());
                        matTemp = (MatrixVariableDeclaration)hash[temp.getVar().getText()];
                    }
                    int row = getMatrixRow(temp);
                    int col = getMatrixCol(temp);

                    if (matTemp != null)
                    {
                        if (row < int.Parse(matTemp.getRow().getText()) && col < int.Parse(matTemp.getColumn().getText()))
                        {
                            if (matTemp.getType() == "int")
                            {
                                int val = matTemp.getintValueat(row, col);
                                IntegerElement elem = new IntegerElement();
                                elem.setText(val.ToString());
                                mat_stack.Push(elem);
                            }
                            else if (matTemp.getType() == "double")
                            {
                                double val = matTemp.getdoubleValueat(row, col);
                                DoubleElement elem = new DoubleElement();
                                elem.setText(val.ToString());
                                mat_stack.Push(elem);
                            }
                        }
                        else
                        {
                            Console.Write("Range out of bound\n");
                            sendres(112, "Range out of bound\n");
                        }
                    }
                }
            }
        }

        private int getIndex(VectorElement temp)
        {
            try
            {
                if (temp.getRange() is IntegerElement)
                {
                    string r = ((IntegerElement)temp.getRange()).getText();
                    return int.Parse(r);
                }
                else
                {
                    string r;
                    if (local == 0)
                        r = ((IntegerElement)(mVariableMap[((VariableElement)temp.getRange()).getText()])).getText();
                    else
                    {
                        Hashtable hash = getHashTable(((VariableElement)temp.getRange()).getText());
                        r = ((IntegerElement)(hash[((VariableElement)temp.getRange()).getText()])).getText();
                    }
                    return int.Parse(r);
                }
            }
            catch (Exception e) { sendres(112, "Invalid index\n"); e.GetType(); return 0; }
        }

        private void vectorData(string vectorVar)
        {
            try
            {
                if (map_contains_matrix(vectorVar) && !(parallelVars.Contains(vectorVar)))
                {
                    VectorVariableDeclaration mat;
                    if (local == 0)
                        mat = (VectorVariableDeclaration)mVariableMap[vectorVar];
                    else
                    {
                        Hashtable hash = getHashTable(vectorVar);
                        mat = (VectorVariableDeclaration)hash[vectorVar];
                    }

                    matXml.WriteStartElement("Vector");
                    matXml.WriteStartElement("name");
                    matXml.WriteValue(vectorVar);
                    matXml.WriteEndElement();
                    matXml.WriteStartElement("count");
                    matXml.WriteValue(mat.getRange().getText());
                    matXml.WriteEndElement();
                    int index = int.Parse(((IntegerElement)(mat.getRange())).getText());

                    matXml.WriteStartElement("type");
                    matXml.WriteValue(mat.getType());
                    matXml.WriteEndElement();
                    if (mat.getType() == "int")
                    {
                        List<int> intElems = mat.getintValue();
                        matXml.WriteStartElement("Elements");
                        for (int i = 0; i < index; i++)
                        {
                            matXml.WriteStartElement("Element");
                            matXml.WriteValue(mat.getintValueat(i));
                            matXml.WriteEndElement();
                        }
                    }
                    else if (mat.getType() == "double")
                    {
                        List<double> doubleElems = mat.getdoubleValue();
                        matXml.WriteStartElement("Elements");
                        for (int i = 0; i < index; i++)
                        {
                            matXml.WriteStartElement("Element");
                            matXml.WriteValue(mat.getdoubleValueat(i));
                            matXml.WriteEndElement();
                        }
                    }
                    matXml.WriteEndElement();//Elements
                    matXml.WriteEndElement();//Vector
                    //matXml.Flush();
                    parallelData.Append(matStr.ToString());
                    parallelData.Append("\n");
                    parallelVars.Add(vectorVar);

                }
            }
            catch (Exception e) { sendres(112, "Parallel for : Error in Vector data\n"); e.GetType(); }
        }


        public void PerformVectorSingleElementOperation(VectorElement temp)
        {
            if (map_contains_matrix(temp.getVar().getText()))
            {
                VectorVariableDeclaration matTemp = null;
                if (temp != null)
                {
                    if (local == 0)
                        matTemp = (VectorVariableDeclaration)mVariableMap[temp.getVar().getText()];
                    else
                    {
                        Hashtable hash = getHashTable(temp.getVar().getText());
                        matTemp = (VectorVariableDeclaration)hash[temp.getVar().getText()];
                    }
                    int loc = getIndex(temp);

                    if (matTemp != null)
                    {
                        if (loc < int.Parse(matTemp.getRange().getText()))
                        {
                            if (matTemp.getType() == "int")
                            {
                                int val = matTemp.getintValueat(loc);
                                IntegerElement elem = new IntegerElement();
                                elem.setText(val.ToString());
                                mat_stack.Push(elem);
                            }
                            else if (matTemp.getType() == "double")
                            {
                                double val = matTemp.getdoubleValueat(loc);
                                DoubleElement elem = new DoubleElement();
                                elem.setText(val.ToString());
                                mat_stack.Push(elem);
                            }
                        }
                        else
                        {
                            Console.Write("Range out of bound\n");
                            sendres(112, "Range out of bound\n");
                        }
                    }
                }
            }
        }

        public override void VisitScalarArgument(ScalarArgument element)
        {
            //throw new NotImplementedException();
        }
        public override void VisitStringElement(StringElement element)
        {
            if (inParallelFor == 1)
            {

                parallelString.Append(element.getText());
            }
            else
            {
                mat_stack.Push(element);
            }
        }
        public override void VisitVectorReference(VectorReference element)
        {
            //throw new NotImplementedException();
        }

        private void ParallelVectorElement(AssignmentOperationElement element)
        {
            VectorElement temp = (VectorElement)(element.getLhs());
            parallelString.Append(temp.getVar().getText());
            parallelString.Append("[");
            if (temp.getRange() is VariableElement)
                parallelString.Append(((VariableElement)temp.getRange()).getText());
            else if (temp.getRange() is IntegerElement)
                parallelString.Append(((IntegerElement)temp.getRange()).getText());
            parallelString.Append("]");
            parallelString.Append("=");
            VisitElement(element.getRhs());

        }

        private void HandleSingleVectorElement(AssignmentOperationElement element)
        {
            if (inParallelFor == 1)
            {
                ParallelVectorElement(element);
                if (parallelVars.Contains(((VectorElement)element.getLhs()).getVar().getText()))
                {
                }
                else
                {
                    vectorData(((VectorElement)element.getLhs()).getVar().getText());
                }

            }
            else
            {
                VectorElement temp = (VectorElement)(element.getLhs());
                VectorVariableDeclaration matTemp = null;
                if (temp != null)
                {
                    int mflag = -1;
                    if (map_contains_matrix(temp.getVar().getText()))
                    {
                        if (local == 0)
                        {
                            matTemp = (VectorVariableDeclaration)mVariableMap[temp.getVar().getText()];
                            mflag = 1;//Matrix entry found
                        }
                        else
                        {
                            Hashtable hash;
                            hash = getHashTable(temp.getVar().getText());
                            matTemp = (VectorVariableDeclaration)hash[temp.getVar().getText()];
                            mflag = 1;//Matrix entry found

                        }
                    }
                    else
                        sendres(112, "Vector not declared yet\n");
                    int index = getIndex(temp);
                    Element rhs = element.getRhs();
                    VisitElement(rhs);
                    if (matTemp != null)
                    {
                        if (mat_stack.Count > 0 && mflag == 1 && matTemp.getType() == "int")
                        {
                            Object obj = getTopOfStack_Matrix();
                            int val = int.Parse(((IntegerElement)(obj)).getText());
                            if (index < int.Parse(matTemp.getRange().getText()))
                                matTemp.setintValueat(index, val);
                            else
                            {
                                Console.Write("Range out of bound\n");
                                sendres(112, "Range out of bound\n");
                            }
                            if(parallelSwarm==1)
                            writeIntResultVec(temp.getVar().getText(),index,val);

                        }
                        else if (mat_stack.Count > 0 && mflag == 1 && matTemp.getType() == "double")
                        {
                            Object obj = getTopOfStack_Matrix();
                            double val = double.Parse(((DoubleElement)(obj)).getText());
                            matTemp.setdoubleValueat(index, val);
                            if (parallelSwarm == 1)
                                writeDoubleResultVec(temp.getVar().getText(), index, val);
                        }
                    }
                }
            }
        }

        private void writeIntResultVec(string vecName, int index, int val)
        {
            parallelResult.Append("<Vector>");
            parallelResult.Append("<Name>");
            parallelResult.Append(vecName);
            parallelResult.Append("</Name>");
            parallelResult.Append("<Index>");
            parallelResult.Append(index.ToString());
            parallelResult.Append("</Index>");
            parallelResult.Append("<Value>");
            parallelResult.Append(val.ToString());
            parallelResult.Append("</Value>");
            parallelResult.Append("</Vector>");
        }

        private void writeDoubleResultVec(string vecName, int index, double val)
        {
            parallelResult.Append("<Vector>");
            parallelResult.Append("<Name>");
            parallelResult.Append(vecName);
            parallelResult.Append("</Name>");
            parallelResult.Append("<Index>");
            parallelResult.Append(index.ToString());
            parallelResult.Append("</Index>");
            parallelResult.Append("<Value>");
            parallelResult.Append(val.ToString());
            parallelResult.Append("</Value>");
            parallelResult.Append("</Vector>");
        }
        public override void VisitVectorSingleElement(VectorElement element)
        {
            try
            {
                VectorElement temp = element;
                if (inParallelFor == 1)
                {
                    if (parallelVars.Contains(element.getVar().getText()))
                    {
                    }
                    else
                    {
                        vectorData(element.getVar().getText());
                    }
                    parallelString.Append(temp.getVar().getText());
                    parallelString.Append("[");
                    if (temp.getRange() is VariableElement)
                        parallelString.Append(((VariableElement)temp.getRange()).getText());
                    else if (temp.getRange() is IntegerElement)
                        parallelString.Append(((IntegerElement)temp.getRange()).getText());
                    parallelString.Append("]");

                }
                else
                {
                    PerformVectorSingleElementOperation(element);
                }
            }
            catch (Exception e) { sendres(112, "Error in vector element\n"); e.GetType(); }

        }
        public override void VisitDoubleElement(DoubleElement element)
        {
            if (inParallelFor == 1)
            {

                parallelString.Append(element.getText());
            }
            else
            {
                mat_stack.Push(element);
            }
        }

        private void CreateForData(ForStatementElement element)
        {

        }

        public override void VisitForStatementElement(ForStatementElement element)
        {
            //throw new NotImplementedException();
            if (inParallelFor == 1)
            {
                parallelString.Append("for(" + element.RANGEVARIABLE.getText() + "->");
                parallelString.Append(element.STARTINGRANGE.getText() + " to " + element.ENDINGRANGE.getText() + ")");
                parallelString.Append("\n{");
                for (int i = 0; element.CODELIST.Count != 0 && i < element.CODELIST.Count; i++)
                {
                    VisitElement(element.CODELIST[i]);
                    if (element.CODELIST[i] is AssignmentOperationElement)
                        parallelString.Append(";");
                }
                parallelString.Append("\n}");
                CreateForData(element);
            }
            else
            {
                try
                {
                    int start = 0; int end = 0;
                    if (element.RANGEVARIABLE.getText() != null && element.STARTINGRANGE.getText() != null && element.ENDINGRANGE.getText() != null)
                    {
                        try
                        {
                            start = int.Parse(element.STARTINGRANGE.getText());
                            end = int.Parse(element.ENDINGRANGE.getText());
                        }
                        catch (Exception err)
                        {
                            sendres(113, "The range for the for loop is not set"); err.GetType();
                        }
                        //if (end != 0)
                        {
                            if (start <= end)
                            {
                             //   if (!map_contains_matrix(element.RANGEVARIABLE.getText()))
                                {
                                    local++;
                                    Hashtable localTable = new Hashtable();
                                    scope.Push(localTable);
                                    ScalarVariableDeclaration scalar_elem = new ScalarVariableDeclaration();
                                    scalar_elem.setType("int");
                                    scalar_elem.setVar(element.RANGEVARIABLE);
                                    VisitElement(scalar_elem);
                                    for (int i = start; i <= end; i++)
                                    {
                                        AssignmentOperationElement elem = new AssignmentOperationElement();
                                        elem.setLhs(element.RANGEVARIABLE);
                                        IntegerElement int_elem = new IntegerElement();
                                        int_elem.setText(i.ToString());
                                        elem.setRhs(int_elem);
                                        VisitElement(elem);
                                        List<Element> codeList = new List<Element>();
                                        codeList = element.CODELIST;
                                        for (int j = 0; j < codeList.Count; j++)
                                        {
                                            VisitElement(codeList[j]);
                                        }
                                    }
                                    scope.Pop();
                                    local--;
                                }
                             //   else
                                //    sendres(112, "The range variable in the for loop has already been used in the program. Please use a different variable.");
                            }
                            else
                                sendres(112, "The starting index should be less than the ending index");
                        }
                    }
                    else
                        sendres(112, "The ending index of the for loop cannot be zero");
                }
                catch (Exception err)
                {
                    sendres(113, "For loop cannot be executed. Please check for semantic errors"); err.GetType();
                }
            }
        }
        public override void VisitFunctionCallElement(FunctionCallElement element)
        {
            try
            {
                functionFlag = local;
                local++;
                Hashtable local_table = new Hashtable();
                Hashtable func = new Hashtable();
                Element name = element.getfunctioncallname();
                int temp_flag = 0;
                int flag = 0;
                int para_flag = 0;
                FunctionElement temp;
                if (element.getparameters().Count > 0)
                {
                    temp_flag = 1;
                }
                foreach (FunctionElement item in func_def)
                {
                    if (((VariableElement)item.getfunctionname()).getText() == ((VariableElement)name).getText())
                    {
                        flag = 1;
                        temp = item;
                        if (temp_flag == 1)
                        {
                            List<Element> arguments = element.getparameters();
                            List<Element> parameters = item.getArguments();
                            if (arguments.Count == parameters.Count)
                            {
                                for (int p = 0; p < arguments.Count; p++)
                                {
                                    if (GetTypeOfElement(arguments[p]) == GetTypeOfElement(parameters[p]))
                                    {
                                        para_flag = 1;
                                        Element elem = null;
                                        if (parameters[p] is ScalarArgument)
                                            elem = ((ScalarArgument)parameters[p]).getvariable();
                                        else if (parameters[p] is MatrixReference)
                                            elem = ((MatrixReference)parameters[p]).getvariable();
                                        else if (parameters[p] is VectorReference)
                                            elem = ((VectorReference)parameters[p]).getvariable();
                                        if (arguments[p] is IntegerElement)
                                            local_table.Add(((VariableElement)elem).getText(), arguments[p]);
                                        else if (arguments[p] is DoubleElement)
                                            local_table.Add(((VariableElement)elem).getText(), arguments[p]);
                                        else if (arguments[p] is VariableElement)
                                        {
                                            if (local == 0)
                                            {
                                                Element value = (Element)(mVariableMap[((VariableElement)elem).getText()]);
                                                local_table.Add(((VariableElement)elem).getText(), value);
                                            }
                                            else
                                            {
                                                Hashtable temp_value = getHashTable(((VariableElement)arguments[p]).getText());
                                                Element value = (Element)(temp_value[((VariableElement)arguments[p]).getText()]);
                                                local_table.Add(((VariableElement)elem).getText(), value);
                                            }
                                        }
                                    }
                                }
                                if (para_flag == 0)
                                {
                                    Console.Write("\n Parameters types do not match.. \n");
                                    sendres(112, "\n Parameters types do not match.. \n");
                                }
                            }
                            else
                            {
                                Console.Write("\n Parameters count do not match.. \n");
                                sendres(112, "\n Parameters count do not match.. \n");
                            }
                        }
                        scope.Push(local_table);
                        List<Element> body = temp.getBody();
                        for (int i = 0; i < body.Count; i++)
                        {
                            Element elem = body[i];
                            int type = GetTypeOfElement(elem);
                            if (type == 3) // matrix
                            {
                                MatrixVariableDeclaration mat_elem = (MatrixVariableDeclaration)(elem);
                                VisitMatrixElement(mat_elem);
                            }
                            else if (type == 20)
                            {
                                //for
                                ForStatementElement forstmt = (ForStatementElement)(elem);
                                VisitForStatementElement(forstmt);
                            }
                            else if (type == 21)
                            {
                                //if
                                IfStatementElement ifelse = (IfStatementElement)(elem);
                                VisitIfStatementElement(ifelse);
                            }
                            else if (type == 22)
                            {
                                // para
                                ParallelForElement para = (ParallelForElement)(elem);
                                VisitParallelForElement(para);
                            }
                            else if (type == 16)
                            {
                                VectorVariableDeclaration vec = (VectorVariableDeclaration)(elem);
                                VisitVectorElement(vec);
                            }
                            else if (type == 9) // assignment
                            {
                                AssignmentOperationElement assign = (AssignmentOperationElement)(elem);
                                VisitAssignmentOperationElement(assign);
                            }
                            else if (type == 0)  // print
                            {
                                PrintOperationElement print = (PrintOperationElement)(elem);
                                VisitPrintOperationElement(print);
                            }
                            else if (type == 1) // scalar 
                            {
                                if (elem is IntegerElement)
                                    VisitIntegerElement((IntegerElement)elem);
                                else if (elem is ScalarVariableDeclaration)
                                    VisitStructVar((ScalarVariableDeclaration)elem);
                                else if (elem is ReturnElement)
                                {

                                    if (temp.getreturntype() == "void")
                                        sendres(112, "\n Return type is void.. Cannot return.. \n");
                                    else
                                    {
                                        /*   ReturnElement ret = (ReturnElement)(elem);
                                           VisitReturnElement(ret);*/
                                        ReturnElement ret = (ReturnElement)(elem);
                                        Element ret_type = ret.getreturnvariable();

                                        int retType = GetTypeOfElement(ret_type);

                                        if (ret_type is VariableElement && temp.getreturntype() == "int" && retType == 1)
                                        {    // if (retType == 1)
                                            string var = ((VariableElement)ret_type).getText();

                                            Object obj = scope.Peek()[var];
                                            //return_var.Add(obj);
                                            mat_stack.Push(obj);
                                        }
                                        else if (temp.getreturntype() == "int" && ret_type is IntegerElement && retType == 1)
                                        {
                                            //   rType = "int";
                                            mat_stack.Push((IntegerElement)ret.getreturnvariable());
                                        }
                                        else if (temp.getreturntype() == "double" && ret_type is DoubleElement && retType == 2)
                                        {
                                            mat_stack.Push((DoubleElement)ret.getreturnvariable());
                                        }
                                        else
                                            sendres(112, "\n Return types mismatch.. \n");
                                    }
                                }

                                //ScalarVariableDeclaration scalar = (ScalarVariableDeclaration)(elem);
                                //VisitStructVar(scalar);
                            }
                            else if (type == 2) // scalar 
                            {
                                if (elem is DoubleElement)
                                    VisitDoubleElement((DoubleElement)elem);
                                else if (elem is ScalarVariableDeclaration)
                                    VisitStructVar((ScalarVariableDeclaration)elem);
                                else if (elem is ReturnElement)
                                {

                                    if (temp.getreturntype() == "void")
                                        sendres(112, "\n Return type is void.. Cannot return.. \n");
                                    else
                                    {
                                        ReturnElement ret = (ReturnElement)(elem);
                                        Element ret_type = ret.getreturnvariable();

                                        int retType = GetTypeOfElement(ret_type);

                                        if (temp.getreturntype() == "double" && ret_type is VariableElement && retType == 2)
                                        {    // if (retType == 1)

                                            string var = ((VariableElement)ret_type).getText();

                                            Object obj = scope.Peek()[var];
                                            //return_var.Add(obj);
                                            mat_stack.Push(obj);
                                        }

                                        else if (temp.getreturntype() == "int" && ret_type is IntegerElement && retType == 1)
                                        {
                                            //   rType = "int";
                                            mat_stack.Push((IntegerElement)ret.getreturnvariable());
                                        }
                                        else if (temp.getreturntype() == "double" && ret_type is DoubleElement && retType == 2)
                                        {
                                            mat_stack.Push((DoubleElement)ret.getreturnvariable());
                                        }
                                        else
                                            sendres(112, "\n Return types mismatch.. \n");
                                    }
                                }
                                //ScalarVariableDeclaration scalar = (ScalarVariableDeclaration)(elem);
                                //VisitStructVar(scalar);
                            }
                            else if (type == 10) // function call
                            {
                                FunctionCallElement call = (FunctionCallElement)(elem);
                                VisitFunctionCallElement(call);
                            }
                            else if (type == 11) // delete 
                            {
                                DeleteVariable del = (DeleteVariable)(elem);
                                VisitDeleteElement(del);
                            }
                            else if (type == 12) // return element
                            {

                            }
                            else
                            {
                            }

                        }
                        // function body


                    }
                }
                if (flag == 0)
                {
                    Console.Write("\n Function not defined.. \n");
                    sendres(112, "\n Function is not defined.. \n");
                }
                scope.Pop();
                local--;
            }
            catch (Exception e) { sendres(112, "Error in function"); e.GetType(); }
        }
        /*
        public override void VisitIfStatementElement(IfStatementElement element)
        {
            //throw new NotImplementedException();
        }
        */
        public override void VisitFunctionElement(FunctionElement element)
        {
            try
            {
                string name = ((VariableElement)element.getfunctionname()).getText();
                foreach (FunctionElement item in func_def)
                {
                    if (((VariableElement)item.getfunctionname()).getText() == name)
                        sendres(112, "\n Function definition with same name.. \n");
                }
                func_def.Push(element);
            }
            catch (Exception e) { e.GetType(); }

        }
        public override void VisitMatrixElement(MatrixVariableDeclaration element)
        {
            string variable_name = element.getVar().getText();
            string type = element.getType();
            if (local == 0)
            {

                if (mVariableMap.Contains(variable_name))
                {
                    Console.Write(" \nSemantic Error.. ");
                    sendres(112, "\nSemantic Error...\n");
                    Console.Write("\n The matrix name you entered is already existing.. try again..");
                    sendres(112, "\n The matrix name you entered is already existing.. try again..");
                    return;
                }
                else
                {
                    mVariableMap.Add(variable_name, element);
                }
            }

            else
            {

                if (scope.Peek().Count == 0)
                    scope.Peek().Add(variable_name, element);
                else
                {
                    if (scope.Peek().Contains(variable_name))
                    {
                        Console.Write(" \nSemantic Error.. ");
                        sendres(112, "\nSemantic Error...\n");
                        Console.Write("\n The matrix name you entered is already existing.. try again..");
                        sendres(112, "\n The matrix name you entered is already existing.. try again..");
                        return;
                    }
                    else
                    {
                        scope.Peek().Add(variable_name, element);
                    }
                }
            }
            /* if (mVariableMap.Count == 0)
                 mVariableMap.Add(variable_name, element);
             else
             {
                 if (mVariableMap.Contains(variable_name))
                 {
                     Console.Write(" \nSemantic Error.. ");
                     sendres(112, "\nSemantic Error...\n");
                     Console.Write("\n The matrix name you entered is already existing.. try again..");
                     sendres(112, "\n The matrix name you entered is already existing.. try again..");
                     return;
                 }
                 else
                 {
                     mVariableMap.Add(variable_name, element);
                 }
             } */
            /*int row = int.Parse(element.getRow().getText());
            int col = int.Parse(element.getColumn().getText());
            Console.Write("\n Matrix name : ");
            Console.Write(variable_name);
            Console.Write("\nMatrix Type : ");
            Console.Write(type); Console.Write("\n");
            Console.Write(" Rows : "); Console.Write(row); Console.Write("\n");
            Console.Write(" Columns : "); Console.Write(col);
            string mat_type = element.getType();
            if (mat_type == "int")
            {
                int[,] elements = element.getintValue();
                Console.Write("\nMatrix Elements are : \n");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(elements[i, j]);
                        Console.Write("\t");
                    }
                    Console.Write("\n");
                }
            }
            else if (mat_type == "double")
            {
                double[,] elemenets = element.getdoubleValue();
                if (elemenets != null)
                {
                    Console.Write("\n Matrix Elements are : \n");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            Console.Write(elemenets[i, j]);
                            Console.Write("\t");
                        }
                        Console.Write("\n");
                    }
                }
            }
            Console.Write("\n");*/

            //throw new NotImplementedException();
        }

        private void ParallelAddition(AdditiveElement element)
        {
            VisitElement(element.getLhs());
            parallelString.Append("+");
            VisitElement(element.getRhs());

        }

        private void ParallelSub(SubtractionElement element)
        {
            VisitElement(element.getLhs());
            parallelString.Append("-");
            VisitElement(element.getRhs());

        }

        private void ParallelMul(MultiplicationElement element)
        {
            VisitElement(element.getLhs());
            parallelString.Append("*");
            VisitElement(element.getRhs());

        }

        public override void VisitMultiplicationElement(MultiplicationElement element)
        {
            if (element.getRhs() == null)
            {
                Element var_name = element.getLhs();
                VisitElement(var_name);
            }
            else
            {
                if (inParallelFor == 1)
                {
                    ParallelMul(element);
                    return;
                }
                else
                {
                    VisitElement(element.getLhs());
                    VisitElement(element.getRhs());

                    if (mat_stack.Count >= 2)
                    {
                        Object obj_rhs = getTopOfStack_Matrix();
                        Object obj_lhs = getTopOfStack_Matrix();
                        int rhs_type = GetTypeOfElement((Element)obj_rhs);
                        int lhs_type = GetTypeOfElement((Element)obj_lhs);
                        if (rhs_type == 3 && lhs_type == 3) // check whether both are matrices or not
                        {

                            MatrixVariableDeclaration stk_rhs = (MatrixVariableDeclaration)(obj_rhs);
                            MatrixVariableDeclaration stk_lhs = (MatrixVariableDeclaration)(obj_lhs);
                            MatrixVariableDeclaration final = new MatrixVariableDeclaration();
                            //Object output = new Object();
                            if (stk_lhs.getType() == stk_rhs.getType())
                            {
                                IntegerElement lRow = (IntegerElement)(stk_lhs.getRow());
                                IntegerElement lCol = (IntegerElement)(stk_lhs.getColumn());
                                IntegerElement rRow = (IntegerElement)(stk_rhs.getRow());
                                IntegerElement rCol = (IntegerElement)(stk_rhs.getColumn());
                                int lhs_row = int.Parse(((IntegerElement)(stk_lhs.getRow())).getText());
                                int lhs_col = int.Parse(((IntegerElement)(stk_lhs.getColumn())).getText());
                                int rhs_row = int.Parse(((IntegerElement)(stk_rhs.getRow())).getText());
                                int rhs_col = int.Parse(((IntegerElement)(stk_rhs.getColumn())).getText());
                                if (lhs_col == rhs_row)
                                {
                                    final.setRow(lRow);
                                    final.setColumn(rCol);
                                    final.setType(stk_lhs.getType());
                                    Console.Write("Multiplication..\n");
                                    string mat_type = stk_lhs.getType();
                                    if (mat_type == "int")
                                    {
                                        int[,] lhs_elem = stk_lhs.getintValue();
                                        int[,] rhs_elem = stk_rhs.getintValue();
                                        int[,] result = new int[lhs_row, rhs_col];
                                        for (int i = 0; i < lhs_row; i++)
                                        {
                                            for (int j = 0; j < rhs_col; j++)
                                            {
                                                for (int k = 0; k < lhs_col; k++)
                                                {
                                                    int res = lhs_elem[i, k] * rhs_elem[k, j];
                                                    result[i, j] = result[i, j] + res;
                                                }
                                            }
                                        }
                                        bool mat_set = final.setIntMatrix(result);
                                        int[,] output = final.getintValue();
                                        int row = int.Parse(((IntegerElement)(final.getRow())).getText());
                                        int col = int.Parse(((IntegerElement)(final.getColumn())).getText());
                                        for (int i = 0; i < row; i++)
                                        {
                                            for (int j = 0; j < col; j++)
                                            {
                                                Console.Write("\t" + output[i, j]);
                                            }
                                            Console.Write("\n");
                                        }
                                        Object final_output = (Object)(final);
                                        mat_stack.Push(final_output);
                                    }
                                    else if (mat_type == "double")
                                    {
                                        double[,] lhs_elem = stk_lhs.getdoubleValue();
                                        double[,] rhs_elem = stk_rhs.getdoubleValue();
                                        double[,] result = new double[lhs_row, rhs_col];
                                        for (int i = 0; i < lhs_row; i++)
                                        {
                                            for (int j = 0; j < rhs_col; j++)
                                            {
                                                for (int k = 0; k < lhs_col; k++)
                                                {
                                                    double res = lhs_elem[i, k] * rhs_elem[k, j];
                                                    result[i, j] = result[i, j] + res;
                                                }
                                            }
                                        }
                                        bool mat_set = final.setDoubleMatrix(result);
                                        double[,] output = final.getdoubleValue();
                                        int row = int.Parse(((IntegerElement)(final.getRow())).getText());
                                        int col = int.Parse(((IntegerElement)(final.getColumn())).getText());
                                        for (int i = 0; i < row; i++)
                                        {
                                            for (int j = 0; j < col; j++)
                                            {
                                                Console.Write("\t" + output[i, j]);
                                            }
                                            Console.Write("\n");
                                        }
                                        Object final_output = (Object)(final);
                                        mat_stack.Push(final_output);
                                    }

                                }
                                else
                                {
                                    Console.Write("Matrix dimensions does not match for multiplication.. try again.. \n");
                                    sendres(112, "Matrix dimensions does not match for multiplication.. try again.. \n");
                                }
                            }
                            else
                            {
                                Console.Write("Matrix types are different.. try again.. ");
                                sendres(112, "Matrix types are different.. try again..\n");
                            }
                        }
                        else if (lhs_type == (int)datatypes.DoubleElement && rhs_type == (int)datatypes.DoubleElement)
                            PerformDoubleMultiplication(obj_rhs, obj_lhs);
                        else if (lhs_type == (int)datatypes.IntElement && rhs_type == (int)datatypes.IntElement)
                            PerformIntMultiplication(obj_rhs, obj_lhs);
                        else
                        {
                            Console.Write("Scalar and Matrix cannot be multiplied.. \n");
                            sendres(112, "Scalar and Matrix cannot be multiplied.. ..\n");
                        }
                    }
                    else
                    {
                        sendres(112, "Undeclared variables");
                    }
                }
            }
            //throw new NotImplementedException();
        }

        private void PerformIntMultiplication(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                IntegerElement stk_rhs = (IntegerElement)(obj_rhs);
                IntegerElement stk_lhs = (IntegerElement)(obj_lhs);
                IntegerElement final = new IntegerElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    int temp_lhs = int.Parse(stk_lhs.getText());
                    int temp_rhs = int.Parse(stk_rhs.getText());
                    final.setText((temp_lhs * temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Product: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };
        }

        private void PerformDoubleMultiplication(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                DoubleElement stk_rhs = (DoubleElement)(obj_rhs);
                DoubleElement stk_lhs = (DoubleElement)(obj_lhs);
                DoubleElement final = new DoubleElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    double temp_lhs = double.Parse(stk_lhs.getText());
                    double temp_rhs = double.Parse(stk_rhs.getText());
                    final.setText((temp_lhs * temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Product: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };
        }

        public override void VisitParallelForElement(ParallelForElement element)
        {
            try
            {
                inParallelFor = 1;
                matStr = new StringWriter();
                matXml = new XmlTextWriter(matStr);
                matXml.Formatting = Formatting.Indented;
                //matXml.WriteStartDocument();
                //matXml.WriteStartElement("root");
                if (parallelVars != null && parallelVars.Count > 0)
                    parallelVars.Clear();
                parallelString.Remove(0, parallelString.Length);
                rangeVar = element.RANGEVARIABLE.getText();
                int start = int.Parse(element.STARTINGRANGE.getText());
                int end=int.Parse(element.ENDINGRANGE.getText());
                List<Element> l1 = null;
                for (int s = 0; element.PARALLELCODE.Count > 0 && s < element.PARALLELCODE.Count; s++)
                {
                    inParallelFor = 1;
                    l1 = element.PARALLELCODE[s];

                    for (int i = 0; l1 != null && i < l1.Count; i++)
                    {
                        VisitElement(l1[i]);
                        if (l1[i] is AssignmentOperationElement)
                            parallelString.Append(";");
                    }
                    //sendToSwarm(start,end,body,string)
                    //convertParallel(matStr.ToString(), parallelString.ToString(), 0, l1.Count);
                    //execParallel(parallelString.ToString(),parallelData.ToString(),0, l1.Count);
                    inParallelFor = 0;
                    smem.distributeParallelCode(start, end,parallelData.ToString(),parallelString.ToString(),rangeVar);
                    parallelData.Length = 0;
                    parallelString.Length = 0;
                    while (result_.Count == 0)
                    {
                        Thread.Sleep(2000);
                    }
                    result_.Clear();
                    //wait
                }
                inParallelFor = 0;
                //matXml.WriteEndElement();
                //CreateData(matStr.ToString());
                //result(matStr.ToString());
                //result(parallelString.ToString());
            }
            catch (Exception e) { sendres(112, "Parallel for:Error processing\n"); e.GetType(); }

            //throw new NotImplementedException();
        }

        private Plot convert_Ele_to_plot(PlotFunctionElement p)
        {
            Plot p1 = new Plot();
            p1.Command = p.getPlotFunction();
            p1.PaneNum = p.getPeno() == null ? 0 : int.Parse(p.getPeno().getText());

            if (p.getData() != null && mVariableMap.ContainsKey(p.getData().getText()))
            {
                double[,] temp = ((MatrixVariableDeclaration)(mVariableMap[p.getData().getText()])).getdoubleValue();
                p1.Data = p.getData().getText() == null ? null : temp;
            }
            p1.Mode = p.getMode() == null ? 0 : int.Parse(p.getMode().getText());
            p1.Dimensions = p.getPlotType() == null ? 0 : p.getPlotType() == "2D" ? 2 : 3;
            p1.PlotTitle = p.getTitle() == null ? "" : p.getTitle().getText();
            p1.X_Fact = p.getXFact() == null ? 1.0 : double.Parse(p.getXFact().getText());
            p1.Y_Fact = p.getYFact() == null ? 1.0 : double.Parse(p.getYFact().getText());
            p1.Z_Fact = p.getZFact() == null ? 1.0 : double.Parse(p.getZFact().getText());
            p1.X_Axis_Title = p.getXTitle() == null ? "" : p.getXTitle().getText();
            p1.Y_Axis_Title = p.getYTitle() == null ? "" : p.getYTitle().getText();
            p1.Z_Axis_Title = p.getZTitle() == null ? "" : p.getZTitle().getText();
            p1.ScaleMode = p.getScaleMode() == null ? 1 : (p.getScaleMode() == "linear") ? 1 : 2;
            return (p1);
        }
        public override void VisitPlotFunctionElement(PlotFunctionElement element)
        {
            if (element.getPlotFunction() == "plot" || element.getPlotFunction() == "subPlot")
            {
                if (mVariableMap.ContainsKey(element.getData().getText()))
                {
                    //   double[,] temp = ((MatrixVariableDeclaration)(mVariableMap[element.getData().getText()])).getdoubleValue();
                    if (element.getPlotFunction() == "subPlot")
                    {
                        int pane = int.Parse(element.getPeno().getText()); //.getPane().getText());
                        string plotType = element.getPlotType();

                        if (pane > 4 || pane <= 0)
                        {
                            Console.Write("pane no. is not valid.. it lies between 1 to 4.. Try again..");
                            sendres(112, "pane no. is not valid.. it lies between 1 to 4.. Try again..");
                            return;
                        }
                        else if (plotType == "2D" || plotType == "1D")
                        {
                            if ((IntegerElement)(element.getMode()) != null)
                            {
                                Console.Write("Invalid argumenet.. Mode is not required.. Try again.. ");
                                sendres(112, "Invalid argumenet.. Mode is not required.... Try again..");
                                return;
                            }
                        }
                        else if (plotType == "3D")
                        {
                            int mode = int.Parse(((IntegerElement)(element.getMode())).getText());
                            if (mode > 3 || mode <= 0)
                            {
                                Console.Write("Invalid mode.. Give the input between 1..3 ");
                                sendres(112, "Invalid mode.. Give the input between 1..3 ");
                                return;
                            }
                        }
                    }
                    else if (element.getPlotFunction() == "plot")
                    {
                        string plotType = element.getPlotType();
                        string data = element.getData().getText();
                        if (plotType == "1D" || plotType == "2D")
                        {
                            if ((IntegerElement)(element.getMode()) != null)
                            {
                                Console.Write("Invalid argumenet.. Mode is not required.. Try again.. ");
                                sendres(112, "Invalid argumenet.. Mode is not required.. Try again.. ");
                                return;
                            }
                        }
                        else if (plotType == "3D")
                        {
                            int mode = int.Parse(((IntegerElement)(element.getMode())).getText());
                            if (mode >= 3 || mode <= 0)
                            {
                                Console.Write("Invalid mode.. Give the input between 1..3 ");
                                sendres(112, "Invalid mode.. Give the input between 1..3 ");
                                return;
                            }

                        }
                    }
                }
                else
                {
                    Console.Write("Plot data not declared.. Try again..");
                    sendres(112, "Plot data not declared.. Try again..");
                    return;
                }
            }

            else if (element.getPlotFunction() == "setScaleMode")
            {
                string scaleMode = element.getScaleMode();
                if (scaleMode != "log" || scaleMode != "linear")
                {
                    Console.Write("Invalid scale mode.. it should be either 'linear' or 'log'");
                    sendres(112, "Invalid scale mode.. it should be either 'linear' or 'log'");
                    return;
                }
            }


            Plot pr = new Plot();
            pr = convert_Ele_to_plot(element);
            p.writetolist(pr);

        }


        public override void VisitReturnElement(ReturnElement element)
        {
            //ReturnElement ret = (ReturnElement)(elem);
            /* Element ret_type = element.getreturnvariable();
             int retType = GetTypeOfElement(ret_type);
             string rType = "";
             if (retType == 1)
                rType = "int";
             else if (retType == 2)
                 rType = "double";
             if (temp.getreturntype() != rType)
                 sendres(112, "\n Return types mismatch.. \n");*/


            /* result("Returned Value : \n");
             int ret_type = GetTypeOfElement(element);
             if (ret_type == 1)
             {
                 string temp = (((VariableElement)element)).getText();
                 if (map_contains_matrix(temp))
                     result(scope.Peek()[temp].ToString());
             }*/
            /* int value = int.Parse(((IntegerElement)(element)).getText().ToString());
         result(((VariableElement)element.getreturnvariable()).getText());*/
            //throw new NotImplementedException();
        }
        public override void VisitStructVar(ScalarVariableDeclaration element)
        {
            //throw new NotImplementedException();
            string int_name = (element.getVar()).getText();
            if (local == 0)
            {
                if (mVariableMap.Contains(int_name))
                {
                    Console.Write("Variable Already Declared\n");
                    sendres(112, "Variable Already Declared\n");
                }
                else
                    mVariableMap.Add(int_name, element);
            }
            else
            {
                if (scope.Peek().Count == 0)
                    scope.Peek().Add(int_name, element);
                else
                {
                    if (scope.Peek().Contains(int_name))
                    {
                        Console.Write("Variable Already Declared\n");
                        sendres(112, "Variable Already Declared\n");
                    }
                    else
                        scope.Peek().Add(int_name, element);
                }
            }
        }
        public override void VisitSubtractionElement(SubtractionElement element)
        {
            if (element.getRhs() == null)
                VisitElement(element.getLhs());
            else
            {
                if (inParallelFor == 1)
                {
                    ParallelSub(element);
                    return;
                }
                else
                {
                    VisitElement(element.getLhs());
                    VisitElement(element.getRhs());
                    if (mat_stack.Count >= 2)
                    {
                        Object obj_rhs = getTopOfStack_Matrix();
                        Object obj_lhs = getTopOfStack_Matrix();
                        int rhs_type = GetTypeOfElement((Element)obj_rhs);
                        int lhs_type = GetTypeOfElement((Element)obj_lhs);
                        if (rhs_type == 3 && lhs_type == 3) // check whether both are matrices or not
                        {
                            MatrixVariableDeclaration stk_rhs = (MatrixVariableDeclaration)(obj_rhs);
                            MatrixVariableDeclaration stk_lhs = (MatrixVariableDeclaration)(obj_lhs);
                            MatrixVariableDeclaration final = new MatrixVariableDeclaration();
                            if (stk_lhs != null && stk_rhs != null)
                            {
                                if (stk_lhs.getType() == stk_rhs.getType())
                                {
                                    IntegerElement lRow = (IntegerElement)(stk_lhs.getRow());
                                    IntegerElement lCol = (IntegerElement)(stk_lhs.getColumn());
                                    IntegerElement rRow = (IntegerElement)(stk_rhs.getRow());
                                    IntegerElement rCol = (IntegerElement)(stk_rhs.getColumn());
                                    int lhs_row = int.Parse(((IntegerElement)(stk_lhs.getRow())).getText());
                                    int lhs_col = int.Parse(((IntegerElement)(stk_lhs.getColumn())).getText());
                                    int rhs_row = int.Parse(((IntegerElement)(stk_rhs.getRow())).getText());
                                    int rhs_col = int.Parse(((IntegerElement)(stk_rhs.getColumn())).getText());
                                    if (lhs_row == rhs_row && lhs_col == rhs_col)
                                    {
                                        final.setRow(lRow);
                                        final.setColumn(lCol);
                                        final.setType(stk_lhs.getType());
                                        Console.Write("Subtraction..\n");
                                        Console.Write(element.getLhs().GetType());
                                        string mat_type = stk_lhs.getType();
                                        if (mat_type == "int")
                                        {
                                            int[,] rhs_elements = stk_rhs.getintValue();
                                            int[,] lhs_elements = stk_lhs.getintValue();
                                            int[,] output = new int[lhs_row, lhs_col];
                                            for (int i = 0; i < lhs_row; i++)
                                            {
                                                for (int j = 0; j < lhs_col; j++)
                                                {
                                                    output[i, j] = lhs_elements[i, j] - rhs_elements[i, j];
                                                    Console.Write(output[i, j]);
                                                    Console.Write("\t");
                                                }
                                                Console.Write("\n");
                                            }
                                            bool mat_set = final.setIntMatrix(output);
                                        }
                                        else if (mat_type == "double")
                                        {
                                            double[,] rhs_elements = stk_rhs.getdoubleValue();
                                            double[,] lhs_elements = stk_lhs.getdoubleValue();
                                            double[,] output = new double[lhs_row, lhs_col];
                                            for (int i = 0; i < lhs_row; i++)
                                            {
                                                for (int j = 0; j < lhs_col; j++)
                                                {
                                                    output[i, j] = lhs_elements[i, j] - rhs_elements[i, j];
                                                    Console.Write(output[i, j]);
                                                    Console.Write("\t");
                                                }
                                                Console.Write("\n");
                                            }
                                            bool mat_set = final.setDoubleMatrix(output);
                                        }
                                        Object result = (Object)(final);
                                        mat_stack.Push(result);
                                    }
                                }
                                else
                                {
                                    Console.Write("Matrix dimensions does not match.. try again.. \n");
                                    sendres(112, "Matrix dimensions does not match.. try again.. \n");
                                }
                            }
                        }
                        else if (lhs_type == 2 && rhs_type == 2)
                        {
                            //Double
                            PerformDoubleSubtraction(obj_rhs, obj_lhs);

                        }
                        else if (lhs_type == 1 && rhs_type == 1)
                        {
                            //Int
                            PerformIntSubtraction(obj_rhs, obj_lhs);
                        }
                        else
                        {
                            Console.Write("Scalar and matrix subtraction not possible\n");
                            sendres(112, "Scalar and matrix subtraction not possible\n");
                        }
                    }
                    else
                    {
                        Console.Write("Matrix types are different.. try again.. ");
                        sendres(112, "Matrix types are different.. try again.. ");
                    }
                }
            }
        }

        private void PerformDoubleSubtraction(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                DoubleElement stk_rhs = (DoubleElement)(obj_rhs);
                DoubleElement stk_lhs = (DoubleElement)(obj_lhs);
                DoubleElement final = new DoubleElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    double temp_lhs = double.Parse(stk_lhs.getText());
                    double temp_rhs = double.Parse(stk_rhs.getText());
                    final.setText((temp_lhs - temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Difference: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };

        }

        private void PerformIntSubtraction(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                IntegerElement stk_rhs = (IntegerElement)(obj_rhs);
                IntegerElement stk_lhs = (IntegerElement)(obj_lhs);
                IntegerElement final = new IntegerElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    int temp_lhs = int.Parse(stk_lhs.getText());
                    int temp_rhs = int.Parse(stk_rhs.getText());
                    final.setText((temp_lhs - temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Difference: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };

        }
        public override void VisitVectorElement(VectorVariableDeclaration element)
        {
            string variable_name = element.getText().getText();
            string type = element.getType();
            if (local == 0)
            {
                if (mVariableMap.Contains(variable_name))
                {
                    Console.Write(" \nSemantic Error.. ");
                    sendres(112, "\nSemantic Error...\n");
                    Console.Write("\n The matrix name you entered is already existing.. try again..");
                    sendres(112, "\n The matrix name you entered is already existing.. try again..");
                    return;
                }
                else
                {
                    mVariableMap.Add(variable_name, element);
                }
            }
            else
            {
                if (scope.Peek().Count == 0)
                    scope.Peek().Add(variable_name, element);
                else
                {
                    if (scope.Peek().Contains(variable_name))
                    {
                        Console.Write(" \nSemantic Error.. ");
                        sendres(112, "\nSemantic Error...\n");
                        Console.Write("\n The matrix name you entered is already existing.. try again..");
                        sendres(112, "\n The matrix name you entered is already existing.. try again..");
                        return;
                    }
                    else
                    {
                        scope.Peek().Add(variable_name, element);
                    }
                }
            }
            string elem_type = "";
            IntegerElement range = element.getRange();
            List<int> int_elem = new List<int>();
            List<double> double_elem = new List<double>();

            if (element.getintValue() != null)
            {
                int_elem = element.getintValue();
                elem_type = "int";

            }
            else if (element.getdoubleValue() != null)
            {
                double_elem = element.getdoubleValue();
                elem_type = "double";
            }
            if (type != elem_type)
                sendres(112, "\nType mismatch..\n");
            else
            {
                if (elem_type == "int")
                {
                    int elem_count = int.Parse(range.getText());
                    if (elem_count != int_elem.Count)
                        sendres(112, "\nRange and number of elements do not match...\n");
                }
                else if (elem_type == "double")
                {
                    int elem_count = int.Parse(range.getText());
                    if (elem_count != double_elem.Count)
                        sendres(112, "\nRange and number of elements do not match...\n");
                }
                // if( int.Parse(range.getText())!= elements.Count)
                // sendres(112, "\nRange and number of elements do not match...\n");
            }
            //throw new NotImplementedException();
        }

        //public override void VisitMatrixOperationElement(MatrixOperationElement element) { }
        public override void VisitIntegerElement(IntegerElement element)
        {
            if (inParallelFor == 1)
            {
                parallelString.Append(element.getText());
            }
            else
            {
                mat_stack.Push(element);
            }

        }


        public override void VisitAssignmentOperationElement(AssignmentOperationElement element)
        {
            StructAssignDeclaration temp;
            StructDeclaration structTemp = null;
            int flag = -1;

            //Handle struct
            if (GetTypeOfElement(element.getLhs()) == 4)
            {
                temp = (StructAssignDeclaration)(element.getLhs());
                if (mVariableMap.ContainsKey(((VariableElement)(temp.getObjName())).getText())) //getName()))
                {
                    structTemp = (StructDeclaration)mVariableMap[((VariableElement)(temp.getObjName())).getText()]; //.getName()];
                    flag = 1;
                }
                else
                    sendres(112, "Structure " + ((VariableElement)(temp.getObjName())).getText() + " not found\n");

                Element rhs = element.getRhs();
                VisitElement(rhs);
                if (mat_stack.Count > 0 && flag == 1)
                {
                    Object obj = getTopOfStack_Matrix();
                    List<ScalarVariableDeclaration> l1 = structTemp.getVarType();
                    for (int i = 0; i < l1.Count; i++)
                        if (l1[i].getVar().getText() == ((VariableElement)temp.getDataMember()).getText())
                        {
                            if (obj is IntegerElement)
                            {
                                result("Struct member set:" + ((IntegerElement)obj).getText());
                                finalResult.Append("Struct member set:" + ((IntegerElement)obj).getText());
                            }
                        }
                    //temp.setObjName((Element)(obj));  //.setObj((Element)(obj));
                }
            }
            else if (GetTypeOfElement(element.getLhs()) == 5)
            {
               // Thread.Sleep(5);
                HandleSingleMatrixElement(element);
            }
            else if (GetTypeOfElement(element.getLhs()) == 15)
                HandleSingleVectorElement(element);
            else if (map_contains_matrix(((VariableElement)(element.getLhs())).getText()))
            {
                if (inParallelFor == 1)
                {
                    parallelString.Append((((VariableElement)(element.getLhs())).getText()));
                    parallelString.Append("=");
                    VisitElement(element.getRhs());
                    if(local==0)
                    {
                    if (mVariableMap[(((VariableElement)(element.getLhs())).getText())] is MatrixVariableDeclaration)
                        matrixData((((VariableElement)(element.getLhs())).getText()));
                    else if (mVariableMap[(((VariableElement)(element.getLhs())).getText())] is IntegerElement)
                        varData((((VariableElement)(element.getLhs())).getText()));
                    else if (mVariableMap[(((VariableElement)(element.getLhs())).getText())] is DoubleElement)
                        varData((((VariableElement)(element.getLhs())).getText()));
                    }
                    else
                    {
                    Hashtable hash=getHashTable((((VariableElement)(element.getLhs())).getText()));
                    if (hash[(((VariableElement)(element.getLhs())).getText())] is MatrixVariableDeclaration)
                        matrixData((((VariableElement)(element.getLhs())).getText()));
                    else if (hash[(((VariableElement)(element.getLhs())).getText())] is IntegerElement)
                        varData((((VariableElement)(element.getLhs())).getText()));
                    else if (hash[(((VariableElement)(element.getLhs())).getText())] is DoubleElement)
                        varData((((VariableElement)(element.getLhs())).getText()));
                    }
                }
                else
                {
                string var_name = ((VariableElement)(element.getLhs())).getText();
                Element rhs = element.getRhs();
                VisitElement(rhs);

                if (mat_stack.Count > 0 && flag == -1)
                {
                    Object obj = getTopOfStack_Matrix();
                    if (GetTypeOfElement(element.getLhs()) == GetTypeOfElement(((Element)obj)))
                    {
                        if ((GetTypeOfElement(element.getLhs()) == 3))
                        {
                            MatrixVariableDeclaration tempmat = null;
                            if (local == 0)
                            {
                                tempmat = ((MatrixVariableDeclaration)(mVariableMap[((VariableElement)(element.getLhs())).getText()]));
                            }
                            else
                            {
                                Hashtable hash = getHashTable(((VariableElement)(element.getLhs())).getText());
                                tempmat = ((MatrixVariableDeclaration)(hash[((VariableElement)(element.getLhs())).getText()]));
                            }
                            if (tempmat.getType() == (((MatrixVariableDeclaration)(((Element)obj))).getType()))
                            {
                                int rhs_row = int.Parse(((IntegerElement)((((MatrixVariableDeclaration)(((Element)obj))).getRow()))).getText());
                                int lhs_col = int.Parse(((IntegerElement)(tempmat.getColumn())).getText());
                                int lhs_row = int.Parse(((IntegerElement)(tempmat.getRow())).getText());
                                int rhs_col = int.Parse(((IntegerElement)((((MatrixVariableDeclaration)(((Element)obj))).getColumn()))).getText());

                                if (lhs_col == rhs_col && lhs_row == rhs_row)
                                {
                                    if (local == 0)
                                    {
                                        mVariableMap.Remove(var_name);
                                        mVariableMap.Add(var_name, obj);
                                    }
                                    else
                                    {
                                        Hashtable hash = getHashTable(var_name);
                                        hash.Remove(var_name);
                                        hash.Add(var_name, obj);
                                    }
                                }
                                else
                                    sendres(112, "Rows and columns of matrices do not match\n");
                            }
                            else
                                sendres(112, "Matrices are of different types\n");
                        }
                        else
                        {
                            if (local == 0)
                            {
                                mVariableMap.Remove(var_name);
                                mVariableMap.Add(var_name, obj);
                            }
                            else
                            {
                                Hashtable hash = getHashTable(var_name);
                                hash.Remove(var_name);
                                hash.Add(var_name, obj);
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Datatypes mismatch\n");
                        sendres(112, "Datatypes mismatch\n");
                    }
                }
                else
                {
                    Console.Write("Variable not found");
                    sendres(112, "Variable not found");
                }
            }
            }
            else
            {
                Console.Write("Variable not declared");
                sendres(112, "Variable not declared");
            }
        }
        public List<string> result_=new List<string>();
        private void ProcessResults(List<string> result)
        {
            try
            {
                //Thread.Sleep(2);
                for (int i = 0; result.Count != 0 && i < result.Count; i++)
                {
                    int curElement = 0;
                    MatrixVariableDeclaration matTemp = null;
                    VectorVariableDeclaration vec = null;
                    StringReader readStr = new StringReader(result[i]);
                    XmlTextReader xf = new XmlTextReader(readStr);
                    string matElem = "";
                    int currRow = 0;
                    int currCol = 0;
                    string type = "";
                    string name = "";
                    int value = 0;
                    double dvalue = 0.0;
                    while (xf.Read())
                    {
                        switch (xf.NodeType)
                        {
                            case XmlNodeType.Element:
                                {
                                    if (xf.Name == "Matrix")
                                        curElement = 1;
                                    if (xf.Name == "Vector")
                                        curElement = 2;
                                    if (curElement == 2)
                                    {
                                        if (xf.Name == "name")
                                            matElem = "name";

                                    }
                                    if (curElement == 1)
                                    {
                                        if (xf.Name == "Name")
                                            matElem = "name";
                                        if (xf.Name == "Row")
                                            matElem = "row";
                                        if (xf.Name == "Column")
                                            matElem = "column";
                                        if (xf.Name == "type")
                                            matElem = "type";
                                        if (xf.Name == "Value")
                                            matElem = "value";
                                    }
                                    if (curElement == 2)
                                    {
                                        if (xf.Name == "Name")
                                            matElem = "name";
                                        if (xf.Name == "Index")
                                            matElem = "index";
                                        if (xf.Name == "type")
                                            matElem = "type";
                                        if (xf.Name == "Value")
                                        {
                                            matElem = "value";
                                        }
                                    }

                                    break;
                                }
                            case XmlNodeType.Text:
                                {
                                    if (curElement == 1)
                                    {
                                        if (matElem == "row")
                                            currRow = int.Parse(xf.Value.ToString());
                                        if (matElem == "column")
                                            currCol = int.Parse(xf.Value.ToString());
                                        if (matElem == "name")
                                        {
                                            name = xf.Value;
                                            if (map_contains_matrix(name))
                                            {
                                                if (local == 0)
                                                {
                                                    matTemp = (MatrixVariableDeclaration)mVariableMap[name];
                                                }
                                                else
                                                {
                                                    Hashtable hash = getHashTable(name);
                                                    matTemp = (MatrixVariableDeclaration)hash[name];
                                                }
                                            }
                                        }
                                        if (matElem == "type")
                                        {
                                            if (matTemp != null)
                                                type = matTemp.getType(); ;

                                        }
                                        if (matElem == "value")
                                        {
                                            if (matTemp.getType()=="int")
                                                value = int.Parse(xf.Value.ToString());
                                            else if (matTemp.getType() == "double")
                                                dvalue = double.Parse(xf.Value.ToString());
                                        }
                                    }
                                    if (curElement == 2)
                                    {
                                        if (matElem == "index")
                                        {
                                            currRow = int.Parse(xf.Value);
                                        }
                                        if (matElem == "name")
                                        {
                                            name = xf.Value;
                                            if (map_contains_matrix(name))
                                            {
                                                if (local == 0)
                                                {
                                                    vec = (VectorVariableDeclaration)mVariableMap[name];
                                                }
                                                else
                                                {
                                                    Hashtable hash = getHashTable(name);
                                                    vec = (VectorVariableDeclaration)hash[name];

                                                }
                                            }
                                        }
                                        if (matElem == "type")
                                        {
                                            if (vec != null)
                                                type = vec.getType();
                                        }
                                        if (matElem == "value")
                                        {
                                            if (vec.getType() == "int")
                                                value = int.Parse(xf.Value.ToString());
                                            else if (vec.getType() == "double")
                                                dvalue = double.Parse(xf.Value.ToString());
                                        }
                                    }
                                    break;
                                }
                            case XmlNodeType.EndElement:
                                {
                                    if (xf.Name == "Value" && curElement == 1)
                                    {
                                        if (matTemp.getType()=="int")
                                            matTemp.setintValueat(currRow, currCol, value);
                                        else if (matTemp.getType() == "double")
                                            matTemp.setdoubleValueat(currRow, currCol, dvalue);
                                    }
                                    if (xf.Name == "Value" && curElement == 2)
                                    {
                                        if (vec.getType() == "int")//TBD
                                            vec.setintValueat(currRow, value);
                                        else if (vec.getType() == "double")
                                            vec.setdoubleValueat(currRow, value);

                                    }
                                    Console.Write("End:" + xf.Name);
                                    break;
                                }
                            default:
                                {
                                    Console.Write("\n");
                                    break;
                                }
                        }
                    }

                }
                //result_.Clear();
                result_ = result;
            }
            catch (Exception e) { e.GetType(); }
        }
        //Set the single matrix element
        public void HandleSingleMatrixElement(AssignmentOperationElement element)
        {
            if (inParallelFor == 1)
            {
                ParallelMatrixElement(element);
                if (parallelVars.Contains(((MatrixElement)element.getLhs()).getVar().getText()))
                {
                }
                else
                {
                    matrixData(((MatrixElement)element.getLhs()).getVar().getText());
                }

            }
            else
            {
                MatrixElement temp = (MatrixElement)(element.getLhs());
                MatrixVariableDeclaration matTemp = null;
                int row = getMatrixRow(temp);// int.Parse(((IntegerElement)(temp.getRow())).getText());
                int col = getMatrixCol(temp);// int.Parse(((IntegerElement)(temp.getColumn())).getText());
                int mflag = -1;
                if (map_contains_matrix(temp.getVar().getText()))
                {
                    if (local == 0)
                    {
                        matTemp = (MatrixVariableDeclaration)mVariableMap[temp.getVar().getText()];
                        mflag = 1;//Matrix entry found

                    }
                    else
                    {
                        Hashtable hash = getHashTable(temp.getVar().getText());
                        matTemp = (MatrixVariableDeclaration)hash[temp.getVar().getText()];
                        mflag = 1;//Matrix entry found
                    }
                }
                else
                {
                    Console.Write("Matrix not declared yet\n");
                    sendres(112, "Matrix not declared yet\n");
                }

                Element rhs = element.getRhs();
                VisitElement(rhs);
                if (matTemp != null)
                {
                    if (mat_stack.Count > 0 && mflag == 1 && matTemp.getType() == "int")
                    {
                        Object obj = getTopOfStack_Matrix();
                        int val = int.Parse(((IntegerElement)(obj)).getText());
                        if (row < int.Parse(matTemp.getRow().getText()) && col < int.Parse(matTemp.getColumn().getText()))
                            matTemp.setintValueat(row, col, val);
                        else
                        {
                            Console.Write("Range out of bound\n");
                            sendres(112, "Range out of bound\n");
                        }
                        if (parallelSwarm == 1)
                            writeIntResult(((MatrixElement)element.getLhs()).getVar().getText(), row, col, val);
                    }
                    else if (mat_stack.Count > 0 && mflag == 1 && matTemp.getType() == "double")
                    {
                        Object obj = getTopOfStack_Matrix();
                        double val = double.Parse(((DoubleElement)(obj)).getText());
                        matTemp.setdoubleValueat(row, col, val);
                        if (parallelSwarm == 1)
                            writeDoubleResult(((MatrixElement)element.getLhs()).getVar().getText(), row, col, val);
                    }
                }
            }
        }

        private int GetTypeOfElement(Element elem)
        {
            if (elem is IntegerElement)
            {
                return (int)datatypes.IntElement;
            }
            else if (elem is DoubleElement)
            {
                return (int)datatypes.DoubleElement;
            }
            else if (elem is ForStatementElement)
            {
                return (int)datatypes.forstmt;
            }
            else if (elem is IfStatementElement)
            {
                return (int)datatypes.ifelse;
            }
            else if (elem is ParallelForElement)
            {
                return (int)datatypes.paraFor;
            }
            else if (elem is MatrixVariableDeclaration)
            {
                return (int)datatypes.Matrix;
            }
            else if (elem is MatrixReference)
                return (int)datatypes.Matrix;
            else if (elem is VectorVariableDeclaration)
            {
                return (int)datatypes.Vector;
            }
            else if (elem is VectorReference)
                return (int)datatypes.Vector;
            else if (elem is VectorElement)
                return 15;
            else if (elem is StructAssignDeclaration)
            {
                return (int)datatypes.Struct;
            }
            else if (elem is StructObjectDeclaration)
            {
                return (int)datatypes.Struct;
            }
            else if (elem is StructDeclaration)
            {
                return (int)datatypes.Struct;
            }
            else if (elem is FunctionCallElement)
            {
                return (int)datatypes.func;
            }
            else if (elem is DeleteVariable)
            {
                return (int)datatypes.delete;
            }
            else if (elem is ReturnElement)
            {
                if (((ReturnElement)(elem)).getreturnvariable() is IntegerElement)
                    return (int)datatypes.IntElement;
                else if (((ReturnElement)(elem)).getreturnvariable() is DoubleElement)
                    return (int)datatypes.DoubleElement;
                else if (((ReturnElement)(elem)).getreturnvariable() is StringElement)
                    return 7;
                else if (((ReturnElement)(elem)).getreturnvariable() is VariableElement)
                {
                    int a = GetTypeOfElement((Element)((ReturnElement)(elem)).getreturnvariable());
                    return a;
                }
                else
                    return 0;

            }
            else if (elem is MatrixElement)
            {
                return (int)datatypes.MatrixElement;
            }
            else if (elem is VariableElement)
            {
                if (map_contains_matrix(((VariableElement)(elem)).getText()))
                {
                    if (local == 0)
                    {
                        int a = GetTypeOfElement(((Element)(mVariableMap[((VariableElement)(elem)).getText()])));
                        return a;
                    }
                    else
                    {
                        Hashtable hash = getHashTable(((VariableElement)(elem)).getText());
                        int a = GetTypeOfElement(((Element)(hash[((VariableElement)(elem)).getText()])));
                        return a;
                    }
                }
                else
                    return 0;
            }
            /*else if (elem is SubtractionElement)
            {
                return (int)datatypes.Subtraction;
            }*/
            else if (elem is ScalarVariableDeclaration)
            {
                if (((ScalarVariableDeclaration)(elem)).getType() == "int")
                    return (int)datatypes.IntElement;
                else if (((ScalarVariableDeclaration)(elem)).getType() == "double")
                    return (int)datatypes.DoubleElement;
                else if (((ScalarVariableDeclaration)(elem)).getType() == "string")
                    return 7;
                else
                    return 0;
            }
            else if (elem is ScalarArgument)
            {
                if (((ScalarArgument)(elem)).gettype() == "int")
                    return (int)datatypes.IntElement;
                else if (((ScalarArgument)(elem)).gettype() == "double")
                    return (int)datatypes.DoubleElement;
                else if (((ScalarArgument)(elem)).gettype() == "string")
                    return 7;
                else
                    return 0;
            }
            else if (elem is StringElement)
                return (int)datatypes.Strings;
            else if (elem is AssignmentOperationElement)
                return (int)datatypes.Assignment;
            else
                return 0;
        }
        public override void VisitAdditionOperationElement(AdditiveElement element)
        {
            if (element.getRhs() == null)
            {
                VisitElement(element.getLhs());
            }
            else
            {
                if (inParallelFor == 1)
                {
                    ParallelAddition(element);
                    return;
                }
                else
                {
                    VisitElement(element.getLhs());
                    VisitElement(element.getRhs());
                    if (mat_stack.Count >= 2)
                    {
                        Object obj_rhs = getTopOfStack_Matrix();
                        Object obj_lhs = getTopOfStack_Matrix();
                        int rhs_type = GetTypeOfElement((Element)obj_rhs);
                        int lhs_type = GetTypeOfElement((Element)obj_lhs);
                        if (rhs_type == 3 && lhs_type == 3)
                        {
                            MatrixVariableDeclaration stk_rhs = (MatrixVariableDeclaration)(obj_rhs);
                            MatrixVariableDeclaration stk_lhs = (MatrixVariableDeclaration)(obj_lhs);
                            MatrixVariableDeclaration final = new MatrixVariableDeclaration();
                            if (stk_lhs != null && stk_rhs != null)
                            {
                                if (stk_lhs.getType() == stk_rhs.getType())
                                {
                                    IntegerElement lRow = (IntegerElement)(stk_lhs.getRow());
                                    IntegerElement lCol = (IntegerElement)(stk_lhs.getColumn());
                                    IntegerElement rRow = (IntegerElement)(stk_rhs.getRow());
                                    IntegerElement rCol = (IntegerElement)(stk_rhs.getColumn());

                                    int lhs_row = int.Parse(((IntegerElement)(stk_lhs.getRow())).getText());
                                    int lhs_col = int.Parse(((IntegerElement)(stk_lhs.getColumn())).getText());
                                    int rhs_row = int.Parse(((IntegerElement)(stk_rhs.getRow())).getText());
                                    int rhs_col = int.Parse(((IntegerElement)(stk_rhs.getColumn())).getText());
                                    if (lhs_row == rhs_row && lhs_col == rhs_col)
                                    {
                                        final.setRow(lRow);
                                        final.setColumn(lCol);
                                        final.setType(stk_lhs.getType());

                                        Console.Write("Addition..\n");
                                        Console.Write(element.getLhs().GetType());
                                        string mat_type = stk_lhs.getType();
                                        if (mat_type == "int")
                                        {
                                            int[,] rhs_elements = stk_rhs.getintValue();
                                            int[,] lhs_elements = stk_lhs.getintValue();
                                            int[,] output = new int[lhs_row, lhs_col];
                                            for (int i = 0; i < lhs_row; i++)
                                            {
                                                for (int j = 0; j < lhs_col; j++)
                                                {
                                                    output[i, j] = lhs_elements[i, j] + rhs_elements[i, j];
                                                    Console.Write(output[i, j]);
                                                    Console.Write("\t");
                                                }
                                                Console.Write("\n");
                                            }
                                            bool mat_set = final.setIntMatrix(output);
                                        }
                                        else if (mat_type == "double")
                                        {
                                            double[,] rhs_elements = stk_rhs.getdoubleValue();
                                            double[,] lhs_elements = stk_lhs.getdoubleValue();
                                            // int[,] result = new int[lhs_row, lhs_col];
                                            double[,] output = new double[lhs_row, lhs_col];
                                            for (int i = 0; i < lhs_row; i++)
                                            {
                                                for (int j = 0; j < lhs_col; j++)
                                                {
                                                    output[i, j] = lhs_elements[i, j] + rhs_elements[i, j];
                                                    Console.Write(output[i, j]);
                                                    Console.Write("\t");
                                                }
                                                Console.Write("\n");
                                            }
                                            bool mat_set = final.setDoubleMatrix(output);
                                        }
                                        Object result = (Object)(final);
                                        mat_stack.Push(result);
                                    }
                                    // addition
                                }
                                else
                                {
                                    Console.Write("Matrix dimensions does not match.. try again.. \n");
                                }
                            }
                        }
                        else if (lhs_type == 2 && rhs_type == 2)
                        {
                            //Double
                            PerformDoubleAddition(obj_rhs, obj_lhs);

                        }
                        else if (lhs_type == 1 && rhs_type == 1)
                        {
                            //Int
                            PerformIntAddition(obj_rhs, obj_lhs);
                        }
                        else
                        {
                            Console.Write("Scalar and matrix addition not possible\n");
                            sendres(112, "Scalar and matrix addition not possible\n");
                        }
                    }
                    else
                    {
                        Console.Write("Matrix types are different.. try again.. ");
                        sendres(112, "Matrix types are different.. try again.. ");
                    }
                }
            }
        }

        private void PerformIntAddition(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                IntegerElement stk_rhs = (IntegerElement)(obj_rhs);
                IntegerElement stk_lhs = (IntegerElement)(obj_lhs);
                IntegerElement final = new IntegerElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    int temp_lhs = int.Parse(stk_lhs.getText());
                    int temp_rhs = int.Parse(stk_rhs.getText());
                    final.setText((temp_lhs + temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Sum: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };
        }

        private void PerformDoubleAddition(Object obj_rhs, Object obj_lhs)
        {
            try
            {
                DoubleElement stk_rhs = (DoubleElement)(obj_rhs);
                DoubleElement stk_lhs = (DoubleElement)(obj_lhs);
                DoubleElement final = new DoubleElement();
                if (stk_lhs != null && stk_rhs != null)
                {
                    double temp_lhs = double.Parse(stk_lhs.getText());
                    double temp_rhs = double.Parse(stk_rhs.getText());
                    final.setText((temp_lhs + temp_rhs).ToString());
                    Object result = (Object)(final);
                    mat_stack.Push(result);
                    Console.Write("Sum: " + final.getText());
                }
            }
            catch (Exception e) { sendres(112, "Unassigned variables\n"); e.GetType(); };
        }

        public override void VisitPrintOperationElement(PrintOperationElement element)
        {
            Console.Write("Printing..\n");
            VisitElement(element.getChildElement());
            try
            {
                if (element.getChildElement() is VariableElement)
                    PrintVariable(element.getChildElement());
                else if (element.getChildElement() is IntegerElement)
                {
                    result(((IntegerElement)element.getChildElement()).getText() + "\n");
                    finalResult.Append(((IntegerElement)element.getChildElement()).getText() + "\n");
                }
                else if (element.getChildElement() is DoubleElement)
                {
                    result(((DoubleElement)element.getChildElement()).getText() + "\n");
                    finalResult.Append(((DoubleElement)element.getChildElement()).getText() + "\n");
                }
                else if (element.getChildElement() is StringElement)
                {
                    result(((StringElement)element.getChildElement()).getText() + "\n");
                    finalResult.Append(((StringElement)element.getChildElement()).getText() + "\n");
                }
                else if (element.getChildElement() is VectorVariableDeclaration)
                    PrintVector(element.getChildElement());

            }
            catch (Exception e) { sendres(112, "Invalid variable\n"); e.GetType(); }
        }


        private void PrintVariable(Element elem)
        {
            
            if (map_contains_matrix(((VariableElement)elem).getText()))
            {
            
                if (mat_stack.Count > 0)
                {
                    try
                    {
                        string s = ((VariableElement)elem).getText();
                        Object obj = getTopOfStack_Matrix();
                        int a = GetTypeOfElement((Element)obj);
                        if (a == 1)
                        {
                            result(s + ":" + ((IntegerElement)obj).getText() + "\n");
                            finalResult.Append(s + ":" + ((IntegerElement)obj).getText() + "\n");
                        }
                        else if (a == 2)
                        {
                            result(s + ":" + ((DoubleElement)obj).getText() + "\n");
                            finalResult.Append(s + ":" + ((DoubleElement)obj).getText() + "\n");
                        }
                        else if (a == 3)
                        {
                            PrintMatrix(obj);
                        }
                        else if (a == 16)
                            PrintVector(obj);
                        else if (a == (int)datatypes.Struct)
                        {
                            PrintStruct(obj);
                        }
                        else if (a == 7)
                        {
                            result(s + ":" + ((StringElement)obj).getText() + "\n");
                            finalResult.Append(s + ":" + ((StringElement)obj).getText() + "\n");
                        }

                    }
                    catch (Exception e) { sendres(112, "Variable not assigned\n"); e.GetType(); }
                }
            }

            else sendres(112, "Variable not declared\n");

        }
        private void PrintStruct(Object obj)
        {
            try
            {
                result("Struct name:" + ((StructDeclaration)obj).getName().getText() + "\n");
                List<ScalarVariableDeclaration> ls = new List<ScalarVariableDeclaration>();
                if (mVariableMap.ContainsKey(((StructDeclaration)obj).getName().getText()))
                {
                    StructDeclaration s1 = (StructDeclaration)mVariableMap[((StructDeclaration)obj).getName().getText()];
                    if (s1 != null)
                    {
                        ls = s1.getVarType();
                        for (int i = 0; i < ls.Count; i++)
                            result("Members:" + ls[i].getVar().getText() + " ");
                        result("\n");
                    }
                }
            }
            catch (Exception e)
            {
                sendres(112, "Structure not found\n");
                e.GetType();
            }
        }

        private void PrintVector(Object obj)
        {
            VectorVariableDeclaration elem = (VectorVariableDeclaration)(obj);
            string type = elem.getType();
            int index = int.Parse(elem.getRange().getText());

            //result("\nVector : " + elem.getText().getText() + "\n");
            string mat_type = elem.getType();
            if (mat_type == "int")
            {
                List<int> elements = elem.getintValue();
                if (elements != null)
                {
                    result("Vector Elements are : \n");
                    finalResult.Append("Vector Elements are : \n");
                    for (int i = 0; i < index; i++)
                    {
                        result(elements[i].ToString() + "  ");
                        finalResult.Append(elements[i].ToString() + "  ");
                    }


                }
            }
            else if (mat_type == "double")
            {
                List<double> elemenets = elem.getdoubleValue();
                if (elemenets != null)
                {
                    result("\nVector Elements are : \n");
                    finalResult.Append("\nVector Elements are : \n");
                    for (int i = 0; i < index; i++)
                    {
                        result(elemenets[i].ToString() + "  ");
                        finalResult.Append(elemenets[i].ToString() + "  ");
                    }
                }
            }
            Console.Write("\n");
            result("\n");
            finalResult.Append("\n");

        }




        private void PrintMatrix(Object obj)
        {
            MatrixVariableDeclaration elem = (MatrixVariableDeclaration)(obj);
            string type = elem.getType();
            int row = int.Parse(elem.getRow().getText());
            int col = int.Parse(elem.getColumn().getText());
            Console.Write("\nMatrix Type : ");
            Console.Write(type); Console.Write("\n");
            Console.Write(" Rows : "); Console.Write(row); Console.Write("\n");
            Console.Write(" Columns : "); Console.Write(col);
            result("\nMatrix Type : " + type + "\n" + "Rows:" + row.ToString() + "\n" + "Columns:" + col.ToString());
            finalResult.Append("\nMatrix Type : " + type + "\n" + "Rows:" + row.ToString() + "\n" + "Columns:" + col.ToString());
            string mat_type = elem.getType();
            if (mat_type == "int")
            {
                int[,] elements = elem.getintValue();
                if (elements != null)
                {
                    result("\nMatrix Elements are : \n");
                    finalResult.Append("\nMatrix Elements are : \n");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            result(elements[i, j].ToString() + "\t");
                            finalResult.Append(elements[i, j].ToString() + "\t");
                        }
                        Console.Write("\n");
                        result("\n");
                        finalResult.Append("\n");
                    }
                }
            }
            else if (mat_type == "double")
            {
                double[,] elemenets = elem.getdoubleValue();
                if (elemenets != null)
                {
                    result("\nMatrix Elements are : \n");
                    finalResult.Append("\nMatrix Elements are : \n");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            Console.Write(elemenets[i, j]);
                            result(elemenets[i, j].ToString());
                            finalResult.Append(elemenets[i, j].ToString());
                            Console.Write("\t");
                            result("\t");
                            finalResult.Append("\t");
                        }
                        Console.Write("\n");
                        result("\n");
                        finalResult.Append("\n");
                    }
                }
            }
            
        }

        public String getIfElement(Element element)
        {
            if (element is IntegerElement)
            {
                IntegerElement int_elem = (IntegerElement)element;
                return int_elem.getText();
            }
            else if (element is VariableElement)
            {
                VariableElement var_elem = (VariableElement)element;
                if (mVariableMap.ContainsKey(var_elem.getText()) == true)
                {
                    Object obj = mVariableMap[var_elem.getText()];
                    String str = getIfElement((Element)obj);
                    return str;
                }
            }
            else if (element is DoubleElement)
            {
                DoubleElement double_elem = (DoubleElement)element;
                return double_elem.getText();
            }
            else if (element is StringElement)
            {
                StringElement string_elem = (StringElement)element;
                return string_elem.getText();
            }
            else if (element is StructAssignDeclaration)
            {
                /* The following commemted will work when the front end team will provide structure hash map
                 * and related APIs.
                 * sendres(112, "Structure hash map not found.\n");                   
                          return null;  // for time being
                  StructAssignDeclaration struct_elem = (StructAssignDeclaration)element;
                  StructDeclaration structTemp=null;
       
                  if (mVariableMap.ContainsKey(((VariableElement)(struct_elem.getObjName())).getText())) //getName()))
                  {
                      structTemp = (StructDeclaration)mVariableMap[((VariableElement)(struct_elem.getObjName())).getText()]; //.getName()];
                     // String str = getIfElement((Element)obj); 
                      for (x = 0; x < structTemp.getVarType().Count; x++)
                      {
                          VariableElement s = ((VariableElement)(struct_elem.getDataMember())).getText();
                          // search s in structure's hash table
                          // return (s.getText());                        
                      }
                  }
                  else
                      sendres(112, "Structure " + ((VariableElement)(struct_elem.getObjName())).getText() + " not found\n");                   
                 */
                sendres(112, "Program Error: Structure hash map not found.\n");
                return null;  // for time being
            }

            //Console.WriteLine("\n Invalid if expression!");
            sendres(112, "\n Invalid if expression!");
            return null;

        }


        private void createIf(IfStatementElement element)
        {
            string strlhs = "";
            string strrhs = "";
            if (element.getLhs() is VariableElement)
                strlhs = ((VariableElement)element.getLhs()).getText();
            //struct
            parallelString.Append("if(" + strlhs);
            if (element.OP == "eq")
                parallelString.Append("==");
            else if (element.OP == "ne")
                parallelString.Append("!=");
            else if (element.OP == "lt")
                parallelString.Append("<");
            else if (element.OP == "le")
                parallelString.Append("<=");
            else if (element.OP == "gt")
                parallelString.Append(">");
            else if (element.OP == "ge")
                parallelString.Append(">=");

            if (element.getRhs() is VariableElement)
                strrhs = ((VariableElement)element.getRhs()).getText();
            else if (element.getRhs() is IntegerElement)
                strrhs = ((IntegerElement)element.getRhs()).getText();
            else if (element.getRhs() is DoubleElement)
                strrhs = ((DoubleElement)element.getRhs()).getText();
            else if (element.getRhs() is StringElement)
                strrhs = ((StringElement)element.getRhs()).getText();
            parallelString.Append(strrhs + ")" + "\n" + "{\n");
            for (int i = 0; element.IFCODE.Count != 0 && i < element.IFCODE.Count; i++)
            {
                VisitElement(element.IFCODE[i]);
                if (element.IFCODE[i] is AssignmentOperationElement)
                    parallelString.Append(";");
                
            }
            parallelString.Append("\n}");
        }

        private void createElse(IfStatementElement element)
        {

            //struct
            parallelString.Append("else");
            parallelString.Append("{\n");
            for (int i = 0; element.ELSECODE.Count != 0 && i < element.ELSECODE.Count; i++)
            {
                VisitElement(element.ELSECODE[i]);
                if (element.ELSECODE[i] is AssignmentOperationElement)
                    parallelString.Append(";");
                
            }
            parallelString.Append("\n}");
        }


        public override void VisitIfStatementElement(IfStatementElement element)
        {
            if (inParallelFor == 1)
            {
                createIf(element);
                createElse(element);
            }
            else
            {
                local++;
                Hashtable localTable = new Hashtable();
                scope.Push(localTable);

                String lhs = getIfElement(element.getLhs());
                String rhs = getIfElement(element.getRhs());
                Console.WriteLine("\n lhs = " + lhs + " rhs = " + rhs);

                if (lhs == null || rhs == null)
                { Console.WriteLine("\n Variable not allowed. "); return; }

                if (
                     (element.OP == "eq" && String.Compare(lhs, rhs) == 0) ||
                     (element.OP == "ne" && String.Compare(lhs, rhs) != 0) ||
                     (element.OP == "lt" && String.Compare(lhs, rhs) < 0) ||
                     (element.OP == "le" && String.Compare(lhs, rhs) <= 0) ||
                     (element.OP == "gt" && String.Compare(lhs, rhs) > 0) ||
                     (element.OP == "ge" && String.Compare(lhs, rhs) >= 0)
                   )
                {
                    Console.WriteLine("\n Loop condition true - entered true. ");
                    //sendres(120, "Loop condition true - entered true.\n");

                    for (int i = 0; i < element.IFCODE.Count; i++)
                    {
                        Element curr = element.IFCODE[i];
                        curr.Accept(this);
                    }

                    scope.Pop();
                    local--;

                }
                else
                {
                    local++;
                    Hashtable localTableElse = new Hashtable();
                    scope.Push(localTableElse);

                    //VisitElseStatementElement(element);
                    if (element.ELSECODE.Count != 0)
                    {
                        Console.WriteLine("\n Loop condition false - entered else. ");
                        //sendres(121, "Loop condition false - entered false.\n");

                        for (int i = 0; i < element.ELSECODE.Count; i++)
                        {
                            Element curr = element.ELSECODE[i];
                            curr.Accept(this);
                        }
                    }

                    scope.Pop();
                    local--;
                }

            }

        }
    }
}