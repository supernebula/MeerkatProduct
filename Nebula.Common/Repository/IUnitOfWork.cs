using System;

namespace Nebula.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommited { get; }

        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}
