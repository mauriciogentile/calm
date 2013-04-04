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
    public class IsNotNullFixture
    {
        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Name()
        {
            var target = new IsNotNull("Field1");

            Assert.AreEqual(target.ElementName, "IsNotNull");
            Assert.AreEqual(target.FieldRef.Name, "Field1");
            Assert.AreEqual("<IsNotNull><FieldRef Name=\"Field1\" /></IsNotNull>", target.ToString());
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Id()
        {
            var fieldId = Guid.NewGuid();
            var target = new IsNotNull(fieldId);
            Assert.AreEqual(target.ElementName, "IsNotNull");
            Assert.AreEqual(target.FieldRef.FieldId, fieldId);
            Assert.AreEqual(string.Format("<IsNotNull><FieldRef ID=\"{0}\" /></IsNotNull>", fieldId), target.ToString());
        }
    }
}
