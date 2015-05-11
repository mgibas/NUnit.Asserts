using System;
using System.Linq.Expressions;

namespace NUnit.Asserts.Compare
{
  static internal class ExpressionExtensions
  {
    public static string PropertyName<TModel>(this Expression<Func<TModel, object>> @this)
    {
      var body = @this.Body as MemberExpression;

      if (body == null)
      {
        var ubody = (UnaryExpression)@this.Body;
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