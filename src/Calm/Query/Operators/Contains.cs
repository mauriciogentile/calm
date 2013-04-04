using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class Contains : SingleFieldValueOperator<string>
    {
        public Contains(Guid fieldId, string value)
            : base("Contains", fieldId, value, SPFieldType.Text)
        {
        }

        public Contains(string fieldName, string value)
            : base("Contains", fieldName, value, SPFieldType.Text)
        {
        }
    }
}
