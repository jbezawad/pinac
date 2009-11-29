//////////////////////////////////////////////////////////////////////////////////
//  SwarmAPI.cs - SwarmAPI module for UI                                        //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Mohammad Irfan Khan Tareen (mtareen@syr.edu)                 //
//                 Ronak Kirti Rathod (rkrathod@syr.edu)                        //
//                 Shaonan Wang (swang25@syr.edu)                               //
//                 Mehmet KAYA (mkaya@syr.edu)                                  //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 17 Nov 2009
 * - the initial version of the SwarmAPI module
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Management;

namespace Spinach
{
    public class SwarmConnection
    {
        //Delegate and Events**********************
        public delegate void ChangedEventHandler(List<string> conInfo);
        public event ChangedEventHandler ListChanged;
        public delegate void ChangedEventHandlerForDelay(Hashtable conInfo);
        public event ChangedEventHandlerForDelay ListChangedWithDelay;
        public delegate void ChatEventHandler(string Uname, string ChatMsg);
        public event ChatEventHandler ChatChanged;
        public delegate void ErrorEventHandler(int ErrorCode, string ErrorMsg);
        public event ErrorEventHandler ErrorChanged;
        public delegate void PrivelageEventHandler(string[] strPrev);
        public event PrivelageEventHandler AddPrev;
        public event PrivelageEventHandler ChngPermission;
        public event PrivelageEventHandler TransOwner;
        public delegate void DisconnectEventHandler(bool disconnect);
        public event DisconnectEventHandler DisconnectChanged;


        private List<string> DisplayList = new List<string>();
        Thread listenerThread;

        AsynchronousSocketListener mSocket = new AsynchronousSocketListener();
        public AsynchronousSocketListener getSocket()
        {
            return mSocket;
        }
        public SwarmConnection()
        {
            mSocket.ListChanged += new AsynchronousSocketListener.ChangedEventHandler(List_Changed);
            mSocket.ListChangedWithDelay+=new AsynchronousSocketListener.ChangedEventHandlerForDelay(List_Changed);
            mSocket.ChatChanged += new AsynchronousSocketListener.ChatEventHandler(Chat_Changed);
            mSocket.ErrorChanged += new AsynchronousSocketListener.ErrorEventHandler(Error_Changed);
            mSocket.AddPrev+=new AsynchronousSocketListener.PrivelageEventHandler(AddPrevChanged);
            mSocket.ChngPermission+=new AsynchronousSocketListener.PrivelageEventHandler(ChangPermission);
            mSocket.TransOwner+=new AsynchronousSocketListener.PrivelageEventHandler(TransferOwnership);
        }
        public void InsertProgtoSC(SwarmMemory sm)
        {
            mSocket.InsertProg(sm.getPid(), sm);
        }
        private void AddPrevChanged(string[] strTemp)
        {
            if (AddPrev != null)
                AddPrev(strTemp);
        }
        private void ChangPermission(string[] strTemp)
        {
            if (ChngPermission != null)
                ChngPermission(strTemp);
        }
        private void TransferOwnership(string[] strTemp)
        {
            if (TransOwner != null)
                TransOwner(strTemp);
        }

        private void List_Changed(Hashtable Displist)
        {
            DisplayList.Clear();
            //string Delay = "0";
            foreach (string iport in Displist.Keys)
            {
                Peer st = (Peer)Displist[iport];
                string Username = st.mName;
                string Delay;
                if (st.mDelay == null)
                    Delay = "0";
                else
                    Delay = st.mDelay;
                string conMsg = Username + " | " + iport + " | Delay: " + Delay;
                //if (DisplayList.Count < Displist.Count)
                //{
                //    if (!DisplayList.Contains(conMsg))
                //    {
                //        DisplayList.Add(conMsg);
                //    }
                //}
                //else if (DisplayList.Count > Displist.Count)
                //{
                //    DisplayList.Clear();
                //    DisplayList.Add(conMsg);
                //}
                DisplayList.Add(conMsg);
            }
            if (ListChanged != null)
                ListChanged(DisplayList);

        }
        private void Chat_Changed(string Username,string ChatMessage)
        {
            if (ChatChanged != null)
                ChatChanged(Username,ChatMessage);

        }
        private void Error_Changed(int errorcode,string ErrorMsg)
        {
            if (ErrorChanged != null)
                ErrorChanged(errorcode,ErrorMsg);

        }

        //*************************************
        public bool Join_Swarm(string DstIP, string DstPort, string SrcIP, string SrcPort, string Username)
        {
            Thread t1 = null;
            Thread t2 = null;
            try
            {
                string cpu = "1";
                mSocket.SetIP(SrcIP);
                mSocket.SetPort(SrcPort);
                mSocket.SetName(Username);
                mSocket.SetCPU(cpu);

                listenerThread = new Thread(new ThreadStart(mSocket.StartListening));
                listenerThread.IsBackground = true;
                listenerThread.Start();

                t1 = new Thread(new ThreadStart(mSocket.StarHeartBeat));
                t1.IsBackground = true;
                t1.Start();

                MessageGenerator msg = new MessageGenerator();
                string mMsg = msg.msgConnectionRequest
                    (mSocket.GetIP(), mSocket.GetPort(), mSocket.GetName(), mSocket.GetCPU());
                AsynchronousClient client = new AsynchronousClient();
                client.ErrorExcep += new AsynchronousClient.EventHandlerExcep(Error_Changed);
                client.SetSingleMsg(DstIP, DstPort, mMsg);
                // t2 = new Thread(new ThreadStart(client.SendSingleClient));
                client.SendSingleClient();
                // t2.Start();
                // t2.IsBackground = true;
                Thread.Sleep(2000);
                if (mSocket.GetIPtoPeer().Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to join swarm.");
                return false;
            }

        }

        public bool Create_Swarm(string SrcIP, string SrcPort, string Username)
        {
            try
            {
                Thread t1 = null;
                string cpu = "1";
                mSocket.SetIP(SrcIP);
                mSocket.SetPort(SrcPort);
                mSocket.SetName(Username);
                mSocket.SetCPU(cpu);


                listenerThread = new Thread(new ThreadStart(mSocket.StartListening));
                listenerThread.IsBackground = true;
                listenerThread.Start();

                t1 = new Thread(new ThreadStart(mSocket.StarHeartBeat));
                t1.IsBackground = true;
                t1.Start();


                mSocket.InsertPeer(mSocket.GetIP(), mSocket.GetPort(), mSocket.GetName(), mSocket.GetCPU());
                mSocket.SetMaster(mSocket.GetIP() + ":" + mSocket.GetPort());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to create swarm.");
                return false;
            }

        }

        public void Send_ChatMsg(string chatMsg, string Username)
        {
            try
            {
                Thread t = null;
                MessageGenerator mMsg = new MessageGenerator();
                //Chat username to be included
                string msg = mMsg.msgChat(chatMsg, mSocket.GetIP() + ":" + mSocket.GetPort());
                AsynchronousClient client = new AsynchronousClient();
                client.SetMultiMsg(mSocket.GetIPtoPeer(), msg, mSocket.GetIP() + ":" + mSocket.GetPort());
                t = new Thread(new ThreadStart(client.SendMultiClientChat));
                t.IsBackground = true;
                t.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send chat message.");
            }
        }

        //


        //public void CreatProgram(string _Pid, string myIP, string myPort)
        //{
        //    SwarmMemory sm = new SwarmMemory(pid, mSocket.GetIP() + ":" + mSocket.GetPort());
        //    sm.setOwner(mSocket.GetIP() + ":" + mSocket.GetPort());
        //    mSocket.InsertProg(pid, sm);
        //}

        //public void AssignPermission(string pid,string code,string ip,string port,string read, string write)
        //{
        //    string ipport = ip + ":" + port;
        //    SwarmMemory sm = mSocket.GetProg(pid);
        //    sm.addPermissionRequest(mSocket.GetIP() + ":" + mSocket.GetPort(), mSocket.GetIPtoPeer(), code, ipport, read, write);
        //}

        //public void ChangePermission(string pid, string ip,string port, string read, string write)
        //{
        //    string ipport = ip + ":" + port;
        //    SwarmMemory sm = mSocket.GetProg(pid);
        //    sm.changePermissionRequest(mSocket.GetIP() + ":" + mSocket.GetPort(), mSocket.GetIPtoPeer(), ipport, read, write);
        //}


        //public Hashtable GetPermission(string pid)
        //{
        //    return mSocket.GetPermission(pid);
        //}

        public void Disconnect()
        {
            if (DisconnectChanged != null)
                DisconnectChanged(true);
            mSocket.Disconnect();
            Thread.Sleep(1000);
            mSocket.Clear();
            mSocket.CloseSocket();
            //if (listenerThread.IsAlive)
            //{
            //    listenerThread.Abort();
            //}
            //            Thread.CurrentThread.Abort();
        }

        public Hashtable GetIPtoPeer()
        {
            return mSocket.GetIPtoPeer();
        }
    }
}
