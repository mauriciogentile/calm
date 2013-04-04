using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ringo.Calm.Query.Operators;
using Microsoft.SharePoint;
using Ringo.Calm.Query.Clauses;

namespace Ringo.Calm.Query.Tests
{
    [TestFixture]
    public class AndFixture
    {
        [Test]
        public void Should_Retrieve_ElementName_Equals_To_And()
        {
            var target = new And();
            Assert.AreEqual("And", target.ElementName);
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Zero()
        {
            var target = new And();
            Assert.AreEqual(0, target.Operators.Count());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Two()
        {
            var and1 = new And();
            var and2 = new And();
            var target = new And(and1, and2);
            Assert.AreEqual(2, target.Operators.Count());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Two_1()
        {
            var fieldId = Guid.NewGuid();
            var and1 = new And();
            var eq1 = new Eq<int>(fieldId, int.MaxValue, SPFieldType.Integer);
            var or1 = new Or(eq1);
            var target = new And(and1, or1);

            var element = string.Format("<And><And /><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or></And>", fieldId, int.MaxValue);

            Assert.AreEqual(2, target.Operators.Count());
            Assert.AreEqual(element, target.ToString());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Three_2()
        {
            var fieldId = Guid.NewGuid();
            var and1 = new And();
            var eq1 = new Eq<int>(fieldId, int.MaxValue, SPFieldType.Integer);
            var or1 = new Or(eq1);
            var or2 = new Or(eq1);
            var target = new And(and1, or1, or2);

            var element = string.Format("<And><And /><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or></And>", fieldId, int.MaxValue);

            Assert.AreEqual(3, target.Operators.Count());
            Assert.AreEqual(element, target.ToString());
        }
    }
}
