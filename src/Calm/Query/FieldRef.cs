using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query
{
    public sealed class FieldRef : QueryElement
    {
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public bool? Ascending { get; set; }
        public bool? IncludeTimeValue { get; set; }

        public FieldRef()
            : base("FieldRef")
        {
        }

        public override XElement ToXElement()
        {
            var ele = new XElement("FieldRef");
            if (FieldId != Guid.Empty)
            {
                ele.Add(new XAttribute("ID", FieldId));
            }
            else if (!string.IsNullOrEmpty(Name))
            {
                ele.Add(new XAttribute("Name", Name));
            }
            if (Ascending.HasValue)
            {
                ele.Add(new XAttribute("Ascending", Ascending.Value));
            }
            if (IncludeTimeValue.HasValue)
            {
                ele.Add(new XAttribute("IncludeTimeValue", Ascending.Value));
            }
            return ele;
        }
    }
}
