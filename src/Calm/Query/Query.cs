using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ringo.Calm.Query.Clauses;

namespace Ringo.Calm.Query
{
    public sealed class Query
    {
        public Where Where { get; set; }
        public OrderBy OrderBy { get; set; }
        public GroupBy GroupBy { get; set; }

        public Query()
        {
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (Where != null)
            {
                result = Where.ToString();
            }
            if (GroupBy != null)
            {
                result = string.Concat(result, GroupBy.ToString());
            }
            if (OrderBy != null)
            {
                result = string.Concat(result, OrderBy.ToString());
            }
            return result;
        }
    }
}
