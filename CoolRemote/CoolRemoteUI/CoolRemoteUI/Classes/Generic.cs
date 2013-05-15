using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace WindowsFormsApplication1.Classes
{//Generic reusable functions
    public class Generic
    {
        //Dll imports
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        
        //Gets current active window title
        public static string GetActiveWindowTitle()
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

        public static string listen()
        {
            string Data = null;
           
            while (Data == null)
            {
              //  Data = SR.ReadLine();
            }

            return Data;
        }


    }
}
