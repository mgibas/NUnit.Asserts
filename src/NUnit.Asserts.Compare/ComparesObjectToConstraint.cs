using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace NUnit.Asserts.Compare
{
  public class ComparesObjectToConstraint : CompareConstraint
  {
    public ComparesObjectToConstraint(object expectedValue)
    {
      _expectedValue = expectedValue;
    }

    private ComparisonResult _comparisonResult;

    private readonly object _expectedValue;

    public override bool Matches(object actualValue)
    {
      actual = actualValue;

      _comparisonResult = _compareLogic.Compare(actualValue, _expectedValue);

      return _comparisonResult.AreEqual;
    }

    public override void WriteDescriptionTo(MessageWriter writer)
    {
      if (_comparisonResult != null)
      {
        writer.Write("Compared objects are not equal, please inspect differences:\n\n{0}", _comparisonResult.DifferencesString);
      }
    }
  }
}