using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;

namespace Nebula.Cinema.Data.QueryEntries
{
    public class ScreeningRoomQueryEntry : IScreeningRoomQueryEntry
    {
        public ScreeningRoom Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ScreeningRoom> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ScreeningRoom> Retrieve(ScreeningRoomQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScreeningRoom>> RetrieveAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<ScreeningRoom> RetrievePaged(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<ScreeningRoom>> RetrievePagedAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
