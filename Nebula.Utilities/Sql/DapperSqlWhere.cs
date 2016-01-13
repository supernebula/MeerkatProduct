using System;
using System.Text;

namespace Nebula.Utilities.Sql
{
    /// <summary>
    /// 
    /// </summary>
    public class DapperSqlWhere
    {

        string sqlMainStatement;

        StringBuilder cdtFragment;
        // List<string> cdtFragment;


        public DapperSqlWhere(string sqlMainStatement)
        {
            this.sqlMainStatement = sqlMainStatement;
            cdtFragment = new StringBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlMainStatement">SELECT * FROM  [TableName]</param>
        /// <returns></returns>
        public static DapperSqlWhere Create(string sqlMainStatement)
        {
            return new DapperSqlWhere(sqlMainStatement);
        }




        #region SQL Where

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public DapperSqlWhere And(string cdt, object value)
        {
            return AddCondition(cdt, value, ConstraintType.And);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">[ColumnName]=@Value1</param>
        /// <param name="value">SqlConditionBuilder</param>
        /// <returns></returns>
        public DapperSqlWhere Or(string cdt, object value)
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
        public DapperSqlWhere Like(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'", ConstraintType type = ConstraintType.And)
        {
            return AddCondition(columnName + SqlFragment.LIKE + String.Format(ruleFormat, paramName), value, ConstraintType.Or);
        }

        public DapperSqlWhere OrLike(string columnName, string paramName, object value, string ruleFormat = "'%' + {0} + '%'")
        {
            return Like(columnName, paramName, value, ruleFormat, ConstraintType.Or);
        }

        DapperSqlWhere AddCondition(string cdt, object value, ConstraintType type)
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


        public DapperSqlWhere AddConditionExpression(Func<DapperSqlWhere, DapperSqlWhere> expression, ConstraintType type)
        {
            var tempBuilder = new DapperSqlWhere(null);
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
        public DapperSqlWhere AndExpression(Func<DapperSqlWhere, DapperSqlWhere> expression)
        {

            return AddConditionExpression(expression, ConstraintType.And);
        }

        /// <summary>
        /// append "Where, And, Or (expression statement)"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public DapperSqlWhere OrExpression(Func<DapperSqlWhere, DapperSqlWhere> expression)
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






}
