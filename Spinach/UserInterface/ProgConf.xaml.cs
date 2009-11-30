//////////////////////////////////////////////////////////////////////////////////
//  ProgConf.xaml.cs - Program Configuration Window                             //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Windows Vista                                                //
//  Application:   SPINACH                                                      //
//  Author:        Prateek Jain (pjain02@syr.edu)                               //
//                 (315) 751 7324                                               //
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Spinach
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    
    public delegate void ConnectionNotification();
    
    public partial class ProgConf : Window
    {
        public event ConnectionNotification Conn;
        private string username = "";
        private string IP = "";
        private string Port = "";
        private int WindowCount = 0;
        private string[] AccessString;
        String programText = "";

        private Dictionary<string, ArrayList> AccessControlList = new Dictionary<string, ArrayList>();
        private List<Thread> threadList = new List<Thread>();
        private List<string> userList;
        private Dictionary<string, string> swarmUserTable;
        private ErrorModule err = new ErrorModule();
        bool disconnectClick = false;                //Checks whether the diconnect button was pressed
        private SwarmConnection SC;
        private Paragraph p = new Paragraph();

        private void OwnerChanged(string[] strPrev)
        {
              Thread th = new Thread(new ThreadStart(
              delegate()
              {
                  this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                      delegate()
                      {
                            ProgWin temp = (ProgWin)AccessControlList[strPrev[0]][1];
                            string ipPort = strPrev[1] + ":" + strPrev[2];
                            foreach (string s in userList)
                            {
                                string[] userInfo = s.Split('|');
                                if (userInfo[1].Trim() == ipPort)
                                {
                                    temp.SMObj().setOwner(ipPort);
                                    temp.setOwner(userInfo[0].Trim());
                                    break;
                                }
                            }
                      }));
              }));
              th.Start();
        }

        private void submnuExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = System.Windows.MessageBox.Show("Do you really want to disconnect from the swarm?", "Disconnect?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                //Code for disconnecting from the swarm
                Dictionary<string, ArrayList> local = AccessControlList;
                foreach (KeyValuePair<string, ArrayList> kp in local)
                {
                    ProgWin temp = (ProgWin)kp.Value[1];
                    temp.send_close_msg();
                }
                foreach (Thread t in threadList)
                {
                    t.Abort();
                }
                Thread.Sleep(5000);
                SC.Disconnect();
                //this.Close();
                Environment.Exit(1);
            }
        }

        private void submnuDisconnect_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = System.Windows.MessageBox.Show("Do you really want to disconnect from the swarm?", "Disconnect?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                //Code for disconnecting from the swarm
                Dictionary<string, ArrayList> local = AccessControlList;
                foreach (KeyValuePair<string, ArrayList> kp in local)
                {
                    ProgWin temp = (ProgWin)kp.Value[1];
                    temp.send_close_msg();
                }
                foreach (Thread t in threadList)
                {
                    t.Abort();
                }
                SC.Disconnect();
                if (Conn != null)
                    Conn();
                this.Close();
            }
        }

        private void frmProgConf_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void cmdSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtMessage.Text != "")
            {
                SC.Send_ChatMsg(txtMessage.Text, username);
                txtMessage.Text = "";
            }
        }

      private void OwnerThreadStartingPoint()
      {
          string pid;
          pid = Guid.NewGuid().ToString();
          ProgWin editor = new ProgWin(ProgWin.editorType.owner, SC, IP, Port, pid, username);
          editor.CloseProgramEvent += new ProgWin.CloseProgramEventHandler(editor_CloseProgramEvent);
          //owner is the user itself. so pass the username here
          //list of the users in swarm
          //take the program name and send the program name
          editor.setUserList(userList);
          editor.setPermissions("RW");
          editor.loadProgram(programText);
          editor.setOwner(username);
          editor.SMObj().setOwner(IP + ":" + Port);
          ArrayList list = new ArrayList();
          list.Add("RW");
          list.Add(editor);
          AccessControlList.Add(pid, list);
          //editor.Owner = this;
          editor.Show();

          System.Windows.Threading.Dispatcher.Run();
      }

      void editor_CloseProgramEvent(string pid)
      {
          AccessControlList.Remove(pid);
      }

      private void NewAccessPermission(string[] strPrev)
      {
          Thread th = new Thread(new ThreadStart(
              delegate()
              {
                  this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                      delegate()
                      {
                          string[] s = strPrev;

                          //Change Permission Case
                          if (s.Length == 5 && s[1] == IP && s[2] == Port)
                          {
                              string permission = "";
                              if (s[3].ToString() == "true")
                                  permission += "R";
                              if (s[4].ToString() == "true")
                                  permission += "W";
                              if (s[3].ToString() == "false" && s[4].ToString() == "false")
                              {
                                  ProgWin temp = (ProgWin)AccessControlList[s[0].ToString()][1];
                                  temp.Close();
                              }
                              AccessControlList[s[0].ToString()][0] = permission;
                              ProgWin t = (ProgWin)AccessControlList[s[0].ToString()][1];
                              t.SMObj().adder(s[1] + ":" + s[2], s[3], s[4]);
                              t.setPermissions(permission);
                          }
                          // New Permissions Case
                          else if (s[3] == IP && s[4] == Port)
                          {
                              Thread newWindowThread =
                                              new Thread(
                                                   new ThreadStart(
                                                        AccessThreadStartingPoint));
                              newWindowThread.SetApartmentState(ApartmentState.STA);
                              newWindowThread.IsBackground = true;
                              WindowCount++;
                              newWindowThread.Name = "Window" + WindowCount;
                              AccessString = s;
                              threadList.Add(newWindowThread);
                              newWindowThread.Start();

                              //string pid;
                              //pid = Guid.NewGuid().ToString();
                          }
                          //Some other user getting permissions
                          else
                          {
                              if (s.Length == 5)
                              {
                                  ProgWin t = (ProgWin)AccessControlList[s[0].ToString()][1];
                                  t.SMObj().adder(s[1] + ":" + s[2], s[3], s[4]);
                              }
                              else
                              {
                                  ProgWin t = (ProgWin)AccessControlList[s[0].ToString()][1];
                                  t.SMObj().adder(s[3] + ":" + s[4], s[5], s[6]);
                              }
                          }
                      }));
              }));
          th.Start();
      }

      private void AccessThreadStartingPoint()
      {
          ProgWin editor = new ProgWin(ProgWin.editorType.collaborator, SC, IP, Port, AccessString[0], username);
          editor.CloseProgramEvent += new ProgWin.CloseProgramEventHandler(editor_CloseProgramEvent);
          ArrayList list = new ArrayList();
          string permission = "";
          if (AccessString[5].ToString() == "true")
              permission += "R";
          if (AccessString[6].ToString() == "true")
              permission += "W";
          list.Add(permission);
          list.Add(editor);
          AccessControlList.Add(AccessString[0], list);
          editor.loadProgram(AccessString[2]);
          foreach (string entry in userList)
          {
              string[] userInfo = entry.Split('|');
              if (userInfo[1].Trim() == AccessString[1])
              {
                  editor.setOwner(userInfo[0].Trim());
                  break;
              }
          }
          //editor.setOwner(s[1]);
          editor.SMObj().setOwner(AccessString[1]);
          editor.Show();
          editor.setUserList(userList);
          editor.setPermissions(permission);
          //editor.SMObj().createTheObjects(s[0], IP, Port);
          editor.SMObj().InitializeThePeer(AccessString[7]);
          editor.SMObj().adder(AccessString[3] + ":" + AccessString[4], AccessString[5], AccessString[6]);

          System.Windows.Threading.Dispatcher.Run();
      }

      private void ShowError(string errorMsg)
      {
          System.Windows.MessageBox.Show(errorMsg, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      /// <summary>
      /// Updates the list of users in the swarm.
      /// </summary>
      /// <param name="userList">List of users in the swarm</param>
      private void updateList(List<string> userList)
      {
      }

/*** All public functions ***/

      /// <summary>
      /// Sets the username to be displayed on the screen.
      /// This is sent by the connection module.
      /// </summary>
      /// <param name="SelfIP">Self IP Address</param>
      /// <param name="SelfPort">Self Port</param>
      /// <param name="user">username which was accepted by the swarm while connecting</param>
      public void setDetails(string SelfIP, string SelfPort, string user)
      {
          IP = SelfIP;
          Port = SelfPort;
          username = user;
      }

      /// <summary>
      /// Default constructor - Initializing the intial things
      /// </summary>
      // TODO check all the initializations
      public ProgConf(SwarmConnection SConn)
      {
          InitializeComponent();
          SC = SConn;
          ChatModule Chat = new ChatModule(SC);
          mnuProg.Visibility = Visibility.Visible;
          txtMessage.Focus();

          //Event Registrations
          err.ProgConfError += new ErrorNotification(ShowError);
          SC.ListChanged += new SwarmConnection.ChangedEventHandler(setUserList);
          SC.TransOwner += new SwarmConnection.PrivelageEventHandler(OwnerChanged);
          SC.ChngPermission += new SwarmConnection.PrivelageEventHandler(NewAccessPermission);
          SC.AddPrev += new SwarmConnection.PrivelageEventHandler(NewAccessPermission);
          Chat.Chat += new ChatNotification(DisplayChat);

          //Add paragraph to rich text box
          rtbChat.Document.Blocks.Add(p);
      }

      /// <summary>
      /// Sets the userlist sent by the connection module.
      /// This list contains all the users currently in the swarm.
      /// </summary>
      /// <param name="list">List of all the users in the swarm</param>
      public void setUserList(List<string> list)
      {
          userList = list;
          Thread th = new Thread(new ThreadStart(
              delegate()
              {
                  lstUserList.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                      delegate()
                      {
                          lstUserList.Items.Clear();
                          for (int i = 0; i < userList.Count; i++)
                          {
                              lstUserList.Items.Add(userList[i]);
                          }
                          foreach (ArrayList ar in AccessControlList.Values)
                          {
                              ProgWin temp = (ProgWin)ar[1];
                              temp.setUserList(userList);
                          }
                      }));
              }));
          th.Start();
      }

      /// <summary>
      /// Display the chat in the chat box
      /// </summary>
      /// <param name="Uname">Username of the chat message sender</param>
      /// <param name="Msg">Actual chat message</param>
      public void DisplayChat(string Uname, string Msg)
      {
          Thread th = new Thread(new ThreadStart(
            delegate()
            {
                rtbChat.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                    delegate()
                    {
                        p.Inlines.Add(new Bold(new Run(Uname)));
                        p.Inlines.Add(new Run(": " + Msg + "\n"));
                    }));
            }));
          th.Start();
      }

/*** All the Events ***/

      private void submnuLoad_Click(object sender, RoutedEventArgs e)
      {
          programText = "";
          Stream myStream = null;
          OpenFileDialog openFileDialog1 = new OpenFileDialog();

          openFileDialog1.InitialDirectory = "c:\\";
          openFileDialog1.Filter = "ssf files (*.ssf)|*.ssf|All files (*.*)|*.*";
          openFileDialog1.FilterIndex = 1;
          openFileDialog1.RestoreDirectory = true;

          if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          {
              try
              {
                  if ((myStream = openFileDialog1.OpenFile()) != null)
                  {
                      StreamReader sr = new StreamReader(openFileDialog1.FileName);
                      using (sr)
                      {
                          string line;
                          line = sr.ReadLine();
                          while ((line) != null)
                          {
                              programText = programText + line;
                              line = sr.ReadLine();
                              if (line != null)
                              {
                                  programText += "\n";
                              }
                          }
                      }
                  }

                  Thread newWindowThread =
                        new Thread(
                             new ThreadStart(
                                  OwnerThreadStartingPoint));
                  newWindowThread.SetApartmentState(ApartmentState.STA);
                  newWindowThread.IsBackground = true;
                  newWindowThread.Start();


              }
              catch (Exception ex)
              {
                  System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
              }
          }
      }

      private void submnuNew_Click(object sender, RoutedEventArgs e)
      {
          programText = "";
          Thread newWindowThread =
                          new Thread(
                               new ThreadStart(
                                    OwnerThreadStartingPoint));
          newWindowThread.SetApartmentState(ApartmentState.STA);
          newWindowThread.IsBackground = true;
          WindowCount++;
          newWindowThread.Name = "Window" + WindowCount;
          threadList.Add(newWindowThread);
          newWindowThread.Start();
          //OwnerThreadStartingPoint();
      }

      private void frmProgConf_Closed(object sender, EventArgs e)
      {
          MessageBoxResult result;
          result = System.Windows.MessageBox.Show("Do you really want to disconnect from the swarm?", "Disconnect?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
          if (result == MessageBoxResult.Yes)
          {
              //Code for disconnecting from the swarm
              Dictionary<string, ArrayList> local = AccessControlList;
              foreach (KeyValuePair<string, ArrayList> kp in local)
              {
                  ProgWin temp = (ProgWin)kp.Value[1];
                  temp.send_close_msg();
              }
              foreach (Thread t in threadList)
              {
                  t.Abort();
              }
              SC.Disconnect();
              this.Close();
              Environment.Exit(1);
          }
      }

      private void rtbChat_TextChanged(object sender, TextChangedEventArgs e)
      {
          rtbChat.ScrollToEnd();
      }
    }
}
