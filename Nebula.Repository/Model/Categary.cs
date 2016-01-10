using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public class Categary : BaseEntity
    {

        public Guid ParentID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
