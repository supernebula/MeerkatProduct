using System;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class UnitOfWorkDbContextFactory : IUnitOfWorkDbContextFactory
    {
        [Dependency]
        public IActiveUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        public TDbContext Create<TDbContext>() where TDbContext : NamedDbContext
        {
            var context = Activator.CreateInstance<TDbContext>();
            UnitOfWork.AddDbContext(context.Name, context);
            return context;
        }

    }
}
