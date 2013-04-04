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
    public class OrFixture
    {
        [Test]
        public void Should_Retrieve_ElementName_Equals_To_Or()
        {
            var target = new Or();
            Assert.AreEqual("Or", target.ElementName);
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Zero()
        {
            var target = new Or();
            Assert.AreEqual(0, target.Operators.Count());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Two()
        {
            var or1 = new Or();
            var or2 = new Or();
            var target = new Or(or1, or2);
            Assert.AreEqual(2, target.Operators.Count());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Two_1()
        {
            var fieldId = Guid.NewGuid();
            var or = new Or();
            var eq1 = new Eq<int>(fieldId, int.MaxValue, SPFieldType.Integer);
            var or1 = new Or(eq1);
            var target = new Or(or, or1);

            var element = string.Format("<Or><Or /><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or></Or>", fieldId, int.MaxValue);

            Assert.AreEqual(2, target.Operators.Count());
            Assert.AreEqual(element, target.ToString());
        }

        [Test]
        public void Should_Retrieve_Operators_Equals_To_Three_2()
        {
            var fieldId = Guid.NewGuid();
            var or = new Or();
            var eq1 = new Eq<int>(fieldId, int.MaxValue, SPFieldType.Integer);
            var or1 = new Or(eq1);
            var or2 = new Or(eq1);
            var target = new Or(or, or1, or2);

            var element = string.Format("<Or><Or /><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or><Or><Eq><Value Type=\"Integer\">{1}</Value><FieldRef ID=\"{0}\" /></Eq></Or></Or>", fieldId, int.MaxValue);

            Assert.AreEqual(3, target.Operators.Count());
            Assert.AreEqual(element, target.ToString());
        }
    }
}
