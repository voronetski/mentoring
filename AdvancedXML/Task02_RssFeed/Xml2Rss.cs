using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
