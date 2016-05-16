using Nebula.FirstEC.Compoment;

namespace Nebula.EntityFramework.Repository.Test.Entities
{
    public class TestUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
    }
}
