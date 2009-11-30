//////////////////////////////////////////////////////////////////////////////////
//  MessageParser.cs - MessageParser module                                     //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Shaonan Wang (swang25@syr.edu)                               //
//                 Mehmet KAYA (mkaya@syr.edu)                                  //
//                 Mohammad Irfan Khan Tareen (mtareen@syr.edu)                 //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 31 Oct. 2009
 * - the initial version of the MessageParser module
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace Spinach
{
    public partial class AsynchronousSocketListener
    {
        //Delegates and Events
        public delegate void ChatEventHandler(string Uname, string ChatMsg);
        public event ChatEventHandler ChatChanged;

        public delegate void ErrorEventHandler(int ErrorCode,string ErrorMsg);
        public event ErrorEventHandler ErrorChanged;

        public delegate void PrivelageEventHandler(string[] strPrev);
        public event PrivelageEventHandler AddPrev;
        public event PrivelageEventHandler ChngPermission;
        public event PrivelageEventHandler TransOwner;


        private void parseMsg(String msg)
        {
            try
            {
                String type = " ";
                XDocument xml = XDocument.Parse(msg);
                var q1 = from x in xml.Elements() select x;
                if (q1.ElementAt(0).Name.ToString() == "root")
                {
                    var q = from x in xml.Descendants()
                            where (x.Name == "root")
                            select x;
                    foreach (var elem in q)
                        type = elem.Attributes().ElementAt(0).Value;

                    if (type == "Connection")
                        getConnectionRequestMsg(msg);
                    else if (type == "IPtoPeer")
                        getIPtoPeerMsg(msg);
                    else if (type == "HeartBeatRequest")
                        getHeartBeatRequestMsg(msg);
                    else if (type == "HeartBeatReply")
                        getHeartBeatReplyMsg(msg);
                    else if (type == "Master")
                        getMasterMsg(msg);
                    else if (type == "Backup")
                        getBackupMsg(msg);
                    else if (type == "Run")
                        getRunMsg(msg);
                    else if (type == "RunSuccess")
                        getRunSuccessMsg(msg);
                    else if (type == "RunFail")
                        getRunFailMsg(msg);
                    else if (type == "Chat")
                        getChatMsg(msg);
                    else if (type == "Error")
                        getErrorMsg(msg);
                    else if (type == "Disconnect")
                        getDisconnectMsg(msg);
                }
                else if (q1.ElementAt(0).Name.ToString() == "NewProg")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.addPermission(msg);
                    string myIp = GetIP();
                    string myPort = GetPort();
                    if (myIp == temp[3] && myPort == temp[4])
                    {
                        if (AddPrev != null)
                            AddPrev(temp);
                    }
                    else
                    {
                        //string[] temp = { Pid,owner,code,theIP,thePort,read,write, changes};
                        //string[] temp={Pid, theIP, thePort, read, write};
                        string[] temp1 = { temp[0], temp[3], temp[4], temp[5], temp[6] };
                        if (ChngPermission != null)
                            ChngPermission(temp1);
                    }
                }
                else if (q1.ElementAt(0).Name.ToString() == "PermissionChange")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.changePermission(msg);
                    if (ChngPermission != null)
                        ChngPermission(temp);
                }
                else if (q1.ElementAt(0).Name.ToString() == "ChangeOwner")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.changeOwner(msg);
                    if (TransOwner != null)
                        TransOwner(temp);
                }
                else if (q1.ElementAt(0).Name.ToString() == "Prallel")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.PortionReceive(msg);
                    SwarmMemory sm = GetProg(temp[0].ToString());
                    sm.acceptParallelfor(temp[2].ToString(), temp[3].ToString(), temp[1].ToString(), temp[4].ToString());
                }
                else if (q1.ElementAt(0).Name.ToString() == "PrallelResult")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.PortionResultReceive(msg);
                    SwarmMemory sm = GetProg(temp[0].ToString());
                    sm.incomingResult(temp[2].ToString(), temp[1].ToString());
                }
                else if (q1.ElementAt(0).Name.ToString() == "MasterBackUp")
                {
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.MasterBackUpChanger(msg);
                    SwarmMemory sm = GetProg(temp[0].ToString());
                    sm.setMaster(temp[1].ToString());
                    sm.setBackUp(temp[2].ToString());
                    sm.Lock();

                }
                else if (q1.ElementAt(0).Name.ToString() == "ComputationDone")
                {
                    XDocument doc = XDocument.Parse(msg);
                    var q = from x in doc.Elements().Descendants("Pid") select x;
                    string Pid = q.ElementAt(0).Value.ToString();
                    SwarmMemory sm = GetProg(Pid);
                    sm.setRunFlag(false);
                    sm.setStartFlag("");
                    sm.clearMasterBackup(false);
                }
                else if (q1.ElementAt(0).Name.ToString() == "ProgramClosed")
                {
                    XDocument doc = XDocument.Parse(msg);
                    var q = from x in doc.Elements().Descendants("Pid") select x;
                    string Pid = q.ElementAt(0).Value.ToString();
                    q = from x in doc.Elements().Descendants("IPPort") select x;
                    string IPPort = q.ElementAt(0).Value.ToString();
                    SwarmMemory sm = GetProg(Pid);
                    sm.removePermissionRec(IPPort);
                }
                else if (q1.ElementAt(0).Name.ToString() == "SourceChange")
                {
                    XDocument doc = XDocument.Parse(msg);
                    SwarmMemoryCaller smc = new SwarmMemoryCaller();
                    string[] temp = smc.CodeChanged(msg);
                    SwarmMemory sm = GetProg(temp[0].ToString());
                    sm.getSourceChanges(temp);
                }
                else if (q1.ElementAt(0).Name.ToString() == "FinalResult")
                {
                    XDocument doc = XDocument.Parse(msg);
                    var q = from x in doc.Elements().Descendants("Pid") select x;
                    string Pid = q.ElementAt(0).Value.ToString();
                    q = from x in doc.Elements().Descendants("Result") select x;
                    string Result = q.ElementAt(0).Value.ToString();
                    SwarmMemory sm = GetProg(Pid);
                    sm.getFinalResult(Result);
                }
                else if (q1.ElementAt(0).Name.ToString() == "ComError")
                {
                    XDocument doc = XDocument.Parse(msg);
                    var q = from x in doc.Elements().Descendants("Pid") select x;
                    string Pid = q.ElementAt(0).Value.ToString();
                    q = from x in doc.Elements().Descendants("ErrorNum") select x;
                    string ErrorNum = q.ElementAt(0).Value.ToString();
                    q = from x in doc.Elements().Descendants("ErrorDetail") select x;
                    string ErrorDetail = q.ElementAt(0).Value.ToString();
                    SwarmMemory sm = GetProg(Pid);
                    sm.GetError(ErrorNum, ErrorDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void getConnectionRequestMsg(String msg)
        {
            String ip;
            String port;
            String name;
            String cpu;
            Thread t1 = null;
            Thread t2 = null;
            Thread t3 = null;

            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Elements("root").Descendants()
                    select x;
            foreach (var elem in q)
            {

                ip = elem.Attributes().ElementAt(0).Value;
                port = elem.Attributes().ElementAt(1).Value;
                name = elem.Attributes().ElementAt(2).Value;
                cpu = elem.Attributes().ElementAt(3).Value;
                if (IPtoPeer.Count > 0)
                {
                    if (!NametoIP.Contains(name))
                    {
                        InsertPeer(ip, port, name, cpu);
                        if (IPtoPeer.Count == 2)
                            SetBackup(ip + ":" + port);

                        MessageGenerator temp = new MessageGenerator();
                        string mMsg = temp.msgIPtoPeer(IPtoPeer);
                        string master = temp.msgMaster(GetMaster());
                        string backup = temp.msgBackup(GetBackup());
                        AsynchronousClient client1 = new AsynchronousClient();
                        client1.SetMultiMsg(IPtoPeer, mMsg, mPeer.mIP + ":" + mPeer.mPort);
                        t1 = new Thread(new ThreadStart(client1.SendMultiClient));
                        t1.IsBackground = true;
                        t1.Start();
                        
                        AsynchronousClient client2 = new AsynchronousClient();
                        client2.SetSingleMsg(ip, port, master);
                        t2 = new Thread(new ThreadStart(client2.SendSingleClient));
                        t2.IsBackground = true;
                        t2.Start();
                        
                        AsynchronousClient client3 = new AsynchronousClient();
                        client3.SetSingleMsg(ip, port, backup);
                        t3 = new Thread(new ThreadStart(client3.SendSingleClient));
                        t3.IsBackground = true;
                        t3.Start();
                        
                    }
                    else
                    {
                        MessageGenerator temp = new MessageGenerator();
                        string error = temp.msgError("10:Username Already Exists");
                        AsynchronousClient client = new AsynchronousClient();
                        client.SetSingleMsg(ip, port, error);
                        t1 = new Thread(new ThreadStart(client.SendSingleClient));
                        t1.IsBackground = true;
                        t1.Start();
                        
                    }
                }
                else
                {
                    MessageGenerator temp = new MessageGenerator();
                    string error = temp.msgError("10:Peer is not a part of Swarm");
                    AsynchronousClient client = new AsynchronousClient();
                    client.SetSingleMsg(ip, port, error);
                    t1 = new Thread(new ThreadStart(client.SendSingleClient));
                    t1.IsBackground = true;
                    t1.Start();
                    
                }
            }
            showTable();
        }
        private void getIPtoPeerMsg(String msg)
        {
            String ip;
            String port;
            String name;
            String cpu;

            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Elements("root").Descendants()
                    select x;
            foreach (var elem in q)
            {
                ip = elem.Attributes().ElementAt(0).Value;
                port = elem.Attributes().ElementAt(1).Value;
                name = elem.Attributes().ElementAt(2).Value;
                cpu = elem.Attributes().ElementAt(3).Value;
                InsertPeer(ip, port, name, cpu);
            }
            showTable();
        }

        private void getHeartBeatRequestMsg(String msg)
        {
            Thread t;
            string ipport = GetIP() + ":" + GetPort();
            string target = " ";
            string reply = " ";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                target = elem.Value;
            MessageGenerator temp = new MessageGenerator();
            reply = temp.msgHeartBeatReply(ipport);
            AsynchronousClient client = new AsynchronousClient();
            string[] str = target.Split(':');
            string ip = str[0];
            string port = str[1];
            client.SetSingleMsg(ip, port, reply);
            t = new Thread(new ThreadStart(client.SendSingleClient));
            t.IsBackground = true;
            t.Start();
            
        }

        private void getHeartBeatReplyMsg(String msg) 
        {
            string target="";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                target = elem.Value;
            Console.WriteLine(target);
            string receivetime = DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString();
            InsertReceiveTime(target, receivetime);
            string sendtime;
            int delay;
            Heartbeat temp = (Heartbeat)IPtoHeartbeat[target];
            sendtime = temp.SendTime;
            delay = GetTimeDifference(sendtime, receivetime);
            InsertDelay(target, delay.ToString());
            showHeartBeat(target);
        }

        private void getMasterMsg(String msg)
        {
            string master = " ";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                master = elem.Value;
            SetMaster(master);
            showTable();
        }

        private void getBackupMsg(String msg)
        {
            string backup = " ";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                backup = elem.Value;
            SetBackup(backup);
            showTable();
        }

        public void getRunMsg(String msg)
        {
            MessageGenerator temp = new MessageGenerator();
            string pid = " ";
            string ipport="";
            string reply = "";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Elements() select x;
            //var q = from x in xml.Elements().Descendants("root") select x;
            pid = q.ElementAt(0).Attributes().ElementAt(1).Value;
            ipport = q.ElementAt(0).Attributes().ElementAt(2).Value;
            SwarmMemory sm = GetProg(pid.ToString());
            if (sm.getRunFlag() == false)
            {
                sm.setRunFlag(true);
                reply = temp.msgRunSucessReply(pid);
            }
            else
            {
                reply = temp.msgRunFailReply(pid);
            }
            if(ipport!="")
            {
                string[] target = ipport.Split(':');
                string ip = target[0];
                string port = target[1];
                AsynchronousClient client = new AsynchronousClient();
                client.SetSingleMsg(ip, port, reply);
                Thread t;
                t = new Thread(new ThreadStart(client.SendSingleClient));
                t.IsBackground = true;
                t.Start();
            }

        }

        public void getRunFailMsg(String msg)
        {
            string pid = " ";
            XDocument xml = XDocument.Parse(msg);
            //var q = from x in xml.Elements().Descendants("root") select x;
            var q = from x in xml.Elements() select x;
            pid = q.ElementAt(0).Attributes().ElementAt(1).Value;
            SwarmMemory sm = GetProg(pid.ToString());
            sm.setStartFlag("Fail");
        }

        public void getRunSuccessMsg(String msg)
        {
            string pid = " ";
            XDocument xml = XDocument.Parse(msg);
            //var q = from x in xml.Elements().Descendants("root") select x;
            var q = from x in xml.Elements() select x;
            pid = q.ElementAt(0).Attributes().ElementAt(1).Value;
            SwarmMemory sm = GetProg(pid.ToString());
            sm.setStartFlag("Success");
        }

        private void getChatMsg(String msg) 
        {
            string chat = "";
            string ip = "";
            XDocument xml = XDocument.Parse(msg);
            //var q = from x in xml.Descendants()
            //        where (x.Name == "root")
            //        select x;
            //foreach (var elem in q)
            //    chat = elem.Value;
            var q = from x in xml.Elements("root").Descendants()
                    select x;
            foreach (var elem in q)
            {

                ip = elem.Attributes().ElementAt(0).Value;
                chat = elem.Attributes().ElementAt(1).Value;
            }
            string name = "";
            Peer temp = new Peer();
            temp = (Peer)GetIPtoPeer()[ip];
            name = temp.mName;
            Console.WriteLine("{0}:{1}",name,chat);
            ////////////////////////////////////////////////
            if (ChatChanged != null)
                ChatChanged(name,chat);

            //
        }

        private void getErrorMsg(String msg)
        {
            string error = " ";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                error = elem.Value;
            string[] sr = error.Split(':');
            int errorCode = Convert.ToInt32(sr[0]);
            string errorMsg = sr[1];
           // Console.WriteLine(error);
            ////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!////////////////
            if (ErrorChanged != null)
                ErrorChanged(errorCode,errorMsg);


            /////////
        }

        private void getDisconnectMsg(String msg)
        {
            string ipport = " ";
            XDocument xml = XDocument.Parse(msg);
            var q = from x in xml.Descendants()
                    where (x.Name == "root")
                    select x;
            foreach (var elem in q)
                ipport = elem.Value;
            setMasterBackup(ipport);
            showTable();
        }
        private void showHeartBeat(String ipport)
        {
            if(IPtoHeartbeat.Contains(ipport))
            {
                Heartbeat temp=(Heartbeat)IPtoHeartbeat[ipport];
                Console.WriteLine("sendtime: {0}----receivetime: {1}", temp.SendTime, temp.ReceiveTime);
                int Diff = GetTimeDifference(temp.SendTime, temp.ReceiveTime);
                Console.WriteLine("Delay:{0}", Diff);
            }
        }

        private int GetTimeDifference(string SendTime, string RecevTime)
        {
            string[] sendTArr = SendTime.Split('P', 'M', 'A', ':', ' ');
            string strSendTimeMillisecond = sendTArr[sendTArr.Length - 1];
            int sentMs = Convert.ToInt32(strSendTimeMillisecond);

            string[] recevTArr = RecevTime.Split('P', 'M', 'A', ':', ' ');
            string strRecevTimeMillisecond = recevTArr[sendTArr.Length - 1];
            int receMs = Convert.ToInt32(strRecevTimeMillisecond);

            int diffInMs = receMs - sentMs;
            if (diffInMs < 0)
            {
                string strSendSeconds = sendTArr[sendTArr.Length - 2];
                string strRecevSeconds = sendTArr[sendTArr.Length - 2];
                int sendSec = Convert.ToInt32(strSendSeconds);
                int receSec = Convert.ToInt32(strRecevSeconds);
                int diffSec = receSec - sendSec;
                int SecMilliSec = diffSec * 1000;
                int DiffMilleSec = SecMilliSec + (receMs - sentMs);
                return DiffMilleSec;
            }
            else
            {
                return diffInMs;
            }

           
        }

        private void showTable()
        {
            foreach (Object ip in IPtoPeer.Keys)
            {
                Peer mPeer = (Peer)IPtoPeer[ip];
                Console.Write("{0} ---> IP:{1},Port:{2},Name:{3},CPU:{4}\n", 
                    ip, mPeer.mIP, mPeer.mPort, mPeer.mName, mPeer.mCPU);
            }
            Console.Write("Master: {0} ; Backup: {1}\n", GetMaster(), GetBackup());
        }
        private String selectbackup()
        {
            string backup = "";
            string master = GetMaster();
            if (IPtoPeer.Count == 1)
            {
                return backup;
            }
            else
            {
                foreach (string IP in IPtoPeer.Keys)
                {
                    if (IP != master)
                    {
                        backup = IP;
                    }
                }
                foreach (string IPs in IPtoPeer.Keys)
                {
                    if (IPs != master)
                    {
                        int comp = IPs.CompareTo(backup);
                        if (comp < 0)
                            backup = IPs;
                    }
                }
                return backup;
            }
        }
        private void setMasterBackup(String ipport)
        {
            if (ipport == GetMaster())
            {
                SetMaster(GetBackup());
                RemovePeer(ipport);
                string backup = selectbackup();
                SetBackup(backup);
            }
            else if (ipport == GetBackup())
            {
                RemovePeer(ipport);
                string backup = selectbackup();
                SetBackup(backup);
            }
            else
            {
                RemovePeer(ipport);
            }
        }
    }
}
