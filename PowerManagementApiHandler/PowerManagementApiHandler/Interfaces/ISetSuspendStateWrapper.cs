using System.Runtime.InteropServices;

namespace PowerManagementApiHandler.Interfaces
{
    [ComVisible(true)]
    [Guid("DA760838-53C5-41FA-946D-E990FF37C157")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ISetSuspendStateWrapper
    {
        bool SystemSuspend();
        bool SystemHibernate();
    }
}