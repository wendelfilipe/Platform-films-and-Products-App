using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Application.DTOs;
using Teste.Domain.Entites.Enums;

namespace Teste.Application.Interfaces
{
    public interface IMovieServices
    {
        public Task<IEnumerable<MovieDTO>> GetAllMoviesAsync();
        public Task<IEnumerable<MovieDTO>> GetMovieByNameAsync(string name);
        public Task<IEnumerable<MovieDTO>> GetMoviesByGender(Gender gender);
        public Task<MovieDTO> GetMovieByIdAsync(int id);
        public Task CreateMovieAsync(MovieDTO movie);
        public Task UpdateMovieAsync(MovieDTO movie);
        public Task DeleteMovieAsync(int id);
    }
}