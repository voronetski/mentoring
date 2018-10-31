using System.Runtime.InteropServices;
using Newtonsoft.Json;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandler.Classes
{
    [ComVisible(true)]
    [Guid("53970624-97D3-4A4B-9EAE-ADB3B2661C20")]
    [ClassInterface(ClassInterfaceType.None)]
    public class CallNtPowerInformationWrapper : ICallNtPowerInformationWrapper
    {
        public long GetLastSleepTime()
        {
            return CallNtPowerInformationHandler.GetPowerInformation<long>(CallNtPowerInformationHandler.PowerInformationLevel.LastSleepTime);
        }

        public long GetLastWakeTime()
        {
            return CallNtPowerInformationHandler.GetPowerInformation<long>(CallNtPowerInformationHandler.PowerInformationLevel.LastWakeTime);
        }

        public string GetSystemBatteryState()
        {
            return JsonConvert.SerializeObject(CallNtPowerInformationHandler.GetPowerInformation<CallNtPowerInformationHandler.SYSTEM_BATTERY_STATE>(CallNtPowerInformationHandler.PowerInformationLevel.SystemBatteryState));
        }

        public string GetSystemPowerInformation()
        {
            return JsonConvert.SerializeObject(CallNtPowerInformationHandler.GetPowerInformation<CallNtPowerInformationHandler.SYSTEM_POWER_INFORMATION>(CallNtPowerInformationHandler.PowerInformationLevel.SystemPowerInformation));
        }

        public void SetHibernationFile()
        {

        }

        public void DeleteHibernationFile()
        {

        }

    }
}
