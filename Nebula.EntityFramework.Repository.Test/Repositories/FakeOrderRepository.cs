﻿using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Repositories
{
    public class FakeOrderRepository : BasicEntityFrameworkRepository<FakeOrder, FakeEcDbContext>
    {
    }
}
