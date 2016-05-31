﻿using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.Test.Model;

namespace Nebula.EntityFramework.Repository.Test.Repositories
{
    public class FakeArticleOriginalEfRepository : OriginalEntityFrameworkRepository<FakeArticle, FakeEcDbContext>
    {
        public FakeArticleOriginalEfRepository(FakeEcDbContext dbContext) : base(dbContext)
        {
        }
    }
}
