using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ringo.Calm.Query.Operators;
using Microsoft.SharePoint;
using Ringo.Calm.Query.Clauses;
using Ringo.Calm.Query;

namespace Ringo.Calm.Query.Tests.Fixtures
{
    [TestFixture]
    public class QueryFixture
    {
        [Test]
        public void Test_All_Inclusive()
        {
            var query = new Query()
            {
                Where = new Where(
                    new Or(
                        new Eq<string>(fieldName: "ContentType", value: "My Content Type", type: SPFieldType.Text),
                        new IsNotNull(fieldName: "Description"))),

                GroupBy = new GroupBy(fieldName: "Title", collapse: true),
                OrderBy = new OrderBy(fieldName: "_Author").ThenBy(fieldName: "AuthoringDate").ThenBy(fieldName: "AssignedTo", ascending: true)
            };

            var spQuery = new SPQuery();
            spQuery.Query = query.ToString();

            var expected = "";
            expected = string.Concat(expected, "<Where>");
            expected = string.Concat(expected, "<Or>");
            expected = string.Concat(expected, "<Eq>");
            expected = string.Concat(expected, "<Value Type=\"Text\">My Content Type</Value>");
            expected = string.Concat(expected, "<FieldRef Name=\"ContentType\" />");
            expected = string.Concat(expected, "</Eq>");
            expected = string.Concat(expected, "<IsNotNull>");
            expected = string.Concat(expected, "<FieldRef Name=\"Description\" />");
            expected = string.Concat(expected, "</IsNotNull>");
            expected = string.Concat(expected, "</Or>");
            expected = string.Concat(expected, "</Where>");
            expected = string.Concat(expected, "<GroupBy Collapse=\"true\">");
            expected = string.Concat(expected, "<FieldRef Name=\"Title\" Ascending=\"false\" />");
            expected = string.Concat(expected, "</GroupBy>");
            expected = string.Concat(expected, "<OrderBy>");
            expected = string.Concat(expected, "<FieldRef Name=\"_Author\" Ascending=\"false\" />");
            expected = string.Concat(expected, "<FieldRef Name=\"AuthoringDate\" Ascending=\"false\" />");
            expected = string.Concat(expected, "<FieldRef Name=\"AssignedTo\" Ascending=\"true\" />");
            expected = string.Concat(expected, "</OrderBy>");
            expected = string.Concat(expected, "");

            Assert.AreEqual(expected, spQuery.Query);
        }
    }
}
