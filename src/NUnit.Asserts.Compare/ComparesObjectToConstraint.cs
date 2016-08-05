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

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            _comparisonResult = _compareLogic.Compare(actual, _expectedValue);

            return new ConstraintResult(this, actual, _comparisonResult.AreEqual);
        }

        public override string Description
        {
            get
            {
                if (_comparisonResult != null)
                {
                    return string.Format("Compared objects are not equal, please inspect differences:\n\n{0}", _comparisonResult.DifferencesString);
                }
                return "";
            }
        }
    }
}