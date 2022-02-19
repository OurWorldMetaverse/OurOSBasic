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
        public static Root root = new();

        public static async Task CommandParserFunc()
        {
            while (!O_OS_Kernel.Kernel.isRunning)
            {
                await GetCommandAPI();

                if (Console.ReadLine() == "ping".ToLower())
                {
                    Console.WriteLine("[ISAIAH'S EDITION]: " + root.Commands.ping);
                }
                else if(Console.ReadLine() == "isaiah".ToLower())
                {
                    Console.WriteLine("[ISAIAH'S EDITION]: " + root.Commands.isaiah);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ISAIAH'S EDITION]: UNKNOWN COMMAND");
                    Console.ForegroundColor = ConsoleColor.White;
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
