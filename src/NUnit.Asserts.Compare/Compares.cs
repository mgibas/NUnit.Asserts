using System.Collections;

namespace NUnit.Asserts.Compare
{
  public class Compares
  {
    public static ComparesObjectToConstraint To<T>(T expected)
    {
      return new ComparesObjectToConstraint(expected);
    }

    public static ComparesCollectionToConstraint ToAnyIn(IEnumerable collection)
    {
      return new ComparesCollectionToConstraint(collection);
    }
  }
}