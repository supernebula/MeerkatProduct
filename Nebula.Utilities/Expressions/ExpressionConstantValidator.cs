using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Expressions
{
    public class ExpressionConstantValidator : ExpressionVisitor
    {

        private string CurrentExprBody { get; set; }

        /// <summary>
        /// 常量有效性验证器
        /// </summary>
        private Func<object, bool> ValidateFunc { get; set; }

        /// <summary>
        /// 无效的常量
        /// </summary>
        public List<KeyValuePair<object, bool>> Constants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantValidator"></param>
        public ExpressionConstantValidator(Func<object, bool> validateFunc)
        {
            ValidateFunc = validateFunc;
            Constants = new List<KeyValuePair<object, bool>>();
        }

        /// <summary>
        /// 验证表达式常量节点有效性
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public bool Validate(Expression expr)
        {
            Visit(expr);
            return !Constants.Any(e => e.Value == false);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Constants.Add(new KeyValuePair<object, bool>(node.Value, ValidateFunc(node.Value)));
            return node;
        }
    }
}
