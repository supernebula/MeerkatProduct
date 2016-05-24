using Nebula.FirstEC.Compoment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository.Test.Entities
{
    public class FakeArticle : BaseEntity
    {
        public string Title { get; set; }

        public string Tag { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}
