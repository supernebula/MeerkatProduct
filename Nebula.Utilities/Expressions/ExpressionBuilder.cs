using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Expressions
{
    public class ExpressionBuilder<T>
    {
        private Expression<Func<T, bool>> _leftExpression;

        private ExpressionBuilder()
        {
            _leftExpression = p => true;

        }


        public static ExpressionBuilder<T> Create()
        {
            return new ExpressionBuilder<T>();
        }


        public ExpressionBuilder<T> And(Expression<Func<T, bool>> func)
        {
            var binary = Expression.AndAlso(_leftExpression.Body, func.Body);
            _leftExpression = Expression.Lambda<Func<T, bool>>(binary, _leftExpression.Parameters);
            return this;
        }
        
        public string ToBodyString()
        {
            return _leftExpression.Body.ToString();
        }

        public Expression<Func<T, bool>> ToLambda()
        {
            return _leftExpression;
        }


    }
}
