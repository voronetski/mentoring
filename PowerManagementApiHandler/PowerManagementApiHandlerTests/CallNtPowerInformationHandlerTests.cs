using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerManagementApiHandler;
using PowerManagementApiHandler.Classes;
using PowerManagementApiHandler.Interfaces;

namespace PowerManagementApiHandlerTests
{
    [TestClass]
    public class CallNtPowerInformationHandlerTests
    {
        private readonly ICallNtPowerInformationWrapper callNtPowerInformationWrapper = new CallNtPowerInformationWrapper();


        [TestMethod]
        public void GetLastSleepTimeTest()
        {
            var time = callNtPowerInformationWrapper.GetLastSleepTime();
            Assert.IsTrue(time>0);
        }

        [TestMethod]
        public void GetLastWakeTimeTest()
        {
            var time = callNtPowerInformationWrapper.GetLastWakeTime();
            Assert.IsTrue(time > 0);
        }

        [TestMethod]
        public void GetSystemInformationTest()
        {
            var info = callNtPowerInformationWrapper.GetSystemPowerInformation();
            Assert.IsFalse(String.IsNullOrWhiteSpace(info));
        }

        [TestMethod]
        public void GetBatteryStateTest()
        {
            var state = callNtPowerInformationWrapper.GetSystemBatteryState();
            Assert.IsFalse(String.IsNullOrWhiteSpace(state));
        }

        [TestMethod]
        public void SetHibernationFileTest()
        {
            callNtPowerInformationWrapper.SetHibernationFile();
        }

        [TestMethod]
        public void DeleteHibernationFileTest()
        {
            callNtPowerInformationWrapper.DeleteHibernationFile();
        }
    }
}
