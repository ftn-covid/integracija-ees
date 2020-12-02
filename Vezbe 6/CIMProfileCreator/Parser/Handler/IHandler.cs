using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelventDMS.Integration.CIM.Model;

namespace TelventDMS.Integration.CIM.Parser.Handler
{
	interface IHandler
	{
		void StartDocument(string filePath);
		void StartElement(string localName, string qName, SortedList<string,string> atts);
		void EndElement(string localName, string qName);
		void StartPrefixMapping(string prefix, string uri);
		void Characters(string text);
		void EndDocument();
		//CIMModel GetModel();
		//public virtual void FatalError(ParseError error);
		//public virtual void Error(ParseError error);
		//public virtual void Warning(ParseError error);
	}
}
