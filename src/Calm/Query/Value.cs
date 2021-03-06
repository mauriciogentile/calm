﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query
{
    public sealed class Value<T> : QueryElement
    {
        public T Val { get; set; }
        public SPFieldType Type { get; set; }

        public Value(T value, SPFieldType type)
            : base("Value")
        {
            Val = value;
            Type = type;
        }

        public override XElement ToXElement()
        {
            var ele = base.ToXElement();
            ele.Add(new XAttribute("Type", Type));
            ele.Value = Val.ToString();
            return ele;
        }
    }
}
