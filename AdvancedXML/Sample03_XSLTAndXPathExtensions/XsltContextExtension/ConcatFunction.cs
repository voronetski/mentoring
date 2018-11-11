using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Sample03_XSLTAndXPathExtensions.XsltContextExtension
{
    public class ConcatFunction : IXsltContextFunction
    {
        public XPathResultType[] ArgTypes
        {
            get
            {
                return new XPathResultType[] { XPathResultType.NodeSet };
            }
        }

        public int Maxargs
        {
            get
            {
                return 1;
            }
        }

        public int Minargs
        {
            get
            {
                return 1;
            }
        }

        public XPathResultType ReturnType
        {
            get
            {
                return XPathResultType.String;
            }
        }

        public object Invoke(System.Xml.Xsl.XsltContext xsltContext, object[] args, 
            XPathNavigator docContext)
        {
            var nodes = args[0] as XPathNodeIterator;
            return string.Concat(nodes.OfType<XPathNavigator>().Select(xp => xp.Value));
        }
    }
}
