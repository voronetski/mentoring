using System.Runtime.InteropServices;
using PowerManagementApiHandler.Classes;

namespace PowerManagementApiHandler.Interfaces
{
    [ComVisible(true)]
    [Guid("9A9648F8-71BE-4342-AFCA-5A3A3D1D5E65")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICallNtPowerInformationWrapper
    {
        long GetLastSleepTime();
        long GetLastWakeTime();
        void SetHibernationFile();
        void DeleteHibernationFile();
        string GetSystemBatteryState();
        string GetSystemPowerInformation();
    }
}