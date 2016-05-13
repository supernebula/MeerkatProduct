using System;
using Nebula.First.EFRepository.Model;

namespace Nebula.EntityFramework.Repository.Test.Entities
{
    public class TestOrder : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Recipient { get; set; }

        public double Amount { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }

        public int Remark { get; set; }
    }
}
