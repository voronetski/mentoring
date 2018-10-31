using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandler.Classes
{
    [ComVisible(true)]
    [Guid("5BC096D3-4941-468C-A386-37F02F619F30")]
    [ClassInterface(ClassInterfaceType.None)]
    public class SetSuspendStateWrapper : ISetSuspendStateWrapper
    {
        public bool SystemSuspend()
        {
            return SetSuspendStateHandler.SetSuspendState(false, false, false);
        }

        public bool SystemHibernate()
        {
            return SetSuspendStateHandler.SetSuspendState(true, false, false);
        }
    }


}
