//////////////////////////////////////////////////////////////////////////////////
//  Peer.cs - Swarm connection infomation module                                //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Shaonan Wang (swang25@syr.edu)                               //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 24 Oct. 2009
 * - the initial version of the Peer module
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Spinach
{

    public struct Peer
    {
        public String mIP;
        public String mPort;
        public String mName;
        public String mCPU;
        public String mDelay;
    }

    public struct Heartbeat
    {
        public String SendTime;
        public String ReceiveTime;
    }

    public partial class AsynchronousSocketListener
    {
        public delegate void ChangedEventHandler(Hashtable conInfo);
        public event ChangedEventHandler ListChanged;


        ////////////////////////////////////////////////////////////////////////////////


        //connection part
        Peer mPeer = new Peer();

        //computation part
        //private Hashtable RunFlag = new Hashtable();//pid->runflag
        private Hashtable Program = new Hashtable();//pid->swarm program object

        //shared infomation part
        private String Master;
        private String Backup;
        private Hashtable IPtoPeer = new Hashtable();//ip:port->peer object
        private Hashtable NametoIP = new Hashtable();//username->ip:port
        private Hashtable IPtoHeartbeat = new Hashtable();//ip:port->heartbeat object


        public void SetIP(String str) { mPeer.mIP = str; }
        public String GetIP() { return mPeer.mIP; }

        public void SetPort(String str) { mPeer.mPort = str; }
        public String GetPort() { return mPeer.mPort; }

        public void SetName(String str) { mPeer.mName = str; }
        public String GetName() { return mPeer.mName; }

        public void SetCPU(String str) { mPeer.mCPU = str; }
        public String GetCPU() { return mPeer.mCPU; }


        public void SetMaster(String str) { Master = str; }
        public String GetMaster() { return Master; }

        public void SetBackup(String str) { Backup = str; }
        public String GetBackup() { return Backup; }

        public int InsertPeer(String ip, String port, String name, String cpu)
        {
            string ipport = ip + ":" + port;
            Peer nPeer = new Peer();
            nPeer.mIP = ip;
            nPeer.mPort = port;
            nPeer.mName = name;
            nPeer.mCPU = cpu;
            IPtoPeer[ipport] = nPeer;
            NametoIP[name] = ipport;


            //////////////////////////////
            if (ListChanged != null)
                ListChanged(IPtoPeer);
            //////////////////////////////////
            return 1;
        }

        public int RemovePeer(String ipport)
        {
            if (IPtoPeer.Contains(ipport))
            {
                Peer temp = (Peer)IPtoPeer[ipport];
                string name = temp.mName;
                IPtoPeer.Remove(ipport);
                if (NametoIP.Contains(name))
                    NametoIP.Remove(name);
                ///////////////////////
                if (ListChanged != null)
                    ListChanged(IPtoPeer);
                /////////////////////////////
                return 1;
            }
            else
                return 0;
        }

        public void Clear()
        {
            if (IPtoPeer.Count > 0)
                IPtoPeer.Clear();
            if (NametoIP.Count > 0)
                NametoIP.Clear();
            if (Program.Count > 0)
                Program.Clear();
        }

        public Hashtable GetIPtoPeer() { return IPtoPeer; }
        public Hashtable GetNametoIP() { return NametoIP; }
        public Hashtable GetPidtoProgram() { return Program; }

        public void InsertProg(String pid, SwarmMemory prog)
        {
            Program[pid] = prog;
        }

        public SwarmMemory GetProg(String pid)
        {
            SwarmMemory temp = null;
            if (Program.Contains(pid))
                temp = (SwarmMemory)Program[pid];
            return temp;
        }

    }
}
