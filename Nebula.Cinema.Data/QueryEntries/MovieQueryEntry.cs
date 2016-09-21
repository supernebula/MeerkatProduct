using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.QueryEntries.Parameters;
using Nebula.Cinema.Domain.Repositories;
using Nebula.Common;

namespace Nebula.Cinema.Data.QueryEntries
{
    public class MovieQueryEntry : IMovieQueryEntry
    {
        [Dependency]
        public IMovieRepository MovieRepository { get; set; }

        public Movie Fetch(Guid id)
        {
            return MovieRepository.Find(id);
        }

        public async Task<Movie> FetchAsync(Guid id)
        {
            return await MovieRepository.FindAsync(id);
        }

        public List<Movie> Retrieve(MovieQueryParameter param)
        {
            throw new NotImplementedException();
            
            //Func<Movie, bool> predicate = (m) => true;
            //if (!string.IsNullOrWhiteSpace(param.Name))
            //{
            //    var predicate1 = predicate;
            //    predicate = (m) => predicate1(m) && m.Name.Contains(param.Name);
            //}
            //if (param.Name != null)
            //{
            //    var predicate2 = predicate;
            //    predicate = (m) => predicate2(m) && m.Name.Contains(param.Name);
            //}
            //MovieRepository.Retrieve(e => e)
        }

        public Task<List<Movie>> RetrieveAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Movie> Paged(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Movie>> PagedAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
