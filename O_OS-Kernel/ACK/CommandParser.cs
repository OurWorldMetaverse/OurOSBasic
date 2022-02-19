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
    public class Commands
    {
        public string ping { get; set; }
        public string isaiah { get; set; }
    }

    public class Root
    {
        public List<string> exclude { get; set; }
        public Commands Commands { get; set; }
    }




    class CommandParser
    {
        private static Root root = new();
        private const string ping = "ping";
        private const string isaiah = "isaiah";

        public static async Task CommandParserFunc()
        {
            await GetCommandAPI();
            while (Resources.KernelVars.isRunning == true)
            {
                await GetCommandAPI();
                Console.Write("[Usr]: ");
                switch (Console.ReadLine())
                {
                    case ping:
                        Console.WriteLine("[CMP]: " + root.Commands.ping);
                        break;
                    case isaiah:
                        Console.WriteLine("[CMP]: " + root.Commands.isaiah);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[CMP]: " + "ERROR INVALID COMMAND");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        public static async Task GetCommandAPI()
        {
            using var httpClient = new HttpClient();
            root = await httpClient.GetFromJsonAsync<Root>("https://raw.githubusercontent.com/OurWorldMetaverse/OurOSBasic/main/O_OS-Kernel/ACK/Resources/ACKCommands.json");
        }

    }
}
