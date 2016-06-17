using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Test.Interface;

namespace Code.Test.Implement
{
    public class TagService : ITagService
    {
        public int Delete(object tag)
        {
            return 1;
        }

        public int Insert(object tag)
        {
            return 1;
        }

        public IEnumerable<object> RetriveByCategory(Guid id)
        {
            return null;
        }

        public int Update(object tag)
        {
            return 1;
        }
    }
}
