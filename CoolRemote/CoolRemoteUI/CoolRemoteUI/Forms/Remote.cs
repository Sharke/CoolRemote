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


        public void RDP_Start(NetworkStream NS)
        {
           
            StreamReader SR = new StreamReader(NS);
            StreamWriter SW = new StreamWriter(NS);
            
            for (; ; )
            {
                char[] ByteData = new char[350208];
                SR.Read(ByteData, 0, 350208);
                string Data = new string(ByteData);
                string[] Delimeter = new string[] { "|***|" };
                string[] DataSplit = Data.Split(Delimeter, StringSplitOptions.None);
                if (DataSplit[0] == "REMOTEDATA")
                {
                    
                }

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