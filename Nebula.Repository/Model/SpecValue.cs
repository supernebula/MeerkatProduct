using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public class SpecValue
    {
        public Guid ID { get; set; }

        public Guid SpecID { get; set; }

        public string Value { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
