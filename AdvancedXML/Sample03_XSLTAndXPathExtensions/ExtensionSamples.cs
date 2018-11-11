using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Xsl;
using System.Diagnostics;
using System.Xml.XPath;
using System.Xml;

namespace Sample03_XSLTAndXPathExtensions
{
    [TestClass]
    public class ExtensionSamples
    {
        [TestMethod]
        public void XslEmbeddedFunction()
        {
            var xsl = new XslCompiledTransform();
            var settings = new XsltSettings { EnableScript = true };
            xsl.Load("01_EmbeddedFunctions.xslt", settings, null);
            
            xsl.Transform("CDCatalog1.xml", null, Console.Out);
        }

        [TestMethod]
        public void XslExtensionObjects()
        {
            var xsl = new XslCompiledTransform();
            var args = new XsltArgumentList();
            args.AddExtensionObject("http://epam.com/xsl/ext", new Counters());

            xsl.Load("02_ExtensionObjects.xslt");

            xsl.Transform("CDCatalog1.xml", args, Console.Out);
        }


        [TestMethod]
        public void XslContext_XPath()
        {
            XPathDocument document = new XPathDocument("CDCatalog1.xml");
            XPathNavigator navigator = document.CreateNavigator();
            XsltContextExtension.XsltContext context = 
                new XsltContextExtension.XsltContext();
            context.AddNamespace("my", "http://epam.com/xsl/ext");

            var s = (string)navigator.Evaluate("my:concat(//*)", context);
            Console.WriteLine(s);
        }
    }
}
