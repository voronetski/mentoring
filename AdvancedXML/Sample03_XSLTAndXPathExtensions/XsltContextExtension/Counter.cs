using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Sample03_XSLTAndXPathExtensions.XsltContextExtension
{
    public class Counter : IXsltContextVariable
    {
        private int counter = 0;

        public bool IsLocal
        {
            get
            {
                return true;
            }
        }

        public bool IsParam
        {
            get
            {
                return false;
            }
        }

        public XPathResultType VariableType
        {
            get
            {
                return XPathResultType.Number;
            }
        }

        public object Evaluate(System.Xml.Xsl.XsltContext xsltContext)
        {
            return counter++;
        }
    }
}
