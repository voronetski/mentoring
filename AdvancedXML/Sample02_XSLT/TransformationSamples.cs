using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Xsl;
using System.Reflection;
using System.IO;

namespace Sample02_XSLT
{
	[TestClass]
	public class TransformationSamples
	{
		[TestMethod]
		public void XslCompiledTransform()
		{
			var xsl = new XslCompiledTransform();
			xsl.Load("GetTitleList.xslt");

			xsl.Transform("CDCatalog1.xml", null, Console.Out);
		}

		[TestMethod]
		public void XslcAssembly()
		{
			var xsl = new XslCompiledTransform();
			xsl.Load(Assembly.Load("GetTitleList").GetType("EPAM.GetTitleList"));

			xsl.Transform("CDCatalog1.xml", null, Console.Out);
		}

		[TestMethod]
		public void XslWithParams()
		{
			var xsl = new XslCompiledTransform();
			xsl.Load("GetTitleList.xslt");
			var xslParams = new XsltArgumentList();
			xslParams.AddParam("Date", "", DateTime.Now);


			xsl.Transform("CDCatalog1.xml", xslParams, Console.Out);
		}
	}
}
