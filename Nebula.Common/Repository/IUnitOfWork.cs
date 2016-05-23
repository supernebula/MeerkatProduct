﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
