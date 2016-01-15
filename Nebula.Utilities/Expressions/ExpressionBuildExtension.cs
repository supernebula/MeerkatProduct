using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Expressions
{
    public static class ExpressionBuildExtension
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = left.Parameters.Select((f, i) => new { f, s = right.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

                          // replace parameters in the second lambda expression with parameters from the first  
            var rightBody = ParameterRebinder.ReplaceParameters(map, right.Body);

            var expression = Expression.AndAlso(left.Body, right.Body);
            var result = Expression.Lambda<Func<T, bool>>(expression, left.Parameters);
            return result;
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
