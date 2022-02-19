using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OurOSBasic.O_OS_Kernel;

namespace OurOSBasic.O_OS_Kernel
{
    class Kernel
    {
        public static bool isRunning = false;

        public static void Main()
        {
            O_OS_Boot.BootKernel.Boot();
            Thread.Sleep(3000);
            Initialize();
            while (isRunning)
            {
                ACK.CommandParser.CommandParserFunc();
                Console.WriteLine("TEST");
            }
        }

        public static void Initialize()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "INITIALIZING OUROS BASIC EDITION 2022"));
        }
    }
}
