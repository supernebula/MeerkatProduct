using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common;
using Nebula.EntityFramework.Repository.Test.Entities;
using Nebula.EntityFramework.Repository.Test.QueryEntries.Parameters;

namespace Nebula.EntityFramework.Repository.Test.QueryEntries
{
    public class UserQueryEntry
    {
        public FakeUser Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public FakeUser FindAlone(Guid id)
        {
            throw new NotImplementedException();
        }

        public FakeUser Retrieve(UserQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public FakeUser RetrieveAlone(UserQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
