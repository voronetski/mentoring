using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Schema;
using Task01_ValidateXML;

namespace Task02_RssFeed
{
    public class Xml2Rss
    {
        public void ConvertXmlToRss(string xmlFile, string schemaUri, string targetNamespace, out bool isConversionSuccessful, string userErrorFile = "")
        {
            if (!XmlValidator.IsXmlValid(@"..\..\..\books.xml", @"..\..\..\books.xsd", "http://library.by/catalog", @"..\..\..\error.txt"))
            {
                isConversionSuccessful = false;
                return;
            }

            isConversionSuccessful = true;
        }

        public static bool IsXsltTransformationSuccesful(string xsltInputFile, string xmlInputFile, string outputFile, string userErrorFile = "")
        {
            var errorFile = String.IsNullOrWhiteSpace(userErrorFile) ? "error.txt" : userErrorFile;

            using (StreamWriter file = new StreamWriter(errorFile, true))
            {
                try
                {
                    var xsl = new XslCompiledTransform();
                    xsl.Load(xsltInputFile);
                    xsl.Transform(xmlInputFile, outputFile);
                    return true;
                }
                catch (Exception ex)
                {
                    file.WriteLine(ex.Message);
                    file.WriteLine(ex.InnerException);
                    return false;
                }
            }
        }

    }
}
