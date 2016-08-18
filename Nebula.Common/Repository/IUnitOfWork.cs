using System;
using System.Data;

namespace Nebula.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommited { get; }

        bool IsDisposed { get; }

        void BeginTransaction(IUnitOfWorkOptions options);

        void Commit();

        void RollBack();
    }
}
