using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Classes
{
    class Connection
    {
        static NetworkStream NS;
        static StreamWriter SW;
        static StreamReader SR;
        static NetworkStream[] NSArray;
        static TcpListener TCPListen;
        static Socket TCPSocket =  new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        static int IDNum = 1;

        static bool AcceptConnections(int Port)
        {
            TCPListen = new TcpListener(System.Net.IPAddress.Any, Port); 
            TCPListen.Start();
            TCPSocket = TCPListen.AcceptSocket();

            if (InitializeStream())
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private static bool InitializeStream()
        {
            try
            {
                NS = new NetworkStream(TCPSocket);
                SW = new StreamWriter(NS);
                SR = new StreamReader(NS);
                NSArray[IDNum] = NS;
                IDNum++;
                return true;
            }

            catch { return false; }

        }
        
        public static void Disconnect(NetworkStream[] NSArray, StreamWriter[] SWArray, StreamReader[] SRArray)
        {
            try
            {
                for (int i = 0; i < NSArray.Length; i++)
                {
                    NSArray[i].Dispose();
                }
            }

            catch {}
            
            for (int i = 0; i < SWArray.Length; i++)
            {
                try
                {

                    SWArray[i].Dispose();
                }

                catch {}
            }

            for (int i = 0; i < SRArray.Length; i++)
            {
                try
                {
                    SRArray[i].Dispose();
                }

                catch {}
            }
        }

        class StreamListener
        {
            static void Start()
            {

            }

            static void Stop()
            {

            }

        }
    }
}
