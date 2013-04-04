using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Or : NestedOperator
    {
        public Or(params Operator[] operators)
            : base("Or", operators)
        {
        }
    }
}
