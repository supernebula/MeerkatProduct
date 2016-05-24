using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nebula.Utilities.Sql
{


    public class SqlWhereBuilder
    {
        class SqlParameterComparer : IEqualityComparer<SqlParameter>
        {
            public bool Equals(SqlParameter x, SqlParameter y)
            {
                return x.ParameterName == y.ParameterName;
            }

            public int GetHashCode(SqlParameter obj)
            {
                return obj.ParameterName.GetHashCode();
            }
        }

        private StringBuilder Conditions { get; set; }
        private List<SqlParameter> SqlParameters { get; set; }

        public SqlWhereBuilder()
        {
            Conditions = new StringBuilder();
            SqlParameters = new List<SqlParameter>();
        }

        public static SqlWhereBuilder Create()
        {
            return new SqlWhereBuilder();
        }

        /// <summary>
        /// 追加Add条件表达式
        /// </summary>
        /// <param name="conditionFormat">条件表达式，如：[Id] = {0}</param>
        /// <param name="paramName">SqlParameter的参数名，如：@id， <see cref="SqlParameter"/></param>
        /// <param name="paramValue">SqlParameter的参数值</param>
        /// <returns></returns>
        public SqlWhereBuilder And(string conditionFormat, string paramName, object paramValue)
        {
            AppendCondition(WhereLogicType.And, conditionFormat, paramName, paramValue);
            return this;
        }

        /// <summary>
        /// 追加Or条件表达式
        /// </summary>
        /// <param name="conditionFormat">条件表达式，如：[Id] = {0}</param>
        /// <param name="paramName">SqlParameter的参数名，如：@id <see cref="SqlParameter"/></param>
        /// <param name="paramValue">SqlParameter的参数值</param>
        /// <returns></returns>
        public SqlWhereBuilder Or(string conditionFormat, string paramName, object paramValue)
        {
            AppendCondition(WhereLogicType.Or, conditionFormat, paramName, paramValue);
            return this;
        }

        /// <summary>
        /// 追加逻辑条件表达式
        /// </summary>
        /// <param name="conditionFormat">条件表达式</param>
        /// <param name="paramName">SqlParameter的参数名</param>
        /// <param name="paramValue">SqlParameter的参数值</param>
        /// <param name="logicType">逻辑运算符</param>
        /// <returns></returns>
        public SqlWhereBuilder AppendCondition(WhereLogicType logicType, string conditionFormat, string paramName, object paramValue)
        {
            var condition = string.Format(conditionFormat, paramName);
            if (paramValue == null)
                return this;
            if ((paramValue is string) && String.IsNullOrWhiteSpace(paramValue.ToString()))
                return this;
            if (paramValue is Array && ((Array)paramValue).Length == 0)
                return this;

            if (Conditions.Length == 0)
                Conditions.Append(condition);
            else
                Conditions.Append(ConstraintFragment(logicType) + condition);
            SqlParameters.Add(new SqlParameter(paramName, paramValue));
            return this;
        }

        /// <summary>
        /// 追加Add条件表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlWhereBuilder AndExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression)
        {
            return AppendConditionExpression(expression, WhereLogicType.And);
        }

        public SqlWhereBuilder OrExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression)
        {
            return AppendConditionExpression(expression, WhereLogicType.Or);
        }

        public SqlWhereBuilder AppendConditionExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression, WhereLogicType type)
        {
            var tempBuilder = new SqlWhereBuilder();
            expression.Invoke(tempBuilder);
            if (tempBuilder.Conditions.Length == 0)
                return this;
            if (Conditions.Length > 0)
                Conditions.Append(ConstraintFragment(type));
            Conditions.Append("(" + tempBuilder.Conditions + ")");
            SqlParameters.AddRange(tempBuilder.SqlParameters);
            return this;
        }


        public List<SqlParameter> ToSqlParameters()
        {
            return SqlParameters.Distinct(new SqlParameterComparer()).ToList();
        }


        public string ToWhereString()
        {
            if (Conditions.Length == 0)
                return String.Empty;
            return $"{SqlSnippet.WHERE}{Conditions}";
        }

        public string ToConditionString()
        {
            if (Conditions.Length == 0)
                return String.Empty;
            return Conditions.ToString();
        }

        public override string ToString()
        {
            return ToConditionString();
        }


        string ConstraintFragment(WhereLogicType type)
        {
            switch (type)
            {
                case WhereLogicType.And:
                    return SqlSnippet.AND;
                case WhereLogicType.Or:
                    return SqlSnippet.OR;
                default:
                    return SqlSnippet.AND;
            }
        }
    }
}
