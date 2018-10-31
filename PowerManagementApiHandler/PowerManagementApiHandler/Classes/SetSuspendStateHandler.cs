using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandler.Classes
{
    internal class SetSuspendStateHandler
    {
        [DllImport("PowrProf.dll", EntryPoint = "SetSuspendState", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool SetSuspendState(
            bool hibernate,
            bool forceCritical,
            bool disableWakeEvent);
    }


}
