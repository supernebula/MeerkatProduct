using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;
using Nebula.Domain.Data;

namespace Nebula.Cinema.Domain.QueryEntries
{
    public interface ISeatQueryEntry : IQueryEntry
    {
        Seat Fetch(Guid id);

        Task<Seat> FetchAsync(Guid id);

        List<Seat> Retrieve(ActorQueryParameter param);

        Task<List<Seat>> RetrieveAsync(ActorQueryParameter param);

        IPaged<Seat> RetrievePaged(ActorQueryParameter param);

        IPaged<Seat> RetrievePagedAsync(ActorQueryParameter param);
    }
}
