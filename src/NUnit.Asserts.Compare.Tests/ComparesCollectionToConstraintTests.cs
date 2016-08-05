using NUnit.Framework;

namespace NUnit.Asserts.Compare.Tests
{
    [TestFixture]
    public class ComparesCollectionToConstraintTests
    {
        [Test]
        public void ComparesTo_ObjectExistWithoutTypeChecking_AssertSucced()
        {
            var expected = new { PropOne = "some other prop", OtherProp = "other OtherProp" };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(expected, Compares.ToAnyIn(secondCollection).WithoutTypeChecking());
        }

        [Test]
        public void ComparesTo_ObjectDifferences_AssertFails()
        {
            var expected = new { PropOne = "some other prop", OtherProp = "difference" };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(() => Assert.That(expected, Compares.ToAnyIn(secondCollection).WithoutTypeChecking()), Throws.InstanceOf<AssertionException>());
        }

        [Test]
        public void ComparesTo_ObjectDifferencesInIgnoredProperty_AssertSuccess()
        {
            var expected = new { PropOne = "some other prop", OtherProp = "difference" };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(expected, Compares.ToAnyIn(secondCollection).WithoutTypeChecking().IgnoreProperty("OtherProp"));
        }
    }
}
