using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Test.Interface
{
    public interface ITagService
    {
        IEnumerable<object> RetriveByCategory(Guid id);

        int Update(object tag);

        int Insert(object tag);

        int Delete(object tag);
    }
}
