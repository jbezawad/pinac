//////////////////////////////////////////////////////////////////////////////////
//  SwarmMemoryCaller.cs - Memory call functions                                //
//                                                                              //
//  Language:      C#                                                           //
//  Author:        Mehmet KAYA (mkaya@syr.edu)                                  //
//                 (315) 480-9763                                               //
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Collections;

namespace Spinach
{
    public class SwarmMemoryCaller
    {
       
        public string[] MasterBackUpChanger(string MasterBackUpXml)
        {
            XDocument doc = XDocument.Parse(MasterBackUpXml);
            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("Master") select x;
            string Master = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("BackUp") select x;
            string BackUp = q.ElementAt(0).Value.ToString();
            string[] temp = {Pid,Master,BackUp};
            return temp;
        }
        public string[] PortionResultReceive(string PortionResultXML)
        {           
            //xml += "<Pid>" + Pid + "<Pid>";
            //xml += "<Index>" + index + "</Index>";
            //xml += "<Result>" + result + "</Result>";
            //xml = "</PrallelResult>";
            XDocument doc = XDocument.Parse(PortionResultXML);
            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("Index") select x;
            string index = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("Result") select x;
            string result = q.ElementAt(0).ToString();
            string[] temp = {Pid,index,result};
            return temp;
        }
        public string[] PortionReceive(string PortionXML)
        {
            //xml += "<Pid>" + Pid + "<Pid>";
            //xml += "<Index>" + index + "</Index>";
            //xml += "<Sender>" + mSocket.GetIP() + ":" + mSocket.GetPort() + "</Sender>";
            //xml += "<Data>" + ParallelForData + "</Data>";
            //xml += "<Body>" + ParallelForBody + "</Body>";
            XDocument doc = XDocument.Parse(PortionXML);
            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("Index") select x;
            string index = q.ElementAt(0).Value.ToString();            
            q = from x in doc.Elements().Descendants("Data") select x;
            string data = q.ElementAt(0).ToString();            
            q = from x in doc.Elements().Descendants("Body") select x;
            string body = q.ElementAt(0).Value.ToString();
            body = body.Replace('%', '<');
            body = body.Replace('@', '>');
            q = from x in doc.Elements().Descendants("Range") select x;
            string range = q.ElementAt(0).Value.ToString();
            string[] temp = {Pid,index,data,body,range};
            return temp;

        }
        //public void StackInfo(string _stack)
        //{
        //    //// SwarmMemory sm = function(Pid);
        //    //SwarmMemory sm = new SwarmMemory("d","");
        //    //sm.receiveStack(_stack);
        //}
 //       public void InitializeThePeer(SwarmMemory sm, string changes)
 //       {
 //           XDocument doc = XDocument.Parse(changes);
 //           var q = from x in doc.Elements().Descendants("Pid") select x;
 //           string Pid = q.ElementAt(0).Value.ToString();

 //           q = from x in doc.Elements().Descendants("Owner") select x;
 //           string owner = q.ElementAt(0).Value.ToString();

 //           q = from x in doc.Elements().Descendants("Stack").Descendants("Value") select x;
 //           Stack<string> newProgramStack = new Stack<string>();

 //           foreach (var item in q)
 //           {
 //               newProgramStack.Push(item.Value.ToString());
 //           }
 //           newProgramStack.Reverse();
 //           sm.setProgramStack(newProgramStack);
 //           ////////////////////////////////////////////////////////
 //           q = from x in doc.Elements().Descendants("PartialResults").Descendants("Result").Descendants("IPPort") select x;
 //           List<string> ResultIPorts = new List<string>();
 //           foreach (var item in q)
 //           {
 //               ResultIPorts.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("PartialResults").Descendants("Result").Descendants("ResultValue") select x;
 //           List<string> ResultVal = new List<string>();
 //           foreach (var item in q)
 //           {
 //               ResultVal.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("PartialResults").Descendants("Result").Descendants("Done") select x;
 //           List<string> _done = new List<string>();
 //           foreach (var item in q)
 //           {
 //               _done.Add(item.Value.ToString());
 //           }
 //           Hashtable newPartialResults = new Hashtable();
 //           for (int i = 0; i < ResultIPorts.Count; i++)
 //           {
 //               string[] temp = { ResultVal[i].ToString(), _done[i].ToString() };
 //               newPartialResults.Add(ResultIPorts[i].ToString(), temp);
 //           }
 //           sm.setpartialResults(newPartialResults);
 //           /////////////////////////////
 //           q = from x in doc.Elements().Descendants("Permissions").Descendants("Permit").Descendants("IPPort") select x;
 //           List<string> IPorts = new List<string>();
 //           foreach (var item in q)
 //           {
 //               IPorts.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("Permissions").Descendants("Permit").Descendants("Read") select x;
 //           List<string> reads = new List<string>();
 //           foreach (var item in q)
 //           {
 //               reads.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("Permissions").Descendants("Permit").Descendants("Write") select x;
 //           List<string> writes = new List<string>();
 //           foreach (var item in q)
 //           {
 //               writes.Add(item.Value.ToString());
 //           }

