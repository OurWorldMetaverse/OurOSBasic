using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using System.Threading;


namespace OurOSBasic.Resources
{
    class ACKCommandFuncs
    {
        private static byte[] dataArr;
        public static Form BabushkaDoggo;

        public static async Task Clear()
        {
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.clear);
            Console.Clear();
        }
        public static async Task Duggo()
        {
            Form BabushkaDoggo = new Forms.BabushkaDuggo();
            BabushkaDoggo.Text = "Babushka Duggo";
            BabushkaDoggo.BackgroundImage = Image.FromFile(@"D:\Resources\BabushkaDoggo.jpg");
            BabushkaDoggo.Show();
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.duggo);
            Thread.Sleep(2000);
            BabushkaDoggo.Dispose();
        }

    }
}
