using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;
using Nebula.Domain.Data;

namespace Nebula.Cinema.Domain.QueryEntries
{
    public interface IScreeningRoomQueryEntry : IQueryEntry
    {
        ScreeningRoom Fetch(Guid id);

        Task<ScreeningRoom> FetchAsync(Guid id);

        List<ScreeningRoom> Retrieve(ScreeningRoomQueryParameter param);

        Task<List<ScreeningRoom>> RetrieveAsync(ScreeningQueryParameter param);

        IPaged<ScreeningRoom> RetrievePaged(ScreeningQueryParameter param);

        IPaged<ScreeningRoom> RetrievePagedAsync(ScreeningQueryParameter param);
    }
}
