using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Json;
using OurOSBasic.O_OS_Kernel;

namespace OurOSBasic.O_OS_Kernel
{

    class Kernel
    {

        public static async Task Main()
        {
            O_OS_Boot.BootKernel.Boot();
            Thread.Sleep(3000);
            Initialize();
            await CommandListenerImpl();
        }

        public static async Task CommandListenerImpl()
        {
            await O_OS_Kernel.ACK.CommandParser.CommandParserFunc();
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
