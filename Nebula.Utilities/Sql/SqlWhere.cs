using System;
using System.Text;

namespace Nebula.Utilities.Sql
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlWhere
    {

        string sqlMainStatement;

        StringBuilder cdtFragment;
        // List<string> cdtFragment;


        public SqlWhere(string sqlMainStatement)
        {
            this.sqlMainStatement = sqlMainStatement;
            cdtFragment = new StringBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlMainStatement">SELECT * FROM  [TableName]</param>
        /// <returns></returns>
        public static SqlWhere Create(string sqlMainStatement)
        {
            return new SqlWhere(sqlMainStatement);
        }




        #region SQL Where

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public SqlWhere And(string cdt, object value)
        {
            return AddCondition(cdt, value, ConstraintType.And);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public SqlWhere Or(string cdt, object value)
        {
            return AddCondition(cdt, value, ConstraintType.Or);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="paramName">@ParamName</param>
        /// <param name="value"></param>
        /// <param name="ruleFormat"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlWhere Like(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'", ConstraintType type = ConstraintType.And)
        {
            return AddCondition(columnName + SqlFragment.LIKE + String.Format(ruleFormat, paramName), value, ConstraintType.Or);
        }

        public SqlWhere OrLike(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'")
        {
            return Like(columnName, paramName, value, ruleFormat, ConstraintType.Or);
        }

        SqlWhere AddCondition(string cdt, object value, ConstraintType type)
        {
            if (value == null)
                return this;
            if ((value is string) && String.IsNullOrWhiteSpace(value.ToString()))
                return this;
            if (value is Array && ((Array)value).Length == 0)
                return this;
            if (cdtFragment.Length == 0)
                cdtFragment.Append(cdt);
            else
                cdtFragment.Append(ConstraintFragment(type) + cdt);
            return this;
        }


        public SqlWhere AddConditionExpression(Func<SqlWhere, SqlWhere> expression, ConstraintType type)
        {
            var tempBuilder = new SqlWhere(null);
            expression.Invoke(tempBuilder);
            if (tempBuilder.cdtFragment.Length == 0)
                return this;
            if (cdtFragment.Length > 0)
                cdtFragment.Append(ConstraintFragment(type));
            cdtFragment.Append("(" + tempBuilder.cdtFragment + ")");
            return this;
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlWhere AndExpression(Func<SqlWhere, SqlWhere> expression)
        {

            return AddConditionExpression(expression, ConstraintType.And);
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlWhere OrExpression(Func<SqlWhere, SqlWhere> expression)
        {
            return AddConditionExpression(expression, ConstraintType.Or);
        }

        #endregion

        #region Order by

        #endregion


        /// <summary>
        /// return complete sql statement
        /// </summary>
        /// <returns></returns>
        public string ToSqlString()
        {
            if (cdtFragment.Length == 0)
                return sqlMainStatement;
            return String.Format("{0}{1}{2}", sqlMainStatement, SqlFragment.WHERE, cdtFragment.ToString());
        }

        /// <summary>
        /// return Where statement
        /// </summary>
        /// <returns></returns>
        public string ToSqlCdtString()
        {
            if (cdtFragment.Length == 0)
                return String.Empty;
            return String.Format("{0}{1}", SqlFragment.WHERE, cdtFragment.ToString());
        }

        /// <summary>
        /// return only condition statement
        /// </summary>
        /// <returns></returns>
        public string ToOnlyCdtString()
        {
            if (cdtFragment.Length == 0)
                return String.Empty;
            return String.Format("{0}", cdtFragment.ToString());
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
                    return SqlFragment.WHERE;
                case ConstraintType.And:
                    return SqlFragment.AND;
                case ConstraintType.Or:
                    return SqlFragment.OR;
                default:
                    return SqlFragment.AND;
            }
        }
    }



    /// <summary>
    /// Where, And, Or
    /// </summary>
    public enum ConstraintType
    {
        /// <summary>
        /// WHERE operator
        /// </summary>
        Where,
        /// <summary>
        /// AND operator
        /// </summary>
        And,
        /// <summary>
        /// OR Operator
        /// </summary>
        Or
    }


    /// <summary>
    /// Summary for the SqlFragment class
    /// </summary>
    public static class SqlFragment
    {
        public const string AND = " AND ";
        public const string AS = " AS ";
        public const string ASC = " ASC";
        public const string BETWEEN = " BETWEEN ";
        public const string CROSS_JOIN = " CROSS JOIN ";
        public const string DELETE_FROM = "DELETE FROM ";
        public const string DESC = " DESC";
        public const string DISTINCT = "DISTINCT ";
        public const string EQUAL_TO = " = ";
        public const string FROM = " FROM ";
        public const string GROUP_BY = " GROUP BY ";
        public const string HAVING = " HAVING ";
        public const string IN = " IN ";
        public const string LIKE = " LIKE ";

        public const string INNER_JOIN = " INNER JOIN ";

        public const string INSERT_INTO = "INSERT INTO ";
        public const string JOIN_PREFIX = "J";
        public const string LEFT_INNER_JOIN = " LEFT INNER JOIN ";
        public const string LEFT_JOIN = " LEFT JOIN ";
        public const string LEFT_OUTER_JOIN = " LEFT OUTER JOIN ";
        public const string NOT_EQUAL_TO = " <> ";
        public const string NOT_IN = " NOT IN ";
        public const string ON = " ON ";
        public const string OR = " OR ";
        public const string ORDER_BY = " ORDER BY ";
        public const string OUTER_JOIN = " OUTER JOIN ";
        public const string RIGHT_INNER_JOIN = " RIGHT INNER JOIN ";
        public const string RIGHT_JOIN = " RIGHT JOIN ";
        public const string RIGHT_OUTER_JOIN = " RIGHT OUTER JOIN ";
        public const string SELECT = "SELECT ";
        public const string SET = " SET ";
        public const string SPACE = " ";
        public const string TOP = "TOP ";
        public const string UNEQUAL_JOIN = " JOIN ";
        public const string UPDATE = "UPDATE ";
        public const string WHERE = " WHERE ";
    }
}
