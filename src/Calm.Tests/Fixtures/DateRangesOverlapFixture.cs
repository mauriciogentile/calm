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
    public class DateRangesOverlapFixture
    {
        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef()
        {
            var target = new DateRangesOverlap(DateTime.MaxValue, "Field1");

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MaxValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual("Field1", target.FieldRefs.First().Name);
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Two_Fields()
        {
            var target = new DateRangesOverlap(DateTime.MaxValue, "Field1", "Field2");

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MaxValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual("Field1", target.FieldRefs.First().Name);
            Assert.AreEqual("Field2", target.FieldRefs.Last().Name);
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Two_FieldIds()
        {
            var fieldId1 = Guid.NewGuid();
            var fieldId2 = Guid.NewGuid();
            var target = new DateRangesOverlap(DateTime.MaxValue, fieldId1, fieldId2);

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MaxValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual(fieldId1, target.FieldRefs.First().FieldId);
            Assert.AreEqual(fieldId2, target.FieldRefs.Last().FieldId);
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef_Two_FieldIds_With_Enum()
        {
            var fieldId1 = Guid.NewGuid();
            var fieldId2 = Guid.NewGuid();
            var target = new DateRangesOverlap(DateRangesOverlapValue.Today, fieldId1, fieldId2);

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual(fieldId1, target.FieldRefs.First().FieldId);
            Assert.AreEqual(fieldId2, target.FieldRefs.Last().FieldId);

            var expected = string.Format("<DateRangesOverlap><Value Type=\"DateTime\"><Today /></Value><FieldRef ID=\"{0}\" /><FieldRef ID=\"{1}\" /></DateRangesOverlap>", fieldId1, fieldId2, DateRangesOverlapValue.Today);

            Assert.AreEqual(expected, target.ToString());
        }

        [Test]
        public void Constructor_Should_SetUp_Element_And_FieldRef1()
        {
            var fieldId = Guid.NewGuid();
            var target = new DateRangesOverlap(DateTime.MinValue, fieldId);
            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MinValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual(fieldId, target.FieldRefs.First().FieldId);
        }

        [Test]
        public void ToString_Should_Retrieve_Correct_Element()
        {
            var fieldId = Guid.NewGuid();
            var target = new DateRangesOverlap(DateTime.MinValue, fieldId);

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MinValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual(fieldId, target.FieldRefs.First().FieldId);

            var expected = string.Format("<DateRangesOverlap><Value Type=\"DateTime\">{1}</Value><FieldRef ID=\"{0}\" /></DateRangesOverlap>", fieldId, DateTime.MinValue);

            Assert.AreEqual(expected, target.ToString());
        }

        [Test]
        public void ToString_Should_Retrieve_Correct_Element_()
        {
            var target = new DateRangesOverlap(DateTime.MinValue, "Field1");

            Assert.AreEqual(target.ElementName, "DateRangesOverlap");
            Assert.AreEqual(target.Value.Val, DateTime.MinValue);
            Assert.AreEqual(target.Value.Type, SPFieldType.DateTime);
            Assert.AreEqual("Field1", target.FieldRefs.First().Name);

            var expected = string.Format("<DateRangesOverlap><Value Type=\"DateTime\">{1}</Value><FieldRef Name=\"{0}\" /></DateRangesOverlap>", "Field1", DateTime.MinValue);

            Assert.AreEqual(expected, target.ToString());
        }
    }
}
