using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Expressions
{
    public interface IConstantValidtor
    {
        bool Validate(object value);
    }
}
