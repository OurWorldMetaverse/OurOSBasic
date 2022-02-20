using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using System.Data;
using System.Threading;
using Microsoft.Win32;

namespace OurOSBasic.Resources
{
    class ACKCommandFuncs
    {
        private static byte[] dataArr;

        private const string ChromeAppKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";

        private static string ChromeAppFileName
        {
            get
            {
                return (string)(Registry.GetValue("HKEY_LOCAL_MACHINE" + ChromeAppKey, "", null) ??
                                    Registry.GetValue("HKEY_CURRENT_USER" + ChromeAppKey, "", null));
            }
        }

        public static async Task Clear()
        {
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.clear);
            Console.Clear();
        }
        public static async Task Duggo()
        {
            Form BabushkaDoggo = new Forms.BabushkaDoggo();
            BabushkaDoggo.Text = "Babushka Duggo";
            BabushkaDoggo.BackgroundImage = Image.FromFile(@"D:\Resources\BabushkaDoggo.jpg");
            BabushkaDoggo.Show();
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.duggo);
            Thread.Sleep(2000);
            BabushkaDoggo.Dispose();
        }

        public static async Task Aidyn()
        {
            Form Kermit = new Forms.Kermit();
            Kermit.Text = "Kermit sees you >:D";
            Kermit.BackgroundImage = Image.FromFile(@"D:\Resources\Kermit.jpg");
            Kermit.Show();
            Console.WriteLine("[CMP]: " + LLFuncs.root.Commands.aidyn);
            Thread.Sleep(2000);
            Kermit.Dispose();
        }

        public static async Task upshot()
        {
            Console.WriteLine(@"NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNNNNNNWNNNNNNWNNWNNNNNN
NKxxxxxxxxxxxxxdxxxxxxxxxkOOOOkOOOOkO0kkOkkxkOOOOkOOOOOkOOOOkkOxxOOOOOOOOOkkkkxxxkkkxkkkkxxkkkkkkkKN
NOcclooollccloodxxxdxxxxxkkxkkkOkkkxkOxxkkxdxOkkkxkkkkkxkkxkxxxodkkkkkkkkkxxddddddddlllc::clccclclkN
NOlodooollllddxK0xkkxkkx00kkOxxxxxxxxkxxkOxxxxkkkxdxxxkxxkkxxdxk0kkkxkkxkkxkxxkO0k0KklcolllloolollkN
Nkcoold0klloodkKKxxxdxxxk0kxkxxdxxxddxddxkxoddxxdolddoddodxdoookOdddoddoddoddooxkddOOdloolcd0klllckN
NkldocdKOoodlok0KXXXX0000KK0000K000KKKKK0K00000K0OO0000000K0KKKXXKKKKKKKKKKKKKKXXKKK0xolloldKklolckN
NkoxdcdKOllooodkOKXKK000OO00OO0000O0KXX0xdoollloodddollooodxOXNXKXXKKKKKXXXKKKKKXXKXX0dlclldKklllcON
NkcolcoxxllokkkKNXXXXXXNXNXXXXNNNNNNNNX0Odc:cldOO0K0Odc;:cdk0XNK0KK00000000KK0000K0KNKkxolcoxdlllckN
NkclolcccloOXXXNNXNNXKOkkO0XNNNNNNNNNNNKxc;codxkO00000Oo;;lxKNNXXNNXKKK0KK0KKKKKKXXNNXKK0xlcccllcckN
Nkc:llodoxOKNX0KXXNKxodxxdox0XNNNNNNNNXOl;:loddddddxkkddo;;lOXNXNNNXK000OkOOOOO00KXNX0XNX0ocllllloON
Nkccllodx0XKXXO0XXXxlxOkxOxld0NNNNNNNNKo;;:loddodxkxxxxddc;:dKNNNNNX0KOxdllooxk0K0XN0kKNXKkxxoooooON
NOloollxKNNNNXXXXNXxcdOkxkklo0NXNNNNNXOc,;;;;cllokOkdxkocc;;lONNNNNKOkdlddlooloOXXXXXXXNXXKkxollclON
Nk:cllokXXNNNNNXNNX0doddddodOXNNNNNNNXk:,;:::cccldxkkkxl::::lOXNNNNKkdlldkdoollkKXNXXXXXXX0xdc:c:cON
NkcclodkXNNNNXXXXXXXK0OxxkOKXNNXNNNNNXOc,;;;;:llccclddl::::;lOXNNNNKOkoclxxlclo0XXXNNNNXNNX0xc:lolON
NkcclcckXNNNXO00000O00000K0000KKKNNNNXOl;;;;;;:loooxOd::::;;oOXNNNNXKK0doododxOKK0XNNNXKKXNXkc:cclON
Nkc::codk0XNXKXXKXXXXXKKXXXKKXXXXNNNN0xo:;:;;::lxkO0Ooccc:;cdx0XNNNNNXXXXKKKXXXXXXNNNNXXXXKOxoc::cON
NkclloxdookXN0OXNKKXXKKXKKKKXKKXNNNX0koll:;;;;;:oddxOkdccclllokKXK00KXXXXXXXXXXXXXNNN00XXkddddooclON
NkclloOklooOX00XX00KK00K0OOKK0OKNNX0xoolllc;;;;;:lodkOxlclllllox0KOOKK00OOKKXK0000KXX00XOoldOxlollON
NkcoolkxlodOXKKKKK0KKK00K00K0xdxxxxdollllloccccclloooddolllccllloxxxddk000KKK00KKKXXXXXXOdooOdcoooON
Nkccodooddoddxddddododddddddolcoxdddoxolxdlcdxddxxddxdxocxxccdxldxxdclodddddxxdddddddxxdoddddoodll0N
N0xxxO0OOkxkkkkkkxxxxxkkxkkkxxxkkkxxxxxxxxxxkkxxkkkkxkkxxxxxxxkxkxxxxxxxxxxxxxxxdddxdxxxddkOOkkxoxKN
NNNWNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNXNNNNNN");
            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(200);
            Console.WriteLine(@"NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNNNNNNWNNNNNNWNNWNNNNNN
NKxxxxxxxxxxxxxdxxxxxxxxxkOOOOkOOOOkO0kkOkkxkOOOOkOOOOOkOOOOkkOxxOOOOOOOOOkkkkxxxkkkxkkkkxxkkkkkkkKN
NOcclooollccloodxxxdxxxxxkkxkkkOkkkxkOxxkkxdxOkkkxkkkkkxkkxkxxxodkkkkkkkkkxxddddddddlllc::clccclclkN
NOlodooollllddxK0xkkxkkx00kkOxxxxxxxxkxxkOxxxxkkkxdxxxkxxkkxxdxk0kkkxkkxkkxkxxkO0k0KklcolllloolollkN
Nkcoold0klloodkKKxxxdxxxk0kxkxxdxxxddxddxkxoddxxdolddoddodxdoookOdddoddoddoddooxkddOOdloolcd0klllckN
NkldocdKOoodlok0KXXXX0000KK0000K000KKKKK0K00000K0OO0000000K0KKKXXKKKKKKKKKKKKKKXXKKK0xolloldKklolckN
NkoxdcdKOllooodkOKXKK000OO00OO0000O0KXX0xdoollloodddollooodxOXNXKXXKKKKKXXXKKKKKXXKXX0dlclldKklllcON
NkcolcoxxllokkkKNXXXXXXNXNXXXXNNNNNNNNX0Odc:cldOO0K0Odc;:cdk0XNK0KK00000000KK0000K0KNKkxolcoxdlllckN
NkclolcccloOXXXNNXNNXKOkkO0XNNNNNNNNNNNKxc;codxkO00000Oo;;lxKNNXXNNXKKK0KK0KKKKKKXXNNXKK0xlcccllcckN
Nkc:llodoxOKNX0KXXNKxodxxdox0XNNNNNNNNXOl;:loddddddxkkddo;;lOXNXNNNXK000OkOOOOO00KXNX0XNX0ocllllloON
Nkccllodx0XKXXO0XXXxlxOkxOxld0NNNNNNNNKo;;:loddodxkxxxxddc;:dKNNNNNX0KOxdllooxk0K0XN0kKNXKkxxoooooON
NOloollxKNNNNXXXXNXxcdOkxkklo0NXNNNNNXOc,;;;;cllokOkdxkocc;;lONNNNNKOkdlddlooloOXXXXXXXNXXKkxollclON
Nk:cllokXXNNNNNXNNX0doddddodOXNNNNNNNXk:,;:::cccldxkkkxl::::lOXNNNNKkdlldkdoollkKXNXXXXXXX0xdc:c:cON
NkcclodkXNNNNXXXXXXXK0OxxkOKXNNXNNNNNXOc,;;;;:llccclddl::::;lOXNNNNKOkoclxxlclo0XXXNNNNXNNX0xc:lolON
NkcclcckXNNNXO00000O00000K0000KKKNNNNXOl;;;;;;:loooxOd::::;;oOXNNNNXKK0doododxOKK0XNNNXKKXNXkc:cclON
Nkc::codk0XNXKXXKXXXXXKKXXXKKXXXXNNNN0xo:;:;;::lxkO0Ooccc:;cdx0XNNNNNXXXXKKKXXXXXXNNNNXXXXKOxoc::cON
NkclloxdookXN0OXNKKXXKKXKKKKXKKXNNNX0koll:;;;;;:oddxOkdccclllokKXK00KXXXXXXXXXXXXXNNN00XXkddddooclON
NkclloOklooOX00XX00KK00K0OOKK0OKNNX0xoolllc;;;;;:lodkOxlclllllox0KOOKK00OOKKXK0000KXX00XOoldOxlollON
NkcoolkxlodOXKKKKK0KKK00K00K0xdxxxxdollllloccccclloooddolllccllloxxxddk000KKK00KKKXXXXXXOdooOdcoooON
Nkccodooddoddxddddododddddddolcoxdddoxolxdlcdxddxxddxdxocxxccdxldxxdclodddddxxdddddddxxdoddddoodll0N
N0xxxO0OOkxkkkkkkxxxxxkkxkkkxxxkkkxxxxxxxxxxkkxxkkkkxkkxxxxxxxkxkxxxxxxxxxxxxxxxdddxdxxxddkOOkkxoxKN
NNNWNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNXNNNNNN");
            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(200);
            Console.WriteLine(@"NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNWNNNNNNWNNNNNNWNNWNNNNNN
NKxxxxxxxxxxxxxdxxxxxxxxxkOOOOkOOOOkO0kkOkkxkOOOOkOOOOOkOOOOkkOxxOOOOOOOOOkkkkxxxkkkxkkkkxxkkkkkkkKN
NOcclooollccloodxxxdxxxxxkkxkkkOkkkxkOxxkkxdxOkkkxkkkkkxkkxkxxxodkkkkkkkkkxxddddddddlllc::clccclclkN
NOlodooollllddxK0xkkxkkx00kkOxxxxxxxxkxxkOxxxxkkkxdxxxkxxkkxxdxk0kkkxkkxkkxkxxkO0k0KklcolllloolollkN
Nkcoold0klloodkKKxxxdxxxk0kxkxxdxxxddxddxkxoddxxdolddoddodxdoookOdddoddoddoddooxkddOOdloolcd0klllckN
NkldocdKOoodlok0KXXXX0000KK0000K000KKKKK0K00000K0OO0000000K0KKKXXKKKKKKKKKKKKKKXXKKK0xolloldKklolckN
NkoxdcdKOllooodkOKXKK000OO00OO0000O0KXX0xdoollloodddollooodxOXNXKXXKKKKKXXXKKKKKXXKXX0dlclldKklllcON
NkcolcoxxllokkkKNXXXXXXNXNXXXXNNNNNNNNX0Odc:cldOO0K0Odc;:cdk0XNK0KK00000000KK0000K0KNKkxolcoxdlllckN
NkclolcccloOXXXNNXNNXKOkkO0XNNNNNNNNNNNKxc;codxkO00000Oo;;lxKNNXXNNXKKK0KK0KKKKKKXXNNXKK0xlcccllcckN
Nkc:llodoxOKNX0KXXNKxodxxdox0XNNNNNNNNXOl;:loddddddxkkddo;;lOXNXNNNXK000OkOOOOO00KXNX0XNX0ocllllloON
Nkccllodx0XKXXO0XXXxlxOkxOxld0NNNNNNNNKo;;:loddodxkxxxxddc;:dKNNNNNX0KOxdllooxk0K0XN0kKNXKkxxoooooON
NOloollxKNNNNXXXXNXxcdOkxkklo0NXNNNNNXOc,;;;;cllokOkdxkocc;;lONNNNNKOkdlddlooloOXXXXXXXNXXKkxollclON
Nk:cllokXXNNNNNXNNX0doddddodOXNNNNNNNXk:,;:::cccldxkkkxl::::lOXNNNNKkdlldkdoollkKXNXXXXXXX0xdc:c:cON
NkcclodkXNNNNXXXXXXXK0OxxkOKXNNXNNNNNXOc,;;;;:llccclddl::::;lOXNNNNKOkoclxxlclo0XXXNNNNXNNX0xc:lolON
NkcclcckXNNNXO00000O00000K0000KKKNNNNXOl;;;;;;:loooxOd::::;;oOXNNNNXKK0doododxOKK0XNNNXKKXNXkc:cclON
Nkc::codk0XNXKXXKXXXXXKKXXXKKXXXXNNNN0xo:;:;;::lxkO0Ooccc:;cdx0XNNNNNXXXXKKKXXXXXXNNNNXXXXKOxoc::cON
NkclloxdookXN0OXNKKXXKKXKKKKXKKXNNNX0koll:;;;;;:oddxOkdccclllokKXK00KXXXXXXXXXXXXXNNN00XXkddddooclON
NkclloOklooOX00XX00KK00K0OOKK0OKNNX0xoolllc;;;;;:lodkOxlclllllox0KOOKK00OOKKXK0000KXX00XOoldOxlollON
NkcoolkxlodOXKKKKK0KKK00K00K0xdxxxxdollllloccccclloooddolllccllloxxxddk000KKK00KKKXXXXXXOdooOdcoooON
Nkccodooddoddxddddododddddddolcoxdddoxolxdlcdxddxxddxdxocxxccdxldxxdclodddddxxdddddddxxdoddddoodll0N
N0xxxO0OOkxkkkkkkxxxxxkkxkkkxxxkkkxxxxxxxxxxkkxxkkkkxkkxxxxxxxkxkxxxxxxxxxxxxxxxdddxdxxxddkOOkkxoxKN
NNNWNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNXNNNNNN");
            Thread.Sleep(200);
            Console.Clear();
        }

        public static async Task FakeMath()
        {
            string chromeAppFileName = ChromeAppFileName;
            if (string.IsNullOrEmpty(chromeAppFileName))
            {
                throw new Exception("Could not find chrome.exe!");
            }
            Process.Start(chromeAppFileName, "https://ourworldmetaverse.xyz/");
        }
    }
}
