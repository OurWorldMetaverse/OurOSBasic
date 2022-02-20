using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace OurOSBasic.O_OS_Kernel.ACK
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);




    class CommandParser
    {

        public static async Task CommandParserFunc()
        {
            await Resources.LLFuncs.GetCommandAPI();
            while (Resources.KernelVars.isRunning == true)
            {
                await Resources.LLFuncs.GetCommandAPI();
                switch (Console.ReadLine())
                {
                    case Resources.KernelVars.ping:
                        Console.WriteLine("[CMP]: " + Resources.LLFuncs.root.Commands.ping);
                        Console.Write("[Usr]: ");
                        break;
                    case Resources.KernelVars.isaiah:
                        Console.WriteLine("[CMP]: " + Resources.LLFuncs.root.Commands.isaiah);
                        Console.Write("[Usr]: ");
                        break;
                    case Resources.KernelVars.clear:
                        await Resources.ACKCommandFuncs.Clear();
                        Console.Write("[Usr]: ");
                        break;
                    case Resources.KernelVars.duggo:
                        await Resources.ACKCommandFuncs.Duggo();
                        Console.Write("[Usr]: ");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[CMP]: " + "ERROR INVALID COMMAND");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[Usr]: ");
                        break;
                }
            }
        }

    }
}
