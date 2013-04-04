using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class IsNull : SingleFieldOperator
    {
        public IsNull(Guid fieldId)
            : base("IsNull", new FieldRef() { FieldId = fieldId })
        {
        }

        public IsNull(string fieldName)
            : base("IsNull", new FieldRef() { Name = fieldName })
        {
        }
    }
}
