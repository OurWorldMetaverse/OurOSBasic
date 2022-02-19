using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace OurOSBasic.O_OS_Kernel.ACK
{
    internal class Commands
    {
        public string Command { get; set; }
        public short Response { get; set; }

        public override string ToString()
        {
            return $"{Command,20}: {Response} contributions";
        }
    }


    class CommandParser
    {
        private static System.Text.Json.JsonElement root;
        private static System.Text.Json.JsonElement.ArrayEnumerator elems;

        public static async void CommandParserFunc()
        {
            var client = new RestClient("https://github.com");

            var request = new RestRequest("OurWorldMetaverse/OurOSBasic/blob/main/O_OS-Kernel/ACK/Resources/ACKCommands.json", Method.Get);
            // Add HTTP headers
            request.AddHeader("User-Agent", "Nothing");

            // Execute the request and automatically deserialize the result.
            var contributors = client.ExecuteAsync<List<Commands>>(request);
            Console.Write(contributors.Result.Data);


        }

    }
}
