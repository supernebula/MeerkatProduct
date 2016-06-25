using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common.Cqrs
{
    public interface ICommandHandler<T> where T : Command, new()
    {
        void Execute(T command);
    }
}
