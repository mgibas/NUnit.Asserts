using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace NUnit.Asserts.Compare
{
  public class ComparesCollectionToConstraint : CompareConstraint
  {
    public ComparesCollectionToConstraint(IEnumerable collection)
    {
      _comparisonResults = new List<ComparisonResult>();
      _collection = collection;
    }

    private readonly List<ComparisonResult> _comparisonResults;

    private readonly IEnumerable _collection;

    public override bool Matches(object expectedItem)
    {
      actual = expectedItem;

      foreach (var item in _collection)
      {
        var compareResult = _compareLogic.Compare(item, actual);
        if (compareResult.AreEqual) return true;
        _comparisonResults.Add(compareResult);
      }
      return false;
    }

    public override void WriteDescriptionTo(MessageWriter writer)
    {
      if (_comparisonResults.Any())
      {
        writer.Write("Could not find item in collection.Please inspect differences:\n\n{0}", _comparisonResults.Select(m => m.DifferencesString).Aggregate((i, j) => i + "\n" + j));
      }
    }
  }
}