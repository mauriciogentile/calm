using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public abstract class ValueOperator<T> : Operator
    {
        public Value<T> Value { get; set; }

        public ValueOperator(string operatorName, T value, SPFieldType type)
            : base(operatorName)
        {
            Value = new Value<T>(value, type);
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();
            ele.Add(Value.ToXElement());
            return ele;
        }
    }
}
