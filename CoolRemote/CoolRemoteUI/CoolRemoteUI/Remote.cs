using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
namespace WindowsFormsApplication1
{
    public partial class Remote : DevComponents.DotNetBar.OfficeForm
    {

        public Remote(NetworkStream NS)
        {
            InitializeComponent();
            StreamWriter SW = new StreamWriter(NS);
            SW.WriteLine("RDP");
            SW.Flush();
            Thread Doet = new Thread(() => RDP_Start(NS));
            Doet.Start();
        }


        void RDP_Start(NetworkStream NS)
        {
           
            StreamReader SR = new StreamReader(NS);
            StreamWriter SW = new StreamWriter(NS);
            
            for (; ; )
            {
                string Data = SR.ReadLine();
               
                if (Data != null)
                {
                    int Size = Convert.ToInt32(Data);
                    byte[] ImgByte = new byte[Size];
                    SW.WriteLine("OK");
                    SW.Flush();
                    NS.Read(ImgByte, 0, ImgByte.Length);
                    File.WriteAllText("C:\\TESTINGBYTES.txt",Convert.ToBase64String(ImgByte));
                    pictureBox1.Image = ByteToImage(ImgByte);
                    Thread.Sleep(1000);
                }

            }
           // byte[] imgByte = new byte[32768];
            //NS.Read(imgByte, 0, imgByte.Length);
            //while (NS.DataAvailable)
            //{
            //    pictureBox1.Image = ByteToImage(imgByte);
           // }
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

        private void Remote_Load(object sender, EventArgs e)
        {
           
            //Main newmain = new Main();
            //NetworkStream Net = newmain.NSArray[1];
            //RDP_Start(Net);
        }

       
    }
}