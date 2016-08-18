﻿using System.Collections.Generic;

namespace Nebula.EntityFramework.Repository
{
    public interface IActiveUnitOfWork
    {
        Dictionary<string, NamedDbContext> ActiveDbContexts { get; }

        void AddDbContext(string name, NamedDbContext dbContext);
        NamedDbContext GetDbContext(string name);
    }
}
