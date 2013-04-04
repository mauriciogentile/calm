using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Lt<T> : SingleFieldValueOperator<T>
    {
        public Lt(Guid fieldId, T value, SPFieldType type)
            : base("Lt", fieldId, value, type)
        {
        }

        public Lt(string fieldName, T value, SPFieldType type)
            : base("Lt", fieldName, value, type)
        {
        }
    }
}
