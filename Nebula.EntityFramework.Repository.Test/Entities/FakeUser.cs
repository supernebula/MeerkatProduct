using System;
using Nebula.Common;
using Nebula.FirstEC.Compoment;

namespace Nebula.EntityFramework.Repository.Test.Entities
{
    public class FakeUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public GenderType Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }

        public float PersonHeight { get; set; }
        
        public DateTime Birthday { get; set; }

    }
}
