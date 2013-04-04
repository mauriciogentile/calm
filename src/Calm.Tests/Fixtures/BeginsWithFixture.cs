using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ringo.Calm.Query.Operators;
using Microsoft.SharePoint;

namespace Ringo.Calm.Query.Tests
{
    [TestFixture]
    public class BeginsWithFixture
    {
        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef()
        {
            var target = new BeginsWith("Field1", "A good value");
            
            Assert.AreEqual(target.ElementName, "BeginsWith"); 
            Assert.AreEqual(target.Value.Val, "A good value");
            Assert.AreEqual(target.Value.Type, SPFieldType.Text);
            Assert.AreEqual(target.FieldRef.Name, "Field1");
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef1()
        {
            var fieldId = Guid.NewGuid();
            var target = new BeginsWith(fieldId, "A good value");
            Assert.AreEqual(target.ElementName, "BeginsWith");
            Assert.AreEqual(target.Value.Val, "A good value");
            Assert.AreEqual(target.Value.Type, SPFieldType.Text);
            Assert.AreEqual(target.FieldRef.FieldId, fieldId);
        }
    }
}

