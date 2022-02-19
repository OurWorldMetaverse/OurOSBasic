using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurOSBasic.O_OS_Kernel.ACK.ACK_Commands
{
    class Ping
    {
        public static void PingCMD()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pong");
        }
    }
}
