using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Entites;
using Teste.Domain.Entites.Enums;

namespace Teste.Domain.Interfaces
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<IEnumerable<Movie>> GetMovieByNameAsync(string name);
        public Task<IEnumerable<Movie>> GetMoviesByGender(Gender gender);
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<Movie> CreateMovieAsync(Movie movie);
        public Task<Movie> UpdateMovieAsync(Movie movie);
        public Task<Movie> DeleteMovieAsync(Movie movie);
    }
}