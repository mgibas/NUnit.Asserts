using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using System.Collections;

namespace NUnit.Asserts.Compare
{
    public class CompareAssert
    {
        /// <summary>
        /// Examine objects equality with types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEqual<T>(T expected, T actual)
        {
            AreEqual(expected, actual, new string[0]);
        }

        /// <summary>
        /// Examine objects equality with types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void AreEqual<T>(T expected, T actual, params string[] propertiesToIgnore)
        {
            var compareConfig = new ComparisonConfig { MembersToIgnore = new List<string>(propertiesToIgnore) };
            ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(expected, actual);
            Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal, please inspect differences:\n\n{0}", compareResult.DifferencesString);
        }

        /// <summary>
        /// Examine objects equality with types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void AreEqual<T>(T expected, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
        {
            var propertyNames = propertiesToIgnore.Select(PropertyName);
            AreEqual(expected, actual, propertyNames.ToArray());
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison with type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void ContainsEqual<T>(IEnumerable collection, T actual)
        {
            ContainsEqual(collection, actual, new string[0]);
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison with type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void ContainsEqual<T>(IEnumerable collection, T actual, params string[] propertiesToIgnore)
        {
            var compareConfig = new ComparisonConfig { MembersToIgnore = new List<string>(propertiesToIgnore) };
            var results = new List<string>();
            foreach (var item in collection)
            {
                ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(item, actual);
                if (compareResult.AreEqual) return;
                results.Add(compareResult.DifferencesString);
            }

            Assert.Fail("Could not find item in collection.Please inspect differences:\n\n{0}", results.Aggregate((i, j) => i + "\n" + j));
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison with type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void ContainsEqual<T>(IEnumerable collection, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
        {
            var propertyNames = propertiesToIgnore.Select(PropertyName);
            ContainsEqual(collection, actual, propertyNames.ToArray());
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison without type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void ContainsEquivalent<T>(IEnumerable collection, T actual)
        {
            ContainsEquivalent(collection, actual, new string[0]);
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison without type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void ContainsEquivalent<T>(IEnumerable collection, T actual, params string[] propertiesToIgnore)
        {
            var compareConfig = new ComparisonConfig
            {
                MembersToIgnore = new List<string>(propertiesToIgnore),
                IgnoreObjectTypes = true
            };

            var differences = new List<string>();
            foreach (var item in collection)
            {
                ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(item, actual);
                if (compareResult.AreEqual) return;
                differences.Add(compareResult.DifferencesString);
            }

            Assert.Fail("Could not find item in collection.Please inspect differences:\n\n{0}", differences.Aggregate((i, j) => i + "\n" + j));
        }

        /// <summary>
        /// Asserts that collection contains item using deep comparison without type checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void ContainsEquivalent<T>(IEnumerable collection, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
        {
            var propertyNames = propertiesToIgnore.Select(PropertyName);
            ContainsEquivalent(collection, actual, propertyNames.ToArray());
        }

        /// <summary>
        /// Examine objects equality without types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEquivalent(object expected, object actual)
        {
            AreEquivalent(expected, actual, new string[0]);
        }

        /// <summary>
        /// Examine objects equality without types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void AreEquivalent(object expected, object actual, params string[] propertiesToIgnore)
        {
            var compareConfig = new ComparisonConfig
            {
                MembersToIgnore = new List<string>(propertiesToIgnore),
                IgnoreObjectTypes = true
            };
            ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(expected, actual);
            Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal, please inspect differences:\n\n{0}", compareResult.DifferencesString);
        }

        /// <summary>
        /// Examine objects equality without types checking
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
        public static void AreEquivalent<T>(T expected, object actual, params Expression<Func<T, object>>[] propertiesToIgnore)
        {
            var propertyNames = propertiesToIgnore.Select(PropertyName);
            AreEquivalent(expected, actual, propertyNames.ToArray());
        }

        private static string PropertyName<TModel>(Expression<Func<TModel, object>> property)
        {
            var body = property.Body as MemberExpression;

            if (body == null)
            {
                var ubody = (UnaryExpression)property.Body;
                body = ubody.Operand as MemberExpression;
            }

            if (body == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression or UnaryExpression.");
            }

            return body.Member.Name;
        }
    }
}


