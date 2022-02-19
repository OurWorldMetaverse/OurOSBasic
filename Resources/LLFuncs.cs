using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace OurOSBasic.Resources
{

    public class Commands
    {
        public string ping { get; set; }
        public string isaiah { get; set; }
        public string clear { get; set; }
    }

    public class Root
    {
        public List<string> exclude { get; set; }
        public Commands Commands { get; set; }
    }

    class LLFuncs
    {
        //Root instance
        public static Root root = new();

        public static async Task GetCommandAPI()
        {
            using var httpClient = new HttpClient();
            root = await httpClient.GetFromJsonAsync<Root>("https://raw.githubusercontent.com/OurWorldMetaverse/OurOSBasic/main/O_OS-Kernel/ACK/Resources/ACKCommands.json");
        }
    }
}
