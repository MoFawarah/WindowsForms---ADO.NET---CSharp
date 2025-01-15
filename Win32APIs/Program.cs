using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win32APIs
{
    internal class Program
    {
        // Struct to hold battery status information
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }

        // Importing the GetSystemPowerStatus function from kernel32.dll
        [DllImport("kernel32.dll")]
        private static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS lpSystemPowerStatus);


        static void Main(string[] args)
        {
            Console.WriteLine("Fetching battery information...");

            if (GetBatteryInfo(out var batteryStatus))
            {
                Console.WriteLine($"AC Line Status: {(batteryStatus.ACLineStatus == 1 ? "Online" : "Offline")}");
                Console.WriteLine($"Battery Status: {GetBatteryFlagDescription(batteryStatus.BatteryFlag)}");
                Console.WriteLine($"Battery Life Percentage: {batteryStatus.BatteryLifePercent}%");
                Console.WriteLine($"Battery Life Remaining: {batteryStatus.BatteryLifePercent}%");
                Console.WriteLine($"Battery Life Time: {(batteryStatus.BatteryLifeTime == -1 ? "Unknown" : $"{batteryStatus.BatteryLifeTime / 60} minutes")}");
                Console.WriteLine($"Battery Full Life Time: {(batteryStatus.BatteryFullLifeTime == -1 ? "Unknown" : $"{batteryStatus.BatteryFullLifeTime / 60} minutes")}");
            }
            else
            {
                Console.WriteLine("Failed to retrieve battery information.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static bool GetBatteryInfo(out SYSTEM_POWER_STATUS batteryStatus)
        {
            return GetSystemPowerStatus(out batteryStatus);
        }

        static string GetBatteryFlagDescription(byte batteryFlag)
        {
            if (batteryFlag == 255)
                return "No battery";
            string description = "";
            if ((batteryFlag & 1) != 0) description += "High, ";
            if ((batteryFlag & 2) != 0) description += "Low, ";
            if ((batteryFlag & 4) != 0) description += "Critical, ";
            if ((batteryFlag & 8) != 0) description += "Charging, ";
            if ((batteryFlag & 128) != 0) description += "No battery";
            return string.IsNullOrEmpty(description) ? "Unknown" : description.TrimEnd(',', ' ');
        }

    }


        
    }



