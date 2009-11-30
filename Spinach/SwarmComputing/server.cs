//////////////////////////////////////////////////////////////////////////////////
//  server.cs - Socket server module                                            //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Zutao Zhu (zuzhu@syr.edu)                                    //
//                 Shaonan Wang (swang25@syr.edu)                               //
//                 Mohammad Irfan Khan Tareen (mtareen@syr.edu)                 //
//                 Ronak Kirti Rathod (rkrathod@syr.edu)                        //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 3 Nov 2009
 * - the initial version of the Socket server module
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections;

namespace Spinach
{
    // State object for reading client data asynchronously
    public class ServerStateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public partial class AsynchronousSocketListener
    {
        public delegate void EventHandlerHeartBeat(string HBError);
        public event EventHandlerHeartBeat HeartBeatException;
        public delegate void ChangedEventHandlerForDelay(Hashtable conInfo);
        public event ChangedEventHandlerForDelay ListChangedWithDelay;


        // Thread signal.
        public ManualResetEvent allDone = new ManualResetEvent(false);
        Socket listener;

        public AsynchronousSocketListener()
        {        
        }

        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            string strport = mPeer.mPort;
            int port = Convert.ToInt32(strport);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message, "Failed to listen.");
            }

            //Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.
                allDone.Set();

                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                //allDone.Set();

                // Create the state object.
                ServerStateObject state = new ServerStateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, ServerStateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message, "Accept callback exception");
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                ServerStateObject state = (ServerStateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        // All the data has been read from the 
                        // client. Display it on the console.
                        preProcess(content);

                        // Echo the data back to the client.
                        //Send(handler, content);
                    }
                    else
                    {
                        // Not all data received. Get more.
                        handler.BeginReceive(state.buffer, 0, ServerStateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    }
                }
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message, "Read callback exception");
            }
        }

        private void preProcess(String msg)
        {
            string mMsg=msg.Remove(msg.Length-5);
            //Console.WriteLine("{0}\n ",mMsg);
            parseMsg(mMsg);
        }

        public void Disconnect()
        {
            MessageGenerator temp = new MessageGenerator();
            string msg = temp.msgDisconnect(mPeer.mIP + ":" + mPeer.mPort);
            Thread t = null;
            AsynchronousClient client = new AsynchronousClient();
            client.SetMultiMsg(GetIPtoPeer(), msg, GetIP() + ":" + GetPort());

            t = new Thread(new ThreadStart(client.SendMultiClient));
            t.IsBackground = true;
            t.Start();
//            Thread.Sleep(5000);
  //          Clear();
            //Thread.Sleep(5000);
        }

        public void CloseSocket()
        {
            listener.Close();
        }
        public void StarHeartBeat()
        {
            MessageGenerator temp=new MessageGenerator();
            string HeartBeatRequestmsg = temp.msgHeartBeatRequest(GetIP() + ":" + GetPort());
            while (true)
            {
                try
                {
                    if (IPtoPeer.Count > 1)
                    {
                        foreach (string IP in IPtoPeer.Keys)
                        {
                            if (IP != GetIP() + ":" + GetPort())
                            {
                                Peer p = new Peer();
                                p = (Peer)IPtoPeer[IP];
                                string ip = p.mIP;
                                string port = p.mPort;
                                HeartbeatClient client = new HeartbeatClient();
                                client.SetSingleMsg(ip, port, HeartBeatRequestmsg);
                                client.HeartBeatException += new HeartbeatClient.EventHandlerHeartBeat(ShutDown);
                                Thread t;
                                string sendtime = DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString();
                                InsertSendTime(ip+":"+port,sendtime);
                                t = new Thread(new ThreadStart(client.SendSingleClient));
                                t.IsBackground = true;
                                t.Start();
                                Thread.Sleep(3000);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public void InsertSendTime(String ipport, String time)
        {
            try
            {
                if (IPtoHeartbeat.Contains(ipport))
                {
                    Heartbeat temp = (Heartbeat)IPtoHeartbeat[ipport];
                    temp.SendTime = time;
                    // temp.ReceiveTime = "";
                    IPtoHeartbeat[ipport] = temp;
                }
                else
                {
                    Heartbeat temp = new Heartbeat();
                    temp.SendTime = time;
                    temp.ReceiveTime = "";
                    IPtoHeartbeat.Add(ipport, temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void InsertReceiveTime(String ipport, String time)
        {
            Heartbeat temp = (Heartbeat)IPtoHeartbeat[ipport];
            temp.ReceiveTime = time;
            IPtoHeartbeat[ipport] = temp;
        }
        private void InsertDelay(String ipport, String Delay)
        {
            Peer temp = (Peer)IPtoPeer[ipport];
            temp.mDelay = Delay;
            IPtoPeer[ipport] = temp;
            if (ListChangedWithDelay != null)
               ListChangedWithDelay(IPtoPeer);

        }
        public void ShutDown(string ExcepErr)
        {
            try
            {
                Hashtable temp = GetPidtoProgram();
                foreach (string pid in temp.Keys)
                {
                    SwarmMemory sm = (SwarmMemory)temp[pid];
                    sm.removePermissionRec(ExcepErr);
                }
                setMasterBackup(ExcepErr);
                showTable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //private void Send(Socket handler, String data)
        //{
        //    // Convert the string data to byte data using ASCII encoding.
        //    byte[] byteData = Encoding.ASCII.GetBytes(data);

        //    // Begin sending the data to the remote device.
        //    handler.BeginSend(byteData, 0, byteData.Length, 0,
        //        new AsyncCallback(SendCallback), handler);
        //}

        //private void SendCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the socket from the state object.
        //        Socket handler = (Socket)ar.AsyncState;

        //        // Complete sending the data to the remote device.
        //        int bytesSent = handler.EndSend(ar);
        //        Console.WriteLine("Sent {0} bytes to client.", bytesSent);

        //        handler.Shutdown(SocketShutdown.Both);
        //        handler.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}


        //public static int Main(String[] args)
        //{
        //    StartListening();
        //    return 0;
        //}
    }
}