using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

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
      Assert.That(actual, Compares.To(expected).IgnoreProperties(propertiesToIgnore));
    }

    /// <summary>
    /// Examine objects equality with types checking
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual"></param>
    /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
    public static void AreEqual<T>(T expected, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
    {
      var propertyNames = propertiesToIgnore.Select(ExpressionExtensions.PropertyName);
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
      Assert.That(actual, Compares.ToAnyIn(collection).IgnoreProperties(propertiesToIgnore));
    }

    /// <summary>
    /// Asserts that collection contains item using deep comparison with type checking
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual"></param>
    /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
    public static void ContainsEqual<T>(IEnumerable collection, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
    {
      var propertyNames = propertiesToIgnore.Select(ExpressionExtensions.PropertyName);
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
      Assert.That(actual, Compares.ToAnyIn(collection).IgnoreProperties(propertiesToIgnore).WithoutTypeChecking());
    }

    /// <summary>
    /// Asserts that collection contains item using deep comparison without type checking
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual"></param>
    /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
    public static void ContainsEquivalent<T>(IEnumerable collection, T actual, params Expression<Func<T, object>>[] propertiesToIgnore)
    {
      var propertyNames = propertiesToIgnore.Select(ExpressionExtensions.PropertyName);
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
      Assert.That(actual, Compares.To(expected).IgnoreProperties(propertiesToIgnore).WithoutTypeChecking());
    }

    /// <summary>
    /// Examine objects equality without types checking
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="actual"></param>
    /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
    public static void AreEquivalent<T>(T expected, object actual, params Expression<Func<T, object>>[] propertiesToIgnore)
    {
      var propertyNames = propertiesToIgnore.Select(ExpressionExtensions.PropertyName);
      AreEquivalent(expected, actual, propertyNames.ToArray());
    }
  }
}


