using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public abstract class Operator : QueryElement
    {
        public Operator(string operatorName)
            : base(operatorName)
        {
        }
    }
}
