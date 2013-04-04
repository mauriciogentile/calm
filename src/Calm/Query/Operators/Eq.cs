using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Eq<T> : SingleFieldValueOperator<T>
    {
        public Eq(Guid fieldId, T value, SPFieldType type)
            : base("Eq", fieldId, value, type)
        {
        }

        public Eq(string fieldName, T value, SPFieldType type)
            : base("Eq", fieldName, value, type)
        {
        }
    }
}
