using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurOSBasic.Resources
{
    class ACKCommandFuncs
    {
        public static async Task Clear()
        {
            Console.WriteLine("[CMP]: " + Resources.LLFuncs.root.Commands.clear);
            Console.Clear();
        }
    }
}
