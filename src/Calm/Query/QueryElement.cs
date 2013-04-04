using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query
{
    public abstract class QueryElement
    {
        public string ElementName { get; private set; }

        public QueryElement(string elementName)
        {
            ElementName = elementName;
        }

        public virtual XElement ToXElement()
        {
            return new XElement(ElementName);
        }

        public override string ToString()
        {
            return ToXElement().ToString(SaveOptions.DisableFormatting);
        }
    }
}
