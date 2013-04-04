using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Gt<T> : SingleFieldValueOperator<T>
    {
        public Gt(Guid fieldId, T value, SPFieldType type)
            : base("Gt", fieldId, value, type)
        {
        }

        public Gt(string fieldName, T value, SPFieldType type)
            : base("Gt", fieldName, value, type)
        {
        }
    }
}
