﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;

namespace Evol.Cinema.Data.QueryEntries
{
    public class ActorQueryEntry : IActorQueryEntry
    {
        public Actor Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Actor> Retrieve(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Actor>> RetrieveAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Actor> RetrievePaged(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Actor>> RetrievePagedAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
