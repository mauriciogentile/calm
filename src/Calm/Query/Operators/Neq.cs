using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Neq<T> : SingleFieldValueOperator<T>
    {
        public Neq(Guid fieldId, T value, SPFieldType type)
            : base("Neq", fieldId, value, type)
        {
        }

        public Neq(string fieldName, T value, SPFieldType type)
            : base("Neq", fieldName, value, type)
        {
        }
    }
}
