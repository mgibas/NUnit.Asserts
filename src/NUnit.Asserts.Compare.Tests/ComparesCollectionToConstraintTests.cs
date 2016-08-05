using NUnit.Framework;

namespace NUnit.Asserts.Compare.Tests
{
    [TestFixture]
    public class ComparesCollectionToConstraintTests
    {
        [Test]
        public void ComparesTo_SameCollectionsWithoutTypeChecking_AssertSucced()
        {
            var firstCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(firstCollection, Compares.ToAnyIn(secondCollection).WithoutTypeChecking());
        }

        [Test]
        public void ComparesTo_ObjectDifferences_AssertFails()
        {
            var firstCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "difference" }
            };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(() => Assert.That(firstCollection, Compares.ToAnyIn(secondCollection).WithoutTypeChecking()), Throws.InstanceOf<AssertionException>());
        }

        [Test]
        public void ComparesTo_ObjectDifferencesInIgnoredProperty_AssertSuccess()
        {
            var firstCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "difference" }
            };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };

            Assert.That(firstCollection, Compares.ToAnyIn(secondCollection).WithoutTypeChecking().IgnoreProperty("OtherProp"));
        }

        [Test]
        public void ComparesTo_CollectionIsSubset_AssertSuccess()
        {
            var firstCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" }
            };
            var secondCollection = new[]
            {
                new { PropOne = "some prop", OtherProp = "OtherProp" },
                new { PropOne = "some other prop", OtherProp = "other OtherProp" },
                new { PropOne = "extra", OtherProp = "extra" }
            };

            Assert.That(firstCollection, Compares.ToAnyIn(secondCollection).WithoutTypeChecking());
        }
    }
}
