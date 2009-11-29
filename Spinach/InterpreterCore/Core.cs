////////////////////////////////////////////////////////////////////////
// Core.cs: Executive for core processing of the SPINACH code.
// 
// version: 1.0
// Description: part of the interpreter example for the visitor design
//  pattern.
// Language:    C++/CLI, Visual Studio 2008 .Net Framework 3.5             
// Platform:    Dell Inspiron 1525, Windows Vista Business, SP 1       
// Application: Pr#2, CSE 784, Spring 2009                              
// Authors:     Rajika Tandon (ratandon@syr.edu)
//              Sushma Thimmappa (skyasara@syr.edu)
//              Rucha Bapat (rmbapat@syr.edu)            
// Source:      Phil Pratt-Szeliga (pcpratts@syr.edu)
////////////////////////////////////////////////////////////////////////
/*
 * Module Operations
 * ================= 
 * This file provides APIs to be used by other teams for communicating with 
 * the core. It provides a setAST() function which receives the Abstract Syntax 
 * Tree. Using this tree, we execute the entire code and perform semantic analysis
 * as well.
 * 
 * We also send the code execution results and errors to the User Interface using 
 * sendres() and result().
 * 
 * Public Interface
 * ================
 * Core core = new Core();  
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
 * ver 1.0 : 10 Nov 09
 *   - first release
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace Spinach
{
    public class Core 
    {
        InterpreterVisitor interp_visitor;
        
       // PrintVisitor print_visitor=new PrintVisitor(this);
        public delegate void errorcoremsg(int code, string errormsg);
        public event errorcoremsg errorcore_;

        public delegate void resultcore(string coremsg);
        public event resultcore rescore_;

        public delegate void executeParallel(string body, string data, int start, int stop);
        public event executeParallel parallelcore_;

        public delegate void getResults(List<string> results);
        public event getResults parallelresult_;

        private int flag = -1;
        private int totalLines = 0;
        private int Visited = 0;
        SwarmMemory smem;
 
        public void sendres(int code, string errormsg)
        {
            if (errorcore_ != null)
            {
                if (flag == -1)
                {
                    errorcore_(code, errormsg);
                    flag = 1;
                }
                
            }

        }

        public void getParallelResult(List<string> results)
        {
            if (parallelresult_ != null)
                parallelresult_(results);
        }
        public void execParallel(string body, string data, int start, int stop)
        {
            if (parallelcore_ != null)
               parallelcore_(body,data,start,stop);
        }

        public void result(string coremsg)
        {
            if (rescore_ != null)
                rescore_(coremsg);
        }

                
        public void setSwarmObject(SwarmMemory sm)
        {
            smem = sm;
            interp_visitor.setSwarmObject(sm);
        }
        public void setSwarm()
        {
            interp_visitor.setSwarm();
        }

        public void setFrontEnd(exec FrontEnd)
        {
            interp_visitor.setFE(FrontEnd);
        }
        //List<Element> elements;
        public Core()
        {
             interp_visitor=new InterpreterVisitor();
             interp_visitor.errorcore_ += new InterpreterVisitor.errorcoremsg(sendres);
             interp_visitor.rescore_ += new InterpreterVisitor.resultcore(result);
             
             
             //interp_visitor.setFE(FE);
        }

        public void setPlotObject(PlotReceiver plotObj)
        {
            interp_visitor.setPlotObj(plotObj);
        }
        public void setAST(List<Element> elements)
        {
            //  element = ele;
            if (elements != null)
            {
                if (Visited != 1)
                {
                    totalLines = elements.Count;
                    Visited = 1;
                }
                for (int i = 0; i < elements.Count && flag != 1; i++)
                {
                    Element curr = elements[i];
                    // curr.Accept(print_visitor);
                    curr.Accept(interp_visitor);
                }
                if(totalLines ==elements.Count && Visited==1)
                   smem.clearMasterBackup(true);
            }
        }

        public void clearVarMap()
        {
            interp_visitor.clearMap();
            Visited = 0;
            flag = -1;

        }


        }

}
