using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml.Linq;

namespace Ringo.Calm.Query.Operators
{
    public enum DateRangesOverlapValue
    {
        Today,
        Day,
        Week,
        Month,
        Year
    }

    public sealed class DateRangesOverlap : MultipleFieldValueOperator<DateTime>
    {
        private DateRangesOverlapValue? enumValue;

        public DateRangesOverlap(DateTime value, params Guid[] fieldIds)
            : base("DateRangesOverlap", fieldIds, value, SPFieldType.DateTime)
        {
        }

        public DateRangesOverlap(DateTime value, params string[] fieldNames)
            : base("DateRangesOverlap", fieldNames, value, SPFieldType.DateTime)
        {
        }

        public DateRangesOverlap(DateRangesOverlapValue value, params Guid[] fieldIds)
            : base("DateRangesOverlap", fieldIds, DateTime.MinValue, SPFieldType.DateTime)
        {
            enumValue = value;
        }

        public DateRangesOverlap(DateRangesOverlapValue value, params string[] fieldNames)
            : base("DateRangesOverlap", fieldNames, DateTime.MinValue, SPFieldType.DateTime)
        {
            enumValue = value;
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();

            if (enumValue.HasValue)
            {
                var value = ele.Elements("Value").Single();
                value.Value = string.Empty;
                value.Add(new XElement(enumValue.ToString()));
            }

            return ele;
        }
    }
}
