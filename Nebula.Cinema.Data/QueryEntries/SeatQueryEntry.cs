using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;

namespace Nebula.Cinema.Data.QueryEntries
{
    public class SeatQueryEntry : ISeatQueryEntry
    {
        public Seat Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Seat> Retrieve(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> RetrieveAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Seat> RetrievePaged(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Seat>> RetrievePagedAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
