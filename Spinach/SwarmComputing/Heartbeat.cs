//////////////////////////////////////////////////////////////////////////////////
//  Heartbeat.cs - Heartbeat client module                                      //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Visual Studio 2008SP1                                        //
//  Application:   SPINACH                                                      //
//  Author:        Mohammad Irfan Khan Tareen (mtareen@syr.edu)                 //
//                 Ronak Kirti Rathod (rkrathod@syr.edu)                        //
//                 Shaonan Wang (swang25@syr.edu)                               //
//                 Zutao Zhu (zuzhu@syr.edu)                                    //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////
/*
 * Maintenance History:
 * ====================
 * version 1.0 : 20 Nov 2009
 * - the initial version of the Heartbeat client module
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Spinach
{
    // State object for receiving data from remote device.

    public class HeartbeatClient
    {
        public delegate void EventHandlerHeartBeat(string HBError);
        public event EventHandlerHeartBeat HeartBeatException;

        String SingleMsg;
        String targetip;
        String targetport;
        // The port number for the remote device.
        //private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        //private String response = String.Empty;
        public void SetSingleMsg(String ip, String port, String msg)
        {
            targetip = ip;
            targetport = port;
            SingleMsg = msg;
        }
        public void SendSingleClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPAddress ipAddress = (Dns.GetHostAddresses(targetip))[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Int32.Parse(targetport));

                //Socket client = new Socket(AddressFamily.InterNetwork,
                //        SocketType.Stream, ProtocolType.Tcp);

                {
                    // Create a TCP/IP socket.
                    Socket client = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();

                    // Send test data to the remote device.
                    string m = SingleMsg + "<EOF>";
                    Send(client, m);
                    sendDone.WaitOne();

                    // Receive the response from the remote device.
                    //Receive(client);
                    //receiveDone.WaitOne();

                    // Write the response to the console.
                    //Console.WriteLine("Response received : {0}", response);

                    // Release the socket.
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }

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
                Console.WriteLine("Heartbeat Error");

                //////////////////////////////////////!!!!!!!!!!!!!!!///////////////////
                string IPPort = targetip + ":" + targetport;
                if (HeartBeatException != null)
                    HeartBeatException(IPPort);
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
            catch (Exception e)
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