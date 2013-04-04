using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;
using Ringo.Calm.Query.Operators;
using Ringo.Calm.Query.Clauses;

namespace Ringo.Calm.Query
{
    public class SPQueryExp : SPQuery
    {
        public SPQueryExp(SPQuery query)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var eq = new Eq<int>("Age", 23, SPFieldType.Text);
            var isNull = new IsNull(Guid.NewGuid());

            And and = new And(eq, isNull);
            Or or = new Or(eq, isNull);

            Where where = new Where(and, or);
            OrderBy orderBy = new OrderBy(Guid.NewGuid());

            Query query = new Query(where, orderBy);

            Console.WriteLine(query.ToString());

            //var query = new SPQuery().Where()
            //    .And()
            //        .Eq(Guid.NewGuid(), SPFieldType.Boolean, "Value1")
            //    .And()
            //        .Eq(Guid.NewGuid(), SPFieldType.Boolean, "Value1");

            ////.And()
            ////.Eq(Guid.NewGuid(), SPFieldType.Boolean, "True")
            ////.Eq(Guid.NewGuid(), SPFieldType.Boolean, "True");

            //query.ViewXml = "";
            //Console.WriteLine(query.Query);

            Console.Read();
        }
    }

    public static class SPListExtensions
    {
        public static SPQueryExp Where(this SPQuery query)
        {
            query.Query = "<Where/>";
            return new SPQueryExp(query);
        }

        public static SPQueryExp And(this SPQueryExp query)
        {
            query.Query = GetQueryXml(query.Query).AppendChild("And").OwnerDocument.OuterXml;
            return query;
        }

        public static SPQueryExp Or(this SPQueryExp query)
        {
            query.Query = GetQueryXml(query.Query).AppendChild("Or").OwnerDocument.OuterXml;
            return query;
        }

        public static SPQueryExp Eq(this SPQueryExp query, Guid fieldId, SPFieldType type, string value)
        {
            var queryDoc = GetQueryXml(query.Query);

            var lastAndOrOr = queryDoc.GetLastAndOrOr();
            var eq = lastAndOrOr.AppendChild("Eq");

            eq.AddFieldRefAndValue(fieldId, type, value);

            query.Query = queryDoc.OuterXml;

            return query;
        }

        private static void AddValue(this XmlNode node, string value, SPFieldType type)
        {
            var attrs2 = new Dictionary<string, string>();
            attrs2.Add("Type", type.ToString());
            node.AppendChild("Value", attrs2).InnerText = value;
        }

        private static void AddFieldRefAndValue(this XmlNode node, Guid fieldId, SPFieldType type, string value)
        {
            var attrs1 = new Dictionary<string, string>();
            attrs1.Add("ID", fieldId.ToString());
            node.AppendChild("FieldRef", attrs1);
            node.AddValue(value, type);
        }

        private static void AddFieldRefAndValue(this XmlNode node, string fieldName, SPFieldType type, string value)
        {
            var attrs1 = new Dictionary<string, string>();
            attrs1.Add("Name", fieldName);
            node.AppendChild("FieldRef", attrs1);
            node.AddValue(value, type);
        }

        private static XmlNode AppendChild(this XmlNode node, string nodeName)
        {
            var xmlDoc = node as XmlDocument;
            if (xmlDoc != null)
            {
                var child = xmlDoc.CreateElement(nodeName);
                return xmlDoc.DocumentElement.AppendChild(child);
            }
            return node.AppendChild(node.OwnerDocument.CreateElement(nodeName));
        }

        private static XmlDocument GetQueryXml(string query)
        {
            var queryDoc = new XmlDocument();
            queryDoc.LoadXml(query);
            return queryDoc;
        }

        private static XmlNode GetLastAndOrOr(this XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Or" || child.Name == "And")
                {
                    return child;
                }
                XmlNode anotherNode = child.GetLastAndOrOr();
                while (anotherNode == null && anotherNode.HasChildNodes)
                {
                    anotherNode = child.GetLastAndOrOr();
                }
                return anotherNode;
            }
            return null;
        }

        private static XmlNode AppendChild(this XmlNode node, string nodeName, Dictionary<string, string> attrs)
        {
            var child = node.AppendChild(nodeName);

            foreach (var attr in attrs)
            {
                var newAttr = child.OwnerDocument.CreateAttribute(attr.Key);
                newAttr.Value = attr.Value;
                child.Attributes.Append(newAttr);
            }

            return child;
        }

    }
}
