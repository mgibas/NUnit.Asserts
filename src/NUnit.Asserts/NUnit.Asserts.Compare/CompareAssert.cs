using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;

namespace NUnit.Asserts.Compare
{
  public class CompareAssert
  {
    public static void Compare(object expected, object actual, params string[] propertiesToIgnore)
    {
      var compareConfig = new ComparisonConfig { MembersToIgnore = new List<string>(propertiesToIgnore) };
      ComparisonResult compareResult = new CompareLogic(compareConfig).Compare(expected, actual);
      Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal, please inspect differences:\n\n{0}", compareResult.DifferencesString);
    }
  }
}


