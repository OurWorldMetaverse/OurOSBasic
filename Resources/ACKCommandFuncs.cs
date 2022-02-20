using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;


namespace OurOSBasic.Resources
{
    class ACKCommandFuncs
    {
        public static async Task Clear()
        {
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.clear);
            Console.Clear();
        }
        public static async Task Duggo()
        {
            Image BabushkaDog = Image.FromFile("./Img/Babushka Dog.jpg");
            Console.WriteLine(BabushkaDog.Size);
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.duggo);
        }
    }
}
