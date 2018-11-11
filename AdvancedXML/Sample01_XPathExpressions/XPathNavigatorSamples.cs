using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.XPath;
using System.Xml;

namespace Sample01_XPathExpressions
{
	[TestClass]
	public class XPathNavigatorSamples
	{
		[TestMethod]
		public void SelectElements()
		{
			XPathDocument document = new XPathDocument("CDCatalog1.xml");
			XPathNavigator navigator = document.CreateNavigator();
			XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
			manager.AddNamespace("ns", "http://epam.com/learn/parody_CD");

			XPathNodeIterator nodes = navigator.Select("/ns:CD/ns:song/ns:title", manager);
			
			while (nodes.MoveNext())
			{
				Console.WriteLine(nodes.Current.Value);
			}

		}


		[TestMethod]
		public void ExecuteQuery()
		{
			XPathDocument document = new XPathDocument("CDCatalog1.xml");
			XPathNavigator navigator = document.CreateNavigator();
			XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
			manager.AddNamespace("ns", "http://epam.com/learn/parody_CD");
			
			XPathExpression query = navigator.Compile("sum(/ns:CD/ns:song/ns:length/ns:minutes) * 60 + sum(/ns:CD/ns:song/ns:length/ns:seconds)");
			query.SetContext(manager);

			Double total = (Double)navigator.Evaluate(query);
			Console.WriteLine(total);
		}

	}
}
