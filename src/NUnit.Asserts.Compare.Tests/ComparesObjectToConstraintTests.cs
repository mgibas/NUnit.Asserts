using NUnit.Framework;

namespace NUnit.Asserts.Compare.Tests
{
    [TestFixture]
    public class ComparesObjectToConstraintTests
    {
        [Test]
        public void ComparesTo_EqualsObject_AssertSucced()
        {
            var firstObject = new { PropOne = "some prop", OtherProp = "OtherProp" };
            var secondObject = new { PropOne = "some prop", OtherProp = "OtherProp" };

            Assert.That(firstObject, Compares.To(secondObject));
        }

        [Test]
        public void ComparesTo_NotEqualObject_AssertFails()
        {
            var firstObject = new { PropOne = "some prop", OtherProp = "OtherProp" };
            var secondObject = new { PropOne = "some prop", OtherProp = "difference" };

            Assert.That(() => Assert.That(firstObject, Compares.To(secondObject)), Throws.InstanceOf<AssertionException>());
        }

        [Test]
        public void ComparesTo_DifferenceInIgnoredProperty_AssertSucced()
        {
            var firstObject = new { PropOne = "some prop", OtherProp = "OtherProp" };
            var secondObject = new { PropOne = "some prop", OtherProp = "difference" };

            Assert.That(firstObject, Compares.To(secondObject).IgnoreProperty("OtherProp"));
        }
    }
}
