using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace Task01_ValidateXML
{
    public class XmlValidator
    {
        internal static XmlReaderSettings GetXmlReaderSettings(string targetNamespace, string schemaUri, StreamWriter streamWriter)
        {
            var settings = new XmlReaderSettings();

            settings.Schemas.Add(targetNamespace, schemaUri);
            settings.ValidationEventHandler +=
                delegate (object sender, ValidationEventArgs e)
                {
                    streamWriter.WriteLine("[{0}:{1}] {2}", e.Exception.LineNumber, e.Exception.LinePosition, e.Message);
                };

            settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;

            return settings;
        }

        public static void ValidateXML(string xmlFile, string schemaUri, string targetNamespace, out bool isXmlValid, string userErrorFile = "")
        {
            var errorFile = String.IsNullOrWhiteSpace(userErrorFile) ? "error.txt" : userErrorFile;

            using (StreamWriter file = new StreamWriter(errorFile, true))
            {
                var settings = GetXmlReaderSettings(targetNamespace, schemaUri, file);

                XmlReader reader = XmlReader.Create(xmlFile, settings);

                while (reader.Read()) ;

                isXmlValid = file.BaseStream.Length == 0;
            }
        }

        public static bool IsXmlValid(string xmlFile, string schemaUri, string targetNamespace, string userErrorFile = "")
        {
            bool result;
            ValidateXML(xmlFile, schemaUri, targetNamespace, out result, userErrorFile);

            return result;
        }
    }
}
