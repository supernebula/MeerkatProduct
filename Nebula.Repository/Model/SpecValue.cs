using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.First.EFRepository.Model
{
    public class SpecValue : BaseEntity
    {

        public Guid SpecID { get; set; }

        public string Value { get; set; }
    }
}
