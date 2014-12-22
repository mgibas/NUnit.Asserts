using System.Collections.Generic;
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
    /// <param name="propertiesToIgnore">Properties that should be ignored when comparing objects</param>
    public static void AreEqual(object expected, object actual, params string[] propertiesToIgnore)
    {
      var compareConfig = new ComparisonConfig { MembersToIgnore = new List<string>(propertiesToIgnore) };
      ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(expected, actual);
      Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal, please inspect differences:\n\n{0}", compareResult.DifferencesString);
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
  }
}


