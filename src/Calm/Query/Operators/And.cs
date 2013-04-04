using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public sealed class And : NestedOperator
    {
        public And(params Operator[] operators)
            : base("And", operators)
        {
        }
    }
}
