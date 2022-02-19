using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics.PerformanceData;
using System.Management;
using System.Threading;

namespace OurOSBasic.O_OS_Boot
{

    public class BootKernel
    {
        public static Int64 TotalRamMB = PerformanceInfo.GetTotalMemoryInMiB();
        public static Int64 AvailableRamMB = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
        public static ManagementClass sysManage = new ManagementClass("win32_processor");
        public static ManagementObjectCollection sysCollection = sysManage.GetInstances();
        public static string CPUIDValue;
        public static float AvailableStorage;
        public static float TotalStorage;
        public static string BootCodeStr = "";
        private static bool BootSuccess;


        //Prints the total system memory, and the available system memory in MiB.
        public static void RamValues()
        {
            Console.WriteLine("TOTAL SYSTEM MEMORY (MiB): " + TotalRamMB);
            Console.WriteLine("  ");
            Console.WriteLine("AVAILABLE SYSTEM MEMORY (MiB): " + AvailableRamMB);
            Console.WriteLine("  ");
        }

        //Get's the total storage, and the available storage. Prints them to the console in Mib.
        public static void StorageValues()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach(DriveInfo d in allDrives)
            {
                Console.WriteLine("  ");
                Console.WriteLine($"TOTAL STORAGE SPACE IN {d.Name} (MiB): " + d.TotalSize / 1048576);
                Console.WriteLine("  ");
                Console.WriteLine($"AVAILABLE STORAGE SPACE IN {d.Name} (MiB): " + d.AvailableFreeSpace / 1048576);
                Console.WriteLine("  ");
            }
        }

        //Get's the CPUID and displays it in the console.
        public static void CPUID()
        {
            foreach (ManagementObject manageObj in sysCollection)
            {
                CPUIDValue = manageObj.Properties["processorID"].Value.ToString();
                break;
            }
            Console.WriteLine("  ");
            Console.WriteLine("CPUID: " + CPUIDValue);
            Console.WriteLine("  ");
        }

        //Main Function
        public static void Boot()
        {
            BeginBoot();
            RamValues();
            StorageValues();
            CPUID();
            while (!BootSuccess)
            {
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write("..");
                Thread.Sleep(200);
                Console.Write("...");
                Thread.Sleep(200);
                Console.Clear();
                Thread.Sleep(200);

                break;
            }
            BootMessage();
            EndBoot();
        }

        //Calculates the sum of AvailableRam and Available storage divided by 2. If it's equal or greater than 253455 then it boots, if it's less than 253455 then it failes, otherwise the error is unknown and it fails.
        public static int CalcBootCode()
        {
            float tempBootCode = AvailableRamMB + AvailableStorage / 2;

            if(tempBootCode > 5010)
            {
                BootSuccess = true;
                return 051;
            }
            else if(tempBootCode < 5010)
            {
                BootSuccess = false;
                return 150;
                Resources.KernelVars.isRunning = false;
            }
            else
            {
                BootSuccess = false;
                return 500;
                Resources.KernelVars.isRunning = false;
            }
        }

        //Detects the boot code and changes the boot message depending on it
        public static void BootMessage()
        {

            if (CalcBootCode() == 051)
            {
                BootCodeStr = "BOOT CODE: BOOT SUCCESS " + "(" + CalcBootCode() + ")";
                Console.WriteLine(BootCodeStr);
                Resources.KernelVars.isRunning = true;
            }
            else if (CalcBootCode() == 150)
            {
                BootCodeStr = "BOOT CODE: BOOT FAILURE " + "(" + CalcBootCode() + ")";
                Console.WriteLine(BootCodeStr);
            }
            else if(CalcBootCode() == 500)
            {
                BootCodeStr = "BOOT CODE: UNKNOWN ERROR " + "(" + CalcBootCode() + ")";
                Console.WriteLine(BootCodeStr);
            }
        }
        
        //Begins the boot, changes the console bg color to green, and the foreground to dark blue.
        public static void BeginBoot()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        //Changes the bg to black, the foreground to green, prints "Boot Completed...", and changed the foreground back to white.
        public static void EndBoot()
        {
            if (BootSuccess)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BOOTING NOW...");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("CAN NOT BOOT!!!");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(5000);
        }

        //Get's the Available RAM, and Total RAM
        public static class PerformanceInfo
        {
            [DllImport("psapi.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

            [StructLayout(LayoutKind.Sequential)]
            public struct PerformanceInformation
            {
                public int Size;
                public IntPtr CommitTotal;
                public IntPtr CommitLimit;
                public IntPtr CommitPeak;
                public IntPtr PhysicalTotal;
                public IntPtr PhysicalAvailable;
                public IntPtr SystemCache;
                public IntPtr KernelTotal;
                public IntPtr KernelPaged;
                public IntPtr KernelNonPaged;
                public IntPtr PageSize;
                public int HandlesCount;
                public int ProcessCount;
                public int ThreadCount;
            }

            public static Int64 GetPhysicalAvailableMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }

            public static Int64 GetTotalMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }

            public static Int64 GetTotalStorageInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }
        }



    }
}