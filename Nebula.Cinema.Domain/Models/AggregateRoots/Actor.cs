using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class Actor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
