using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Utilities.Sql.V1
{

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
}
