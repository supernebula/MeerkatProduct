﻿using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.Cinema.Data.Repositories
{
    public class MovieRepository : BasicEntityFrameworkRepository<Movie, CinemaDbContext>, IMovieRepository
    {
    }
}
