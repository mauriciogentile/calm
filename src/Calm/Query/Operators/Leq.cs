using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Leq<T> : SingleFieldValueOperator<T>
    {
        public Leq(Guid fieldId, T value, SPFieldType type)
            : base("Leq", fieldId, value, type)
        {
        }

        public Leq(string fieldName, T value, SPFieldType type)
            : base("Leq", fieldName, value, type)
        {
        }
    }
}
