using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public class Spec
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
