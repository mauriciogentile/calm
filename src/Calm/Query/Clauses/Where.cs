using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ringo.Calm.Query.Operators;

namespace Ringo.Calm.Query.Clauses
{
    public sealed class Where : Clause
    {
        public Where(params Operator[] operators)
            : base("Where", operators)
        {
        }
    }
}
