using System;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandler.Classes
{
    internal class CallNtPowerInformationHandler
    {
        [DllImport("PowrProf.dll", EntryPoint = "CallNtPowerInformation", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CallNtPowerInformation(
            PowerInformationLevel informationLevel,
            [In]IntPtr lpInputBuffer,
            uint nInputBufferSize,
            [In, Out]IntPtr lpOutputBuffer,
            uint nOutputBufferSize);


        internal enum PowerInformationLevel
        {
            LastSleepTime = 15,
            LastWakeTime = 14,
            SystemPowerInformation = 12,
            SystemReserveHiberFile = 10,
            SystemBatteryState = 5,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_POWER_INFORMATION
        {
            public ulong MaxIdlenessAllowed;
            public ulong Idleness;
            public ulong TimeRemaining;
            public byte CoolingMode;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_BATTERY_STATE
        {
            bool AcOnLine;
            bool BatteryPresent;
            bool Charging;
            bool Discharging;
            bool[] Spare1;
            byte Tag;
            ulong MaxCapacity;
            ulong RemainingCapacity;
            ulong Rate;
            ulong EstimatedTime;
            ulong DefaultAlert1;
            ulong DefaultAlert2;
        }

        internal static T GetPowerInformation<T>(PowerInformationLevel informationLevel)
        {
            IntPtr powerInformation = IntPtr.Zero;
            try
            {
                powerInformation = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(T)));

                int ntStatus = CallNtPowerInformation(informationLevel, IntPtr.Zero, 0, powerInformation,
                    (uint)Marshal.SizeOf(typeof(T)));

                if (ntStatus != 0) return default(T);

                // receives a ULONGLONG that specifies the interrupt-time count, in 100-nanosecond units, at the last system sleep time
                // there are 1e9 nanoseconds in a second, so there are 1e7 100 - nanoseconds in a second

                //long lastSleepTimeInSeconds = Marshal.ReadInt64(informationTime, 0) / 10000000;
                

                return (T)ProcessResult<T>(powerInformation);
            }
            finally
            {
                if (powerInformation != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(powerInformation);
            }
        }

        private static object ProcessResult<T>(IntPtr result)
        {
            return (Type.GetTypeCode(typeof(T)) == TypeCode.Int64) 
                ? Marshal.ReadInt64(result, 0) / 10000000 
                : Marshal.PtrToStructure(result, typeof(T));
        }


    }
}
