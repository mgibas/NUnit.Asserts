using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace NUnit.Asserts.Compare
{
  public abstract class CompareConstraint : Constraint
  {
    protected CompareConstraint()
    {
      _compareLogic = new CompareLogic();
    }

    protected readonly CompareLogic _compareLogic;

    public CompareConstraint WithoutTypeChecking()
    {
      _compareLogic.Config.IgnoreObjectTypes = true;
      return this;
    }

    public CompareConstraint IgnoreProperty<T>(Expression<Func<T, object>> property)
    {
      IgnoreProperty(property.PropertyName());
      return this;
    }

    public CompareConstraint IgnoreProperty(string property)
    {
      if (_compareLogic.Config.MembersToIgnore == null)
        _compareLogic.Config.MembersToIgnore = new List<string>();
      _compareLogic.Config.MembersToIgnore.Add(property);
      return this;
    }

    public CompareConstraint IgnoreProperties(params string[] propertiesToIgnore)
    {
      foreach (var property in propertiesToIgnore)
      {
        IgnoreProperty(property);
      }
      return this;
    }
  }
}