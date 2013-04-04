using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Geq<T> : SingleFieldValueOperator<T>
    {
        public Geq(Guid fieldId, T value, SPFieldType type)
            : base("Geq", fieldId, value, type)
        {
        }

        public Geq(string fieldName, T value, SPFieldType type)
            : base("Geq", fieldName, value, type)
        {
        }
    }
}
