using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace OurOSBasic.O_OS_Kernel.ACK
{
    class CommandParser
    {

        public static string enteredCommand;
        public static ResourceManager rm = new ResourceManager("./Resources/ACKCommands.resx", Assembly.GetExecutingAssembly());
        public static string ping = rm.GetString("CMD_PING", CultureInfo.CurrentCulture);

        public static void CommandParserFunc()
        {
            if(Console.ReadLine() == ping.ToLower())
            {
                Console.WriteLine("Pong");
            }
        }
    }
}
