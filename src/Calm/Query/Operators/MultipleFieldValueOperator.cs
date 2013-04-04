using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public abstract class MultipleFieldValueOperator<T> : ValueOperator<T>
    {
        public IEnumerable<FieldRef> FieldRefs { get; set; }

        protected MultipleFieldValueOperator(string operatorName, IEnumerable<string> fieldNames, T value, SPFieldType type)
            : base(operatorName, value, type)
        {
            var fieldRefs = new List<FieldRef>();
            foreach (var fieldName in fieldNames)
            {
                fieldRefs.Add(new FieldRef() { Name = fieldName });
            }
            FieldRefs = fieldRefs;
        }

        protected MultipleFieldValueOperator(string operatorName, IEnumerable<Guid> fieldIds, T value, SPFieldType type)
            : base(operatorName, value, type)
        {
            var fieldRefs = new List<FieldRef>();
            foreach (var fieldId in fieldIds)
            {
                fieldRefs.Add(new FieldRef() { FieldId = fieldId });
            }
            FieldRefs = fieldRefs;
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();
            foreach (var fieldRef in FieldRefs)
            {
                ele.Add(fieldRef.ToXElement());
            }
            return ele;
        }
    }
}
