using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
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


