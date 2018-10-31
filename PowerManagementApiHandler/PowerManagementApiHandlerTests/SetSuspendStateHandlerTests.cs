using System;
using PowerManagementApiHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerManagementApiHandler.Classes;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandlerTests
{
    [TestClass]
    public class SetSuspendStateHandlerTests
    {
        private static readonly ISetSuspendStateWrapper setSuspendStateWrapper = new SetSuspendStateWrapper();

        [TestMethod]
        public void SystemSuspendTest()
        {
            var result = setSuspendStateWrapper.SystemSuspend();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SystemHibernateTest()
        {
            var result = setSuspendStateWrapper.SystemHibernate();
            Assert.IsTrue(result);
        }
    }
}
