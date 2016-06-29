using System;
using System.Data;

namespace Nebula.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommited { get; }

        IDbTransaction BeginTransaction();

        void Commit();

        void RollBack();
    }
}
