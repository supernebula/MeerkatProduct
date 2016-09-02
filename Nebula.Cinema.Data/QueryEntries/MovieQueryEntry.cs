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
    public class MovieQueryEntry : IMovieQueryEntry
    {
        public Movie Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> Retrieve(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> RetrieveAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Movie> RetrievePaged(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Movie>> RetrievePagedAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
