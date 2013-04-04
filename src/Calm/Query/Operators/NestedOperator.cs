using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public abstract class NestedOperator : Operator
    {
        public IEnumerable<Operator> Operators { get; set; }

        public NestedOperator(string operatorName, params Operator[] operators)
            : base(operatorName)
        {
            Operators = operators;
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();
            foreach (var op in Operators)
            {
                ele.Add(op.ToXElement());
            }
            return ele;
        }
    }
}
