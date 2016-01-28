using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Expressions
{
    /// <summary>
    /// 默认常量验证器
    /// </summary>
    class DefaultConstantValidtor : IConstantValidtor
    {
        public bool Validate(object value)
        {
            if (value == null)
                return false;
            if ((value is string) && string.IsNullOrWhiteSpace(value.ToString()))
                return false;
            if (value is Array && ((Array)value).Length == 0)
                return false;
            return true;
        }
    }
}
