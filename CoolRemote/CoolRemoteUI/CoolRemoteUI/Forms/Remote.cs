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
        //NetworkStream NS;
        //StreamWriter SW;
        //StreamReader SR;
        public Remote(StreamReader SRP, StreamWriter SWP)
        {
            InitializeComponent();
           // NS = NSP;
            //StreamWriter SW = new StreamWriter(NS);
            //SW.WriteLine("RDP");
            //SW.Flush();
            Thread Doet = new Thread(() => RDP_Start(SRP,SWP));
            Doet.Start();
        }


        public void RDP_Start(StreamReader SRP,StreamWriter SWP)
        {

            SWP.WriteLine("RDP");
            SWP.Flush();
            string[] Delimeter = new string[] { "REMOTEDATA|***|" };
            string[] ParsedData;
            for (; ; )
            {

                ParsedData = SRP.ReadLine().Split(Delimeter, StringSplitOptions.None);
                pictureBox1.Image = ByteToImage(Convert.FromBase64String(ParsedData[1]));


            }

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
           
        }

       
    }
}