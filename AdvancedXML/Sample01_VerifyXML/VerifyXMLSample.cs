using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Schema;

namespace Sample01_VerifyXML
{
	[TestClass]
	public class VerifyXMLSample
	{
		XmlReaderSettings settings;

		[TestInitialize]
		public void Init()
		{
			settings = new XmlReaderSettings();

			settings.Schemas.Add("http://epam.com/learn/parody_CD", "CDCatalogSchema.xsd");
			settings.ValidationEventHandler +=
				delegate (object sender, ValidationEventArgs e)
				{
					Console.WriteLine("[{0}:{1}] {2}", e.Exception.LineNumber, e.Exception.LinePosition, e.Message);
				};

			settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
			settings.ValidationType = ValidationType.Schema;
		}

		[TestMethod]
		public void CheckValidXML()
		{
			XmlReader reader = XmlReader.Create("CDCatalog1.xml", settings);

			while (reader.Read()) ;
		}

		[TestMethod]
		public void CheckNotValidXML()
		{
			XmlReader reader = XmlReader.Create("CDCatalog1_withError.xml", settings);

			while (reader.Read()) ;
		}

	}
}
