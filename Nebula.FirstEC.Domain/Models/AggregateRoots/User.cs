using System;
using Evol.Common;

namespace Evol.FirstEC.Domain.Models.AggregateRoots
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string RealName { get; set; }
        public GenderType Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }

        public DateTime Birthday { get; set; }
    }
}
