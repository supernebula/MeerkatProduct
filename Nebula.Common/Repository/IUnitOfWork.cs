using System;
using System.Data;

namespace Nebula.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommited { get; }

        void BeginTransaction(IsolationLevel isolationLevel);

        void Commit();

        void RollBack();
    }
}