 //           Hashtable newPermissions = new Hashtable();
 //           for (int i = 0; i < IPorts.Count; i++)
 //           {
 //               string[] temp = { reads[i].ToString(), writes[i].ToString() };
 //               newPermissions.Add(IPorts[i].ToString(), temp);
 //           }
 //           sm.setPermissions(newPermissions);
 //           //////////////////////////////
 //           q = from x in doc.Elements().Descendants("ProgramVariables").Descendants("Variable").Descendants("Name") select x;
 //           List<string> varnames = new List<string>();
 //           foreach (var item in q)
 //           {
 //               varnames.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("ProgramVariables").Descendants("Variable").Descendants("Value") select x;
 //           List<string> varvalues = new List<string>();
 //           foreach (var item in q)
 //           {
 //               varvalues.Add(item.Value.ToString());
 //           }
 //           Hashtable newProgramVariables = new Hashtable();
 //           for (int i = 0; i < varnames.Count; i++)
 //           {
 //               newProgramVariables.Add(varnames[i].ToString(), varvalues[i].ToString());
 //           }
 //           sm.setProgramVariables(newProgramVariables);
 //           ///////////////////////////////////////////
 //           q = from x in doc.Elements().Descendants("Replies").Descendants("Reply").Descendants("IPPort") select x;
 //           List<string> ports = new List<string>();
 //           foreach (var item in q)
 //           {
 //               ports.Add(item.Value.ToString());
 //           }
 //           q = from x in doc.Elements().Descendants("Replies").Descendants("Reply").Descendants("ReplyValue") select x;
 //           List<string> repVal = new List<string>();
 //           foreach (var item in q)
 //           {
 //               repVal.Add(item.Value.ToString());
 //           }
 //           Hashtable newReplies = new Hashtable();
 //           for (int i = 0; i < ports.Count; i++)
 //           {
 //               newReplies.Add(ports[i].ToString(), repVal[i].ToString());
 //           }
 //           sm.setReply(newReplies);
 //           ///////////////////////////////
 //           /*
 ////////////////////////////////////////////////////////
 ////this part belongs to TEST2
 //string TestID = Pid;
 //Stack<string> TestStack = sm.getStack();
 //Hashtable TestPartialResults = sm.getPartialResults();
 //Hashtable TestPermissions = sm.getPermissions();
 //Hashtable TestVariables = sm.getProgramVariables();
 //Hashtable TestReplies = sm.getReplies();
 //string TestOwner = sm.getOwner();
 //Console.WriteLine("========STACK=======");
 //foreach (string item in TestStack)
 //{
 //    Console.WriteLine(item.ToString());
 //}
 //Console.WriteLine("========PartialResults=======");
 //foreach (DictionaryEntry item in TestPartialResults)
 //{
 //    string[] temp = (string[])item.Value;
 //    Console.WriteLine("IP={0}  Value={1}  Done={2}", item.Key.ToString(), temp[0].ToString(), temp[1].ToString());
 //}
 //Console.WriteLine("========Permissions=======");
 //foreach (DictionaryEntry item in TestPermissions)
 //{
 //    string[] temp = (string[])item.Value;
 //    Console.WriteLine("IP={0}  read={1}  write={2}", item.Key.ToString(), temp[0].ToString(), temp[1].ToString());
 //}
 //Console.WriteLine("========Variables=======");
 //foreach (DictionaryEntry item in TestVariables)
 //{
 //    Console.WriteLine("name={0}  value={1}",item.Key.ToString(),item.Value.ToString());
 //}
 //Console.WriteLine("========Replies=======");
 //foreach (DictionaryEntry item in TestReplies)
 //{
 //    Console.WriteLine("IP={0}  Reply={1}", item.Key.ToString(), item.Value.ToString());
 //}
 //Console.WriteLine("========Owner=======");
 //Console.WriteLine("Owner={0}",TestOwner);
 // * */
 //       }
        public string[] changeOwner(string changes)
        {
            XDocument doc = XDocument.Parse(changes);

            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();

            q = from x in doc.Elements().Descendants("IPPort") select x;
            string IPPort = q.ElementAt(0).Value.ToString();
            string theIP = IPPort.Substring(0, IPPort.IndexOf(':'));
            string thePort = IPPort.Substring(IPPort.IndexOf(':') + 1);

            string[] temp = { Pid,theIP,thePort };
            return temp;
            //call UI function to setOwner
        }
        public string[] changePermission(string changes)
        {
            XDocument doc = XDocument.Parse(changes);

            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();


            q = from x in doc.Elements().Descendants("IPPort") select x;
            string IPPort = q.ElementAt(0).Value.ToString();
            string theIP = IPPort.Substring(0, IPPort.IndexOf(':'));
            string thePort = IPPort.Substring(IPPort.IndexOf(':') + 1);

            q = from x in doc.Elements().Descendants("Read") select x;
            string read = q.ElementAt(0).Value.ToString();

            q = from x in doc.Elements().Descendants("Write") select x;
            string write = q.ElementAt(0).Value.ToString();

            string[] temp={Pid, theIP, thePort, read, write};
            return temp;

            //Console.WriteLine("Pid={0}  IPPort={1}  read={2}  write={3}",Pid,IPPort,read,write);
            //sm.changer(IPPort, read, write);
        }
        public string[] addPermission(string changes)
        {
            XDocument doc = XDocument.Parse(changes);
            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();

            q = from x in doc.Elements().Descendants("Owner") select x;
            string owner = q.ElementAt(0).Value.ToString();

            q = from x in doc.Elements().Descendants("Code") select x;
            string code = q.ElementAt(0).Value.ToString();
            code = code.Replace('%', '<');
            code = code.Replace('@', '>');

            q = from x in doc.Elements().Descendants("IPPort") select x;
            string IPPort = q.ElementAt(0).Value.ToString();

            string theIP = IPPort.Substring(0, IPPort.IndexOf(':'));
            string thePort = IPPort.Substring(IPPort.IndexOf(':') + 1);

            q = from x in doc.Elements().Descendants("Read") select x;
            string read = q.ElementAt(0).Value.ToString();

            q = from x in doc.Elements().Descendants("Write") select x;
            string write = q.ElementAt(0).Value.ToString();
            string[] temp = { Pid,owner,code,theIP,thePort,read,write, changes};
            return temp;
            //UItemas function function(Pid, changes, code, theIP, thePort, read, write);

            /////////////test3/////////////

            //Console.WriteLine(IPPort);
            //Console.WriteLine(read);
            //Console.WriteLine(write);
            //Console.WriteLine(code);

            ///////////////////////////////
        }
        public string[] CodeChanged(string changes)
        {
            //"<SourceChange>" + "<Pid>" + Pid.ToString() + "</Pid>" + "<lno>" + lno.ToString() + "</lno>" + "<s>" + s.ToString() + "</s>" + "<mod>" + mod + "</mod>" + "<uname>"+uname+"</uname>"+"</SorurceChange>";
            XDocument doc = XDocument.Parse(changes);
            var q = from x in doc.Elements().Descendants("Pid") select x;
            string Pid = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("lno") select x;
            string lno = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("s") select x;
            string s = q.ElementAt(0).Value.ToString();
            s = s.Replace('%', '<');
            s = s.Replace('@', '>');
            q = from x in doc.Elements().Descendants("mod") select x;
            string mod = q.ElementAt(0).Value.ToString();
            q = from x in doc.Elements().Descendants("uname") select x;
            string uname = q.ElementAt(0).Value.ToString();
            string[] temp = { Pid, lno, s, mod, uname };
            return temp;
        }
        //if this is master machine
        //public void finalSourceCodeChanger(string changes)
        //{
        //    XDocument doc = XDocument.Parse(changes);
        //    var q = from x in doc.Elements().Descendants("Pid") select x;
        //    string Pid = q.ElementAt(0).Value.ToString();
        //    //SwarmMemory sm = new SwarmMemory("dsf","");// SwarmMemory sm = function(Pid);
        //    //sm.finalCodeChange(changes);
        //}
        //public void masterSourceCodeChage(string changes)
        //{
        //    XDocument doc = XDocument.Parse(changes);
        //    var q = from x in doc.Elements().Descendants("Pid") select x;
        //    string Pid = q.ElementAt(0).Value.ToString();
        //    //SwarmMemory sm = new SwarmMemory("dsf","");// SwarmMemory sm = function(Pid);
        //    //sm.masterCodeChanger(changes);

        //}
    }
}
