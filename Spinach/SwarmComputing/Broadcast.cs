//////////////////////////////////////////////////////////////////////////////////
//  Broadcast.cs - Broadcast client module                                      //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Zutao Zhu (zuzhu@syr.edu)                                    //
//                 Shaonan Wang (swang25@syr.edu)                               //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 14 Nov 2009
 * - the initial version of the Broadcast client module
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Spinach
{

        public class BroadcastClient
        {
            string mIP;
            int mPort;
            string mMsg;

            public BroadcastClient(string IP,int port,string msg) 
            {
                mIP = IP;
                mPort = port;
                mMsg = msg;
            }

            // ManualResetEvent instances signal completion.
            private ManualResetEvent connectDone =
                new ManualResetEvent(false);
            private ManualResetEvent sendDone =
                new ManualResetEvent(false);
            private ManualResetEvent receiveDone =
                new ManualResetEvent(false);


            public void StartClient(object cnt)
            {
                int cCount = (int)cnt;
                // Connect to a remote device.
                try
                {
                    // Establish the remote endpoint for the socket.
                    IPAddress ipAddress = (Dns.GetHostAddresses(mIP))[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, mPort);

                    //Socket client = new Socket(AddressFamily.InterNetwork,
                    //        SocketType.Stream, ProtocolType.Tcp);

                    //for (int i = 0; i < 10; ++i)
                    {
                        // Create a TCP/IP socket.
                        Socket client = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);

                        // Connect to the remote endpoint.
                        client.BeginConnect(remoteEP,
                            new AsyncCallback(ConnectCallback), client);
                        connectDone.WaitOne();

                        // Send test data to the remote device.
                        string m = mMsg + "<EOF>";
                        Send(client, m);
                        sendDone.WaitOne();


                        // Release the socket.
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                try
                {
                    AsynchronousClient.resetEvent[cCount].Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private void ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.
                    Socket client = (Socket)ar.AsyncState;

                    // Complete the connection.
                    client.EndConnect(ar);

                    Console.WriteLine("Socket connected to {0}",
                        client.RemoteEndPoint.ToString());

                    // Signal that the connection has been made.
                    connectDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

          

            private void Send(Socket client, String data)
            {
                try
                {
                    // Convert the string data to byte data using ASCII encoding.
                    byte[] byteData = Encoding.ASCII.GetBytes(data);

                    // Begin sending the data to the remote device.
                    client.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), client);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.
                    int bytesSent = client.EndSend(ar);
                    Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                    // Signal that all bytes have been sent.
                    sendDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }   
}
