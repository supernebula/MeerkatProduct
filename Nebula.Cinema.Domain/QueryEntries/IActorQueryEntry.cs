using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;
using Nebula.Domain.Data;

namespace Nebula.Cinema.Domain.QueryEntries
{
    public interface IActorQueryEntry : IQueryEntry
    {
        Actor Fetch(Guid id);

        Task<Actor> FetchAsync(Guid id);

        List<Actor> Retrieve(ActorQueryParameter param);

        Task<List<Actor>> RetrieveAsync(ActorQueryParameter param);

        IPaged<Actor> RetrievePaged(ActorQueryParameter param);

        Task<IPaged<Actor>> RetrievePagedAsync(ActorQueryParameter param);
    }
}
