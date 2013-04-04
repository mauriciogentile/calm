using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ringo.Calm.Query.Operators;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Tests.Fixtures
{
    [TestFixture]
    public class IsNullFixture
    {
        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Name()
        {
            var target = new IsNull("Field1");

            Assert.AreEqual(target.ElementName, "IsNull");
            Assert.AreEqual(target.FieldRef.Name, "Field1");
            Assert.AreEqual("<IsNull><FieldRef Name=\"Field1\" /></IsNull>", target.ToString());
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Id()
        {
            var fieldId = Guid.NewGuid();
            var target = new IsNull(fieldId);
            Assert.AreEqual(target.ElementName, "IsNull");
            Assert.AreEqual(target.FieldRef.FieldId, fieldId);
            Assert.AreEqual(string.Format("<IsNull><FieldRef ID=\"{0}\" /></IsNull>", fieldId), target.ToString());
        }
    }
}
