using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ringo.Calm.Query.Operators;

namespace Ringo.Calm.Query.Clauses
{
    public abstract class Clause : QueryElement
    {
        public IEnumerable<Operator> Operators { get; private set; }

        protected Clause(string clauseName, params Operator[] operators)
            : base(clauseName)
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
