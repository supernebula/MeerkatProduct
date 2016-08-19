﻿using System;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class DefualtDbContextFactory : IDbContextFactory
    {
        [Dependency]
        public IActiveUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        public TDbContext Create<TDbContext>() where TDbContext : NamedDbContext
        {
            foreach (var item in UnitOfWork.ActiveDbContexts.Values)
            {
                if (item.GetType() == typeof (TDbContext))
                    return (TDbContext)item;
            }
            var context = Activator.CreateInstance<TDbContext>();
            UnitOfWork.AddDbContext(context.Name, context);
            return context;
        }
    }
}