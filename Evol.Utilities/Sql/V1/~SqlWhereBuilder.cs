using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Evol.Utilities.Sql.V1
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


        string sqlMainStatement;

        StringBuilder cdtFragment;
        List<SqlParameter> sqlParameters;
        // List<string> cdtFragment;


        public SqlWhereBuilder(string sqlMainStatement)
        {
            this.sqlMainStatement = sqlMainStatement;
            sqlParameters = new List<SqlParameter>();
            cdtFragment = new StringBuilder();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlMainStatement">如：SELECT * FROM  [TableName]</param>
        /// <returns></returns>
        public static SqlWhereBuilder Create(string sqlMainStatement)
        {
            return new SqlWhereBuilder(sqlMainStatement);
        }




        #region SQL Where

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition">参数化SQL条件表达式</param>
        /// <param name="paramName">SQL参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public SqlWhereBuilder And(string condition, string paramName, object value)
        {
            return AddCondition(condition, paramName, value, ConstraintType.And);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition">参数化SQL条件表达式</param>
        /// <param name="paramName">SQL参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public SqlWhereBuilder Or(string condition, string paramName, object value)
        {
            return AddCondition(condition, paramName, value, ConstraintType.Or);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="paramName">SQL参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="ruleFormat"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlWhereBuilder Like(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'", ConstraintType type = ConstraintType.And)
        {
            return AddCondition(columnName + SqlSnippet.LIKE + String.Format(ruleFormat, paramName), paramName, value, ConstraintType.Or);
        }

        public SqlWhereBuilder OrLike(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'")
        {
            return Like(columnName, paramName, value, ruleFormat, ConstraintType.Or);
        }

        SqlWhereBuilder AddCondition(string condition, string paramName, object value, ConstraintType type)
        {
            condition = String.Format(condition, paramName);
            if (value == null)
                return this;
            if ((value is string) && String.IsNullOrWhiteSpace(value.ToString()))
                return this;
            if (value is Array && ((Array)value).Length == 0)
                return this;

            if (cdtFragment.Length == 0)
                cdtFragment.Append(condition);
            else
                cdtFragment.Append(ConstraintFragment(type) + condition);

            sqlParameters.Add(new SqlParameter(paramName, value));
            return this;
        }


        public SqlWhereBuilder AddConditionExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression, ConstraintType type)
        {
            var tempBuilder = new SqlWhereBuilder(null);
            expression.Invoke(tempBuilder);
            if (tempBuilder.cdtFragment.Length == 0)
                return this;
            if (cdtFragment.Length > 0)
                cdtFragment.Append(ConstraintFragment(type));
            cdtFragment.Append("(" + tempBuilder.cdtFragment + ")");
            sqlParameters.AddRange(tempBuilder.sqlParameters);
            return this;
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlWhereBuilder AndExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression)
        {

            return AddConditionExpression(expression, ConstraintType.And);
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlWhereBuilder OrExpression(Func<SqlWhereBuilder, SqlWhereBuilder> expression)
        {
            return AddConditionExpression(expression, ConstraintType.Or);
        }

        #endregion

        #region Order by

        #endregion

        public List<SqlParameter> ToSqlParameters()
        {
            return sqlParameters.Distinct(new SqlParameterComparer()).ToList();
        }

        /// <summary>
        /// return complete sql statement
        /// </summary>
        /// <returns></returns>
        public string ToSqlString()
        {
            if (cdtFragment.Length == 0)
                return sqlMainStatement;
            return String.Format("{0}{1}{2}", sqlMainStatement, SqlSnippet.WHERE, cdtFragment);
        }

        /// <summary>
        /// return Where statement
        /// </summary>
        /// <returns></returns>
        public string ToWhereString()
        {
            if (cdtFragment.Length == 0)
                return String.Empty;
            return String.Format("{0}{1}", SqlSnippet.WHERE, cdtFragment);
        }

        /// <summary>
        /// return only condition statement
        /// </summary>
        /// <returns></returns>
        public string ToOnlyConditionString()
        {
            if (cdtFragment.Length == 0)
                return String.Empty;
            return String.Format("{0}", cdtFragment);
        }

        /// <summary>
        /// return complete sql statement
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToSqlString();
        }

        string ConstraintFragment(ConstraintType type)
        {
            switch (type)
            {
                case ConstraintType.Where:
                    return SqlSnippet.WHERE;
                case ConstraintType.And:
                    return SqlSnippet.AND;
                case ConstraintType.Or:
                    return SqlSnippet.OR;
                default:
                    return SqlSnippet.AND;
            }
        }
    }


    
}
