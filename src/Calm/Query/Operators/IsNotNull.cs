using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Operators
{
    public sealed class IsNotNull : SingleFieldOperator
    {
        public IsNotNull(Guid fieldId)
            : base("IsNotNull", new FieldRef() { FieldId = fieldId })
        {
        }

        public IsNotNull(string fieldName)
            : base("IsNotNull", new FieldRef() { Name = fieldName })
        {
        }
    }
}
