//////////////////////////////////////////////////////////////////////////////////
//  ProgWin.xaml.cs - Program Editor                                            //
//  ver 1.0                                                                     //
//                                                                              //
//  Language:      C#                                                           //
//  Platform:      Windows Vista                                                //
//  Application:   SPINACH                                                      //
//  Author:        Arunkumar K T (akyasara@syr.edu)                             //
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
using System.IO;
using System.Threading;
using System.ComponentModel;
using Spinach;

namespace Spinach
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProgWin : Window
    {
        //Local Declarations
        bool read, write;
        private string PID;                     //Program ID
        private string owner;
        private string username;
        string IP = "";
        string Port = "";
        private List<string> swarmUserList; 
        private List<string> progUserList;
        private Dictionary<string, string> swarmUserTable = new Dictionary<string,string>();
        public enum editorType { owner, collaborator };
        public editorType et;
        private BackgroundWorker worker;
        public delegate void CloseProgramEventHandler(string pid);
        public event CloseProgramEventHandler CloseProgramEvent;

        //Collaborative Editing Related
        string prog = "";
        struct userhighlight
        {
            public int start;
            public int size;
            public string name;
        };
        List<userhighlight> m_user = new List<userhighlight>();
        Hashtable editedNum = new Hashtable();

        //Related to Text Highlighting
        struct tags
        {
            public int start;
            public int size;
        };
        List<tags> m_tags = new List<tags>();
        List<String> keywords = new List<String>();
        
        //Error Module
        private ErrorModule err = new ErrorModule();               
        
        //Plot related declarations
        private PlotReceiver plot = new PlotReceiver();             
        PngBitmapEncoder PBE = new PngBitmapEncoder();
        private string plotpath = "";
        private int isplotReady = 0; 

        //Swarm Memory related Declarations
        private SwarmConnection SC;
        private SwarmMemory SM;

        //Exec Controller
        private executor Controller;
        
        Thread cur_th = null;
        public delegate void mydelegate();


        //***   All the public functions    ***//
        /// <summary>
        /// ProgWin Constructor
        /// </summary>
        /// <param name="e">editor type</param>
        /// <param name="sconn">Swarm Connection Object</param>
        /// <param name="ip">Self IP</param>
        /// <param name="port">Self Port</param>
        /// <param name="pid">PID of the program</param>
        /// <param name="uname">Self USername</param>
        public ProgWin(editorType e, SwarmConnection sconn, string ip, string port, string pid, string uname)
        {
            InitializeComponent();
            et = e;
            err.ProgWinError += new ErrorNotification(ShowError);
            plot.image += new PlotReceiver.BmpImage(EnablePlot);
            Controller = new executor();
            Controller.resEvent += new executor.result(Display);
            keywords = Controller.frontEnd.getKeywords();
            err.SetExecutorObject(Controller);
            err.SetPlotObject(plot);
            username = uname;

            //Swarm Operations
            SC = sconn;
            SM = new SwarmMemory(SC);
            IP = ip;
            Port = port;
            PID = pid;
            SM.PermissionListCh += new SwarmMemory.PermissionListChanged(progUserListChange);
            SM.rnBtnClicked += new SwarmMemory.RunButtonClick(RunClicked);
            SM.srcChanged += new SwarmMemory.SourceCodeChanged(CollabEditing);
            SM.CloseP += new SwarmMemory.CloseProgram(SM_CloseP);
            SM.RerunP += new SwarmMemory.RerunProgram(SM_RerunP);
            SM.createTheObjects(PID, IP, Port);                 //Finally the swarm memory object
            SC.InsertProgtoSC(SM);

            //Exec Operations
            Controller.setPlotObject(plot);
            Controller.setSMObject(SM);
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void SM_RerunP(bool Rerun)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            if (SM.ReRunClicked(IP, Port))
                            {
                                txtResult.Text = "";
                                isplotReady = 0;
                                plotpath = Title;
                                plotpath += ".png";
                                TextPointer start = rtbInput.Document.ContentStart;
                                TextPointer end = rtbInput.Document.ContentEnd;
                                TextRange tr = new TextRange(start, end);
                                Controller.clearCoreValues();
                                worker.RunWorkerAsync(tr.Text);
                                mnuPlot.IsEnabled = true;
                            }
                        }));
                }));
            t.Start();
        }

        void SM_CloseP(bool CloseProg)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            SM.programClosed();
                            Close();
                        }));
                }));                                                                      
            t.Start();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.VisitLine(e.Argument.ToString());
        }

        void CollabEditing(string[] SourceChanged)
        {
            update(SourceChanged[0], SourceChanged[1], SourceChanged[2], SourceChanged[3]);
        }

        void RunClicked(bool Clicked)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            if (Clicked)
                            {
                                btnCompute.IsEnabled = false;
                                rtbInput.IsEnabled = false;
                            }
                            else
                            {
                                btnCompute.IsEnabled = true;
                                rtbInput.IsEnabled = true;
                            }
                        }));
                }));
            t.Start();
        }

        void progUserListChange(List<string> PerListChanged)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            lstUsers.Items.Clear();
                            foreach (string entry in PerListChanged)
                            {
                                lstUsers.Items.Add(entry);
                            }
                        }));
                }));
            t.Start();
        }

        /// <summary>
        /// Returns the swarm memory object for the calling object
        /// </summary>
        /// <returns>Swarm Memory Object of the object</returns>
        public SwarmMemory SMObj()
        {
            return SM;
        }

        /// <summary>
        /// Sets the owner of program, also updates the local variable 'owner'.
        /// </summary>
        /// <param name="uname"></param>
        public void setOwner(string uname)
        {
              Thread th = new Thread(new ThreadStart(
              delegate()
              {
                  this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                      delegate()
                      {
                          owner = uname;
                          lblOwner.Content = "Owner: " + owner;
                          //SM.setOwner(owner);

                          //Logic for checking Access menu
                          if (username == owner)
                              mnuAccess.IsEnabled = true;
                          else
                              mnuAccess.IsEnabled = false;
                      }));
              }));
              th.Start();
        }

        /// <summary>
        /// Sets the swarm user list
        /// </summary>
        /// <param name="list">Swarm User List</param>
        public void setUserList(List<string> list)
        {
            swarmUserList = list;
            foreach (string s in swarmUserList)
            {
                string[] userInfo = s.Split('|');
                string ipPort = userInfo[1].Trim();
                swarmUserTable[ipPort] = userInfo[0].Trim();
            }
        }

        /// <summary>
        /// Sets the Program Collaborators user list
        /// </summary>
        /// <param name="list">Program Collaboratos User List</param>
        public void setProgUserList(List<string> list)
        {
            progUserList = list;
        }
        
        /// <summary>
        /// Loads the program text into the editor.
        /// </summary>
        /// <param name="text">Program Text</param>
        public void loadProgram(string text)
        {
            rtbInput.AppendText(text);
            syntax();
            LineNumbers();
        }

        /// <summary>
        /// Sets the permissions for the user for this particular program
        /// </summary>
        /// <param name="perm">Permission String</param>
        public void setPermissions(string perm)
        {
            if (perm == "RW")
            {
                read = true;
                write = true;
            }
            else if (perm == "R")
            {
                read = true;
                write = false;
            }
            else if (perm == "W")
            {
                read = true;
                write = true;
            }

            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    rtbInput.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            if (write)
                                rtbInput.IsEnabled = true;
                            else
                                rtbInput.IsEnabled = false;
                        }));
                }));
            t.Start();
        }


        //***   All the Private Functions   ***//
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (et == editorType.collaborator)
            {
                //This will disable the Access Control menu
                mnuAccess.IsEnabled = false;
            }
        }

        private void format()
        {
            m_tags.Sort(compare);
            for (int i = 0; i < m_tags.Count; i++)
            {
                TextPointer str = rtbInput.Document.ContentStart.GetPositionAtOffset(m_tags[i].start, LogicalDirection.Forward);
                TextPointer stp = str.GetPositionAtOffset(m_tags[i].size, LogicalDirection.Backward);
                TextRange ts = new TextRange(str, stp);
                ts.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Blue));
            }
        }
        
        private void syntax()
        {
            TextPointer start = rtbInput.Document.ContentStart;
            TextPointer end = rtbInput.Document.ContentEnd;
            TextRange tr = new TextRange(start, end);
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Black)); 
            m_tags.Clear();
            for (int s = 0; s < keywords.Count && tr.Text.Length > 2; s++)
            {
                int index = -1;
                string text = tr.Text.ToString();
                string[] txt;
                index = text.LastIndexOf(keywords[s]);
                while (index != -1 && text.Length > 0)
                {
                    tags t = new tags();
                    text = text.Substring(0, index + keywords[s].Length);
                    txt = text.Split('\n');
                    int num = 0;
                    for (int i = 0; i < txt.Length; i++)
                        if (txt[i].Length > 1)
                            num = num + 1;
                        else if (txt[i].Length == 1 && keywords[s].Length == 1 && txt[i] == keywords[s])
                            num = num + 1;
                    if ((index==0 || (index >= 1 &&
                        !((tr.Text[index - 1] >= 'a' && tr.Text[index - 1] <= 'z') || (tr.Text[index - 1] >= 'A' && tr.Text[index - 1] <= 'Z')))) &&
                        !((tr.Text[index + keywords[s].Length] >= 'a' && tr.Text[index + keywords[s].Length] <= 'z') || (tr.Text[index + keywords[s].Length] >= 'A' && tr.Text[index + keywords[s].Length] <= 'Z')))
                    {
                        t.start = index+2*num;
                        t.size = keywords[s].Length;
                        m_tags.Add(t);
                    }
                        text = text.Substring(0, index);
                        index = text.LastIndexOf(keywords[s]);
                }
            }
            format();
        }
        
        private void LineNumbers()
        {
            TextPointer start = rtbInput.Document.ContentStart;
            TextPointer end = rtbInput.Document.ContentEnd;
            TextRange tr = new TextRange(start, end);
            string[] txt = tr.Text.Split('\n');

            if (tr.Text.Length > 2)
            {
                if (!mnuWrap.IsChecked)
                {
                    lstLine.Items.Clear();
                    if (txt.Length > 0 && lstLine.Items.Count >= 0)
                    {
                        if (lstLine.Items.Count <= txt.Length - 2)
                        {
                            while (lstLine.Items.Count <= txt.Length - 2)
                                lstLine.Items.Add(lstLine.Items.Count + 1);
                        }
                    }
                }
                else
                {
                    if (txt.Length > 0 && lstLine.Items.Count >= 0)
                    {
                        int lines = 0;
                        lstLine.Items.Clear();
                        int i;
                        
                        for (i = 0; i <= txt.Length - 2; i++)
                        {
                            
                            lines = 0;
                            lines += txt[i].Length / 99;
                            if (txt[i].Length % 99 != 0)
                                lines += 1;
                                lstLine.Items.Add(i + 1);
                            for (int j = 1; j< lines; j++)
                            {
                                lstLine.Items.Add(" ");
                            }
                        }
                       
                    }
                }
            }
            tr = new TextRange(rtbInput.Document.ContentStart, rtbInput.Document.ContentEnd);
            
            if (tr.Text.Length == 0 && lstLine.Items.Count > 0)
            {
                while (lstLine.Items.Count > 0)
                    lstLine.Items.RemoveAt(lstLine.Items.Count - 1);
            }
        }

        private void highlight()
        {
            syntax();
            LineNumbers();
        }
             
        private int compare(tags t1, tags t2)
        {
            if (t1.start < t2.start)
                return 1;
            if (t1.start == t2.start)
                return 0;
            return -1;
        }

        private void rtbInput_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Space" || e.Key.ToString() == "Return")
            
            {
                if (cur_th != null && cur_th.IsAlive == true)
                {
                    cur_th.Abort();
                    cur_th = null;
                }
                cur_th = new Thread(new ThreadStart(
                                        delegate()
                                        {
                                            rtbInput.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                                                delegate()
                                                {
                                                    highlight();
                                                }));
                                        }));
                cur_th.IsBackground = true;
                cur_th.Start();
            }
            else if (e.Key.ToString() == "Left" || e.Key.ToString() == "Right" || e.Key.ToString() == "Down" || e.Key.ToString() == "Up")
            {
            }

            //Collaborative!!!!!!!!!!!!!!!!!!!!!!!
            if (cur_th != null && cur_th.IsAlive == true)
            {
                cur_th.Abort();

                cur_th = null;
            }
            TextPointer cur = rtbInput.CaretPosition;
            TextPointer start = rtbInput.CaretPosition.GetLineStartPosition(0);
            TextPointer end = rtbInput.Document.ContentEnd;
            TextRange tr = new TextRange(start, end);
            string s = tr.Text.ToString();
            if (s.IndexOf('\r') != -1)
                s = s.Substring(0, s.IndexOf('\r'));
            int total = rtbInput.Document.ContentStart.GetOffsetToPosition(start);
            TextRange ts = new TextRange(rtbInput.Document.ContentStart, start);
            int linenum = ts.Text.Split('\n').Length;
            linenum = linenum - 1;
            int modifier = 0;
            //if (prog != "")
                if (e.Key.ToString() == "Return")
                {
                    TextPointer tp = start.GetLineStartPosition(-1);
                    if (tp != null)
                    {
                        TextRange tp1 = new TextRange(tp, end);
                        string st = tp1.Text.ToString();
                        if (st.IndexOf('\r') != -1)
                        {
                            st = st.Substring(0, st.IndexOf('\r'));
                        }
                        string[] param = prog.Split('\n');
                        if (linenum != 0 && linenum <= param.Length - 1)
                        {
                            string temp = param[linenum - 1];
                            temp = temp.Substring(0, temp.IndexOf('\r'));
                            if (temp != st)
                            {
                                SM.sourceCodeChanged((linenum - 1).ToString(), st, "0", "");
                            }
                            modifier = 2;
                            SM.sourceCodeChanged(linenum.ToString(), s, modifier.ToString(), "");
                        }
                    }
                }
                else if ((e.Key.ToString() == "Back" || e.Key.ToString() == "Delete"))
                {
                    int presentlen = new TextRange(rtbInput.Document.ContentStart, rtbInput.Document.ContentEnd).Text.Split('\n').Length;
                    int originallen = prog.Split('\n').Length;
                    SM.sourceCodeChanged(linenum.ToString(), s, "0", "");
                    if (presentlen < originallen)
                    {
                        modifier = 1;
                        linenum = linenum + 1;
                        SM.sourceCodeChanged(linenum.ToString(), s, modifier.ToString(), "");
                    }
                }
                else
                {
                    SM.sourceCodeChanged(linenum.ToString(), s, "0", "");
                }
                tr = new TextRange(rtbInput.Document.ContentStart, rtbInput.Document.ContentEnd);
                prog = tr.Text;
                markLinepositions();
        }

        private void markLinepositions()
        {
            if (prog != "")
            {
                string[] temp = prog.Split('\n');
                m_user.Clear();
                for (int i = 0; i < editedNum.Keys.Count; i++)
                {
                    userhighlight u = new userhighlight();

                    int length = 0;
                    int x = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (temp[j].IndexOf('\r') != -1)
                            length += temp[j].Substring(0, temp[j].IndexOf('\r')).Length;
                        else
                            length += temp[j].Length;
                    }
                    u.start = length + (i) * 4 + 2;
                    u.name = (string)editedNum[i];
                    if (temp[i].IndexOf('\r') != -1)
                    {
                        u.size = temp[i].Substring(0, temp[i].IndexOf('\r')).Length;
                        m_user.Add(u);
                    }
                }
                userformat();
            }
        }

        private void userformat()
        {
            if (mnuHighlight.IsChecked)
                for (int i = 0; i < m_user.Count; i++)
                {
                    TextPointer str = rtbInput.Document.ContentStart.GetPositionAtOffset(m_user[i].start, LogicalDirection.Forward);
                    TextPointer stp = str.GetPositionAtOffset(m_user[i].size, LogicalDirection.Backward);
                    TextRange ts = new TextRange(str, stp);
                    ts.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Gray));
                }
        }

        private void update(string lno1, string s, string mod1, string uname)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            int lno = Int32.Parse(lno1);
                            int mod = Int32.Parse(mod1);
                            //if (prog != "")
                            //{
                                string[] param = prog.Split('\r');
                                int flag = 0;
                                int maxlen = 0;
                                //if(s!="")
                                if (mod != 1)
                                {
                                    Hashtable temp = new Hashtable();
                                    for (int k = 0; k < editedNum.Keys.Count && mod == 2; k++)
                                    {
                                        if (k >= lno)
                                        {
                                            string nam = (string)editedNum[k];
                                            editedNum.Remove(k);
                                            temp.Add(k + 1, nam);
                                        }
                                    }
                                    for (int k = 0; k < temp.Keys.Count; k++)
                                    {
                                        if (editedNum.ContainsKey(k))
                                            editedNum.Remove(k);
                                        editedNum.Add(k, temp[k]);
                                    }
                                    temp.Clear();
                                    if (editedNum.ContainsKey(lno))
                                        editedNum.Remove(lno);
                                    editedNum.Add(lno, uname);
                                }
                                else
                                {
                                    Hashtable temp = new Hashtable();
                                    for (int k = 0; k < editedNum.Keys.Count; k++)
                                    {
                                        if (k > lno)
                                        {
                                            string nam = (string)editedNum[k];
                                            editedNum.Remove(k);
                                            temp.Add(k - 1, nam);
                                        }
                                    }
                                    for (int k = 0; k < temp.Keys.Count; k++)
                                    {
                                        if (editedNum.ContainsKey(k))
                                            editedNum.Remove(k);
                                        editedNum.Add(k, temp[k]);
                                        temp.Remove(k);
                                    }
                                }
                                rtbInput.Document.Blocks.Clear();
                                int i;
                                maxlen = param.Length - 1;
                                for (i = 0; i < maxlen; i++)
                                {
                                    if (lno == i && mod == 1)
                                        continue;
                                    if (mod == 0 || mod == 1)
                                    {
                                        if (lno == i)
                                        {
                                            if (param[i].IndexOf('\n') != -1)
                                            {
                                                rtbInput.AppendText("\n" + s);
                                            }
                                            else
                                            {
                                                rtbInput.AppendText(s + "\r\n");
                                            }
                                            flag = 1;
                                        }
                                        else
                                        {
                                            rtbInput.AppendText(param[i].ToString());
                                        }
                                    }

                                    if (mod == 2)
                                    {
                                        if (lno == i)
                                        {
                                            if (param[i].IndexOf('\n') != -1)
                                            {
                                                rtbInput.AppendText("\n" + s);
                                            }
                                            else
                                            {
                                                rtbInput.AppendText(s + "\r\n");
                                            }
                                            flag = 1;
                                        }
                                        else if (i < lno)
                                        {
                                            rtbInput.AppendText(param[i].ToString());
                                        }
                                        else if (i > lno)
                                        {
                                            rtbInput.AppendText(param[i - 1].ToString());
                                        }
                                    }

                                }
                                if (flag == 0 && mod == 2)
                                {
                                    rtbInput.AppendText("\r\n" + s);
                                }
                                else
                                 if (flag == 0 && mod == 0)
                                 {
                                        rtbInput.AppendText(s);
                                 }
                                 else 
                                 if (flag == 1 && mod == 2)
                                    {
                                        rtbInput.AppendText(param[i - 1]);
                                    }
                                prog = new TextRange(rtbInput.Document.ContentStart, rtbInput.Document.ContentEnd).Text.ToString();
                            //}
                        }));
                }));
            t.Start();
        }

        private void ShowError(string Msg)
        {
            System.Windows.MessageBox.Show(Msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EnablePlot(PngBitmapEncoder encoder)
        {
            try
            {
                if (encoder != null)
                {
                    PBE = new PngBitmapEncoder();
                    PBE.Frames.Add(BitmapFrame.Create(encoder.Frames[0].Clone()));
                    isplotReady = 1;
                    System.IO.FileStream outStream = new System.IO.FileStream(plotpath, System.IO.FileMode.Create);
                    PBE.Save(outStream);
                    outStream.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Error in enable plot:" + e.Message);
            }
        }
            
        private void Display(string res)
        {
            Thread t = new Thread(new ThreadStart(
                delegate()
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                        delegate()
                        {
                            txtResult.Text += res;
                        }));
                }));
            t.Start();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            plot.terminate();
        }

        
        //***   ALL THE EVENTS  ***//
        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {
            mnuSave.Visibility = Visibility.Visible;
            mnuExit.Visibility = Visibility.Visible;
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            SM.programClosed();
            if (CloseProgramEvent != null)
                CloseProgramEvent(PID);
            Close();
        }

        private void mnuWrap_Click(object sender, RoutedEventArgs e)
        {
            if (rtbInput.HorizontalScrollBarVisibility == ScrollBarVisibility.Disabled)
            {
                rtbInput.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                rtbInput.Document.PageWidth = 20000;
                LineNumbers();
                syntax();
            }
            else
            {
                rtbInput.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                rtbInput.Document.PageWidth = rtbInput.Width;
                LineNumbers();
                syntax();
            }
        }

        private void mnuLine_Click(object sender, RoutedEventArgs e)
        {
            if (mnuLine.IsChecked)
                lstLine.Visibility = Visibility.Visible;
            else
                lstLine.Visibility = Visibility.Hidden;
        }

        private void mnuOption_Click(object sender, RoutedEventArgs e)
        {
            mnuLine.Visibility = Visibility.Visible;
            mnuWrap.Visibility = Visibility.Visible;
            mnuHighlight.Visibility = Visibility.Visible;
        }

        private void mnuAccess_Click(object sender, RoutedEventArgs e)
        {
            mnuEdit.Visibility = Visibility.Visible;
        }

        private void mnuAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.setUserList(swarmUserList);
            user.ShowDialog();
        }

        private void mnuEdit_Click(object sender, RoutedEventArgs e)
        {
            TextPointer start = rtbInput.Document.ContentStart;
            TextPointer end = rtbInput.Document.ContentEnd;
            TextRange tr = new TextRange(start, end);
            EditPermissions editPerm = new EditPermissions(SM, IP, Port, tr.Text, owner);
            editPerm.setUserList(swarmUserTable);
            editPerm.ShowDialog();
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser delUser = new DeleteUser();
            delUser.ShowDialog();
        }

        private void btnCompute_Click(object sender, RoutedEventArgs e)
        {
            if (SM.RunClicked(IP, Port))
            {
                txtResult.Text = "";
                isplotReady = 0;
                plotpath = Title;
                plotpath += ".png";
                TextPointer start = rtbInput.Document.ContentStart;
                TextPointer end = rtbInput.Document.ContentEnd;
                TextRange tr = new TextRange(start, end);
                Controller.clearCoreValues();
                worker.RunWorkerAsync(tr.Text);
                mnuPlot.IsEnabled = true;
            }
        }

        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "ssf files (*.ssf)|*.ssf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false);
                    using (sw)
                    {
                        TextPointer start = rtbInput.Document.ContentStart;
                        TextPointer end = rtbInput.Document.ContentEnd;
                        TextRange tr = new TextRange(start, end);
                        sw.Write(tr.Text.ToString());
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not Write file to disk. Original error: " + ex.Message);
                }
            }
        }

        private void mnuShowPlot_Click(object sender, RoutedEventArgs e)
        {
            if (isplotReady == 1)
            {
                ProgPlot frmPlot = new ProgPlot(plotpath);
                frmPlot.ShowDialog();
            }
            else
                System.Windows.MessageBox.Show("No Plot");
        }

        private void mnuSavePlot_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "png files (*.png)|*.png";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String tempPath = saveFileDialog1.FileName;

                    // create a file stream for saving image
                    using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
                    {
                        PBE.Save(outStream);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not Write file to disk. Original error: " + ex.Message);
                }
            }
        }

        public void send_close_msg()
        {
            SM.programClosed();
            //Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SM.programClosed();
            if (CloseProgramEvent != null)
                CloseProgramEvent(PID);
            //Close();
        }
    }
}