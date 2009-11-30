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
using System.Windows.Shapes;
using System.Threading;

namespace Spinach
{
    /// <summary>
    /// Interaction logic for EditPermissions.xaml
    /// </summary>
    public partial class EditPermissions : Window
    {
        private Dictionary<string, string> swarmUserTable = new Dictionary<string, string>();
        private string ipPort = "";
        private string myIP = "", myPort = "", programText = "";
        string owner;
        SwarmMemory SM;

        public EditPermissions(SwarmMemory sm, string ip, string port, string text, string uname)
        {
            InitializeComponent();
            SM = sm;
            myIP = ip;
            myPort = port;
            programText = text;
            owner = uname;
            chkRead.IsEnabled = false;
            chkWrite.IsEnabled = false;
            btnGrant.IsEnabled = false;
            btnCngOwner.IsEnabled = false;
        }

        public void setUserList(Dictionary<string, string> suTable)
        {
            cbUser.Items.Clear();
            swarmUserTable = suTable;
            foreach (string s in swarmUserTable.Values)
            {
                if(!(s == owner))
                    cbUser.Items.Add(s);
            }
            //cbUser.SelectedIndex = 0;
        }

        private void btnGrant_Click(object sender, RoutedEventArgs e)
        {
            if (chkRead.IsEnabled)
            {
                if (chkRead.IsChecked == true)
                {
                    string read = "true";
                    string write = "false";
                    if (chkWrite.IsChecked == true)
                        write = "true";
                    if (cbUser.Text != "")
                    {
                        SM.addPermissionRequest(myIP, myPort, programText, ipPort, read, write);
                    }
                    else
                        MessageBox.Show("Please select a user");
                    Close();
                }
            }
            else if (chkWrite.IsEnabled && chkWrite.IsChecked == true)
            {
                string read = "true";
                string write = "true";
                if (cbUser.Text != null)
                {
                    SM.changePermissionRequest(myIP, myPort, ipPort, read, write);
                }
                else
                    MessageBox.Show("Please select a user");
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCngOwner.IsEnabled = true;
            string uname = (string)cbUser.SelectedItem;
            
            foreach (KeyValuePair<string, string> temp in swarmUserTable)
            {
                if (temp.Value == uname)
                {
                    ipPort = temp.Key;
                    break;
                }
            }
            string[] perm = SM.getOnePermission(ipPort);
            if (perm != null)
            {
                chkRead.IsEnabled = true;
                chkRead.IsChecked = false;
                chkWrite.IsEnabled = true;
                chkWrite.IsChecked = false;
                btnGrant.IsEnabled = true;
                if (perm[0] == "true")
                {
                    chkRead.IsChecked = true;
                    chkRead.IsEnabled = false;
                }
                if (perm[1] == "true")
                {
                    chkWrite.IsChecked = true;
                    chkWrite.IsEnabled = false;
                }
                if (perm[0] == "true" && perm[1] == "true")
                    btnGrant.IsEnabled = false;
                if (perm[0] == "false" && perm[1] == "false")
                    btnGrant.IsEnabled = false;
            }
        }

        private void chkWrite_Checked(object sender, RoutedEventArgs e)
        {
            if (chkRead.IsEnabled)
                chkRead.IsChecked = true;
            btnGrant.IsEnabled = true;
        }

        private void chkRead_Checked(object sender, RoutedEventArgs e)
        {
            if (chkWrite.IsChecked == true)
                chkRead.IsChecked = true;
            btnGrant.IsEnabled = true;
        }

        private void btnCngOwner_Click(object sender, RoutedEventArgs e)
        {
            string user = cbUser.SelectedItem.ToString();
            
            string[] perm = SM.getOnePermission(ipPort);
            if (perm[0] == "false" && perm[1] == "false")
            {
                SM.addPermissionRequest(myIP, myPort, programText, ipPort, "true", "true");
                Thread.Sleep(2000);
                SM.changeTheOwner(ipPort, myIP, myPort);
            }
            else
            {
                SM.changePermissionRequest(myIP, myPort, ipPort, "true", "true");
                Thread.Sleep(2000);
                SM.changeTheOwner(ipPort, myIP, myPort);
            }
            this.Close();
        }

        private void chkRead_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkWrite.IsChecked == true)
                chkWrite.IsChecked = false;
            btnGrant.IsEnabled = false;
        }

        private void chkWrite_Unchecked(object sender, RoutedEventArgs e)
        {
            //btnSubmit.IsEnabled = false;
        }
    }
}
