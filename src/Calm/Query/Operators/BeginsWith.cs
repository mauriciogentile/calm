using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class BeginsWith : SingleFieldValueOperator<string>
    {
        public BeginsWith(Guid fieldId, string value)
            : base("BeginsWith", fieldId, value, SPFieldType.Text)
        {
        }

        public BeginsWith(string fieldName, string value)
            : base("BeginsWith", fieldName, value, SPFieldType.Text)
        {
        }
    }
}
