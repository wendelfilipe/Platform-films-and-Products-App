using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entites;
using Teste.Domain.Entites.Enums;
using Teste.Domain.Interfaces;
using Teste.Infra.Data.Context;

namespace Teste.Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly AppDbContext context;
        public MovieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            context.Movies.Add(movie);
            await context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> DeleteMovieAsync(Movie movie)
        {
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await context.Movies.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGender(Gender gender)
        {
            return await context.Movies.Where(m => m.Gender == gender).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMovieByNameAsync(string name)
        {
            return await context.Movies.Where(m => m.Name.StartsWith(name)).ToListAsync();
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            context.Movies.Update(movie);
            await context.SaveChangesAsync();

            return movie;
        }
    }
}