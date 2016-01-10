using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public abstract class BaseEntity : IEntity
    {
        public Guid ID { get; set; }

        
        public bool MarkDelete { get; set; }


        public DateTime CreateDate { get; set; }

    }
}
