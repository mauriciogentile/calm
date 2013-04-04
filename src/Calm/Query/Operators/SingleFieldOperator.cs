using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public abstract class SingleFieldOperator : Operator
    {
        public FieldRef FieldRef { get; set; }

        public SingleFieldOperator(string operatorName, FieldRef fieldRef)
            : base(operatorName)
        {
            FieldRef = fieldRef;
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();
            ele.Add(FieldRef.ToXElement());
            return ele;
        }
    }
}
