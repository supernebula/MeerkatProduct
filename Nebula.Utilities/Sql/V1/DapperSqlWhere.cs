using System;
using System.Text;

namespace Nebula.Utilities.Sql.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class DapperSqlWhereBuilder
    {

        string sqlMainStatement;

        StringBuilder cdtFragment;
        // List<string> cdtFragment;


        public DapperSqlWhereBuilder(string sqlMainStatement)
        {
            this.sqlMainStatement = sqlMainStatement;
            cdtFragment = new StringBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlMainStatement">SELECT * FROM  [TableName]</param>
        /// <returns></returns>
        public static DapperSqlWhereBuilder Create(string sqlMainStatement)
        {
            return new DapperSqlWhereBuilder(sqlMainStatement);
        }




        #region SQL Where

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public DapperSqlWhereBuilder And(string cdt, object value)
        {
            return AddCondition(cdt, value, ConstraintType.And);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public DapperSqlWhereBuilder Or(string cdt, object value)
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
        public DapperSqlWhereBuilder Like(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'", ConstraintType type = ConstraintType.And)
        {
            return AddCondition(columnName + SqlSnippet.LIKE + String.Format(ruleFormat, paramName), value, ConstraintType.Or);
        }

        public DapperSqlWhereBuilder OrLike(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'")
        {
            return Like(columnName, paramName, value, ruleFormat, ConstraintType.Or);
        }

        DapperSqlWhereBuilder AddCondition(string cdt, object value, ConstraintType type)
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


        public DapperSqlWhereBuilder AddConditionExpression(Func<DapperSqlWhereBuilder, DapperSqlWhereBuilder> expression, ConstraintType type)
        {
            var tempBuilder = new DapperSqlWhereBuilder(null);
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
        public DapperSqlWhereBuilder AndExpression(Func<DapperSqlWhereBuilder, DapperSqlWhereBuilder> expression)
        {

            return AddConditionExpression(expression, ConstraintType.And);
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public DapperSqlWhereBuilder OrExpression(Func<DapperSqlWhereBuilder, DapperSqlWhereBuilder> expression)
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
            return String.Format("{0}{1}{2}", sqlMainStatement, SqlSnippet.WHERE, cdtFragment.ToString());
        }

        /// <summary>
        /// return Where statement
        /// </summary>
        /// <returns></returns>
        public string ToSqlCdtString()
        {
            if (cdtFragment.Length == 0)
                return String.Empty;
            return String.Format("{0}{1}", SqlSnippet.WHERE, cdtFragment.ToString());
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
