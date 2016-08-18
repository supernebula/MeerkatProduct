using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class UnitOfWorkOptions : IUnitOfWorkOptions
    {
        public System.Data.IsolationLevel? IsolationLevel { get; set; }

        public bool IsTransactional { get; set; }

        public System.Transactions.TransactionScopeOption TransactionScope { get; set; }
    }
}
