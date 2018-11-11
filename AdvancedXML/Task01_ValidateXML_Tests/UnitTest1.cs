using System;
using Task01_ValidateXML;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task01_ValidateXML_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(XmlValidator.IsXmlValid(@"..\..\..\books.xml", @"..\..\..\books.xsd", "http://library.by/catalog", @"..\..\..\error.txt"));
        }
    }
}
