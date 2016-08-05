using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
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

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {

            foreach (var item in _collection)
            {
                var compareResult = _compareLogic.Compare(item, actual);
                if (compareResult.AreEqual) return new ConstraintResult(this, actual, true);
                _comparisonResults.Add(compareResult);
            }

            return new ConstraintResult(this, actual, false);
        }

        public override string Description
        {
            get
            {
                return _comparisonResults.Any() ? string.Format("Could not find item in collection.Please inspect differences:\n\n{0}", _comparisonResults.Select(m => m.DifferencesString).Aggregate((i, j) => i + "\n" + j)) : "";
            }
        }
    }
}