using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using xsl = System.Xml.Xsl;

namespace Sample03_XSLTAndXPathExtensions.XsltContextExtension
{
    public class XsltContext : xsl.XsltContext
    {        
        public XsltContext()
        { }

        private Dictionary<string, Counter> counters = new Dictionary<string, Counter>();

        public override bool Whitespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            throw new NotImplementedException();
        }

        public override bool PreserveWhitespace(XPathNavigator node)
        {
            throw new NotImplementedException();
        }

        public override xsl.IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            var ns = LookupNamespace(prefix);
            if (ns == "http://epam.com/xsl/ext" && name == "concat")
            {
                return new ConcatFunction();
            }

            return null;
        }

        public override xsl.IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            var ns = LookupNamespace(prefix);
            if (ns == "http://epam.com/xsl/ext/counters")
            {
                Counter counter = null;
                counters.TryGetValue(name, out counter);

                if (counter == null)
                {
                    counter = new Counter();
                    counters.Add(name, counter);
                }

                return counter;
            }
            return null;
        }
    }
}
