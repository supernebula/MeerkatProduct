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
    public interface IScreeningQueryEntry : IQueryEntry
    {
        Screening Fetch(Guid id);

        Task<Screening> FetchAsync(Guid id);

        List<Screening> Retrieve(ScreeningQueryParameter param);

        Task<List<Screening>> RetrieveAsync(ScreeningQueryParameter param);

        IPaged<Screening> RetrievePaged(ScreeningQueryParameter param);

        IPaged<Screening> RetrievePagedAsync(ScreeningQueryParameter param);
    }
}
