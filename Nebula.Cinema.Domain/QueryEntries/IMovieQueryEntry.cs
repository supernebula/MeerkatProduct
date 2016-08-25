using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Common;
using Nebula.Domain.Data;

namespace Nebula.Cinema.Domain.QueryEntries
{
    public interface IMovieQueryEntry : IQueryEntry
    {
        Movie Fetch(Guid id);

        Task<Movie> FetchAsync(Guid id);

        List<Movie> Retrieve(MovieQueryParameter param);

        Task<List<Movie>> RetrieveAsync(MovieQueryParameter param);

        IPaged<Movie> RetrievePaged(MovieQueryParameter param);

        Task<IPaged<Movie>> RetrievePagedAsync(MovieQueryParameter param);
    }
}
