using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Teste.Application.DTOs;
using Teste.Application.Interfaces;
using Teste.Application.Movies.Commands;
using Teste.Application.Movies.Queries;
using Teste.Domain.Entites.Enums;

namespace Teste.Application.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public MovieServices(
            IMapper mapper, 
            IMediator mediator
        )
        {
            this.mapper = mapper;
            this.mediator = mediator;    
        }

        public async Task CreateMovieAsync(MovieDTO movieDTO)
        {
           var movieCreateCommand = mapper.Map<MovieCreateCommand>(movieDTO);
           await mediator.Send(movieCreateCommand);

        }

        public async Task DeleteMovieAsync(int id)
        {
            var movieRemoveCommand = new MovieRemoveCommand(id);

            if(movieRemoveCommand == null)
                throw new Exception("Entity could not be found");
            
            await mediator.Send(movieRemoveCommand);
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var getAllMovies = new GetAllMoviesQuery();

            if(getAllMovies == null)
                throw new Exception("Entity could not be found");

            var movies = await mediator.Send(getAllMovies);

            return mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var getMovieById = new GetMovieByIdQuery(id);

            if(getMovieById == null)
                throw new Exception("Entity could not be found");

            var movie = await mediator.Send(getMovieById);

            return mapper.Map<MovieDTO>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> GetMovieByNameAsync(string name)
        {
            var getMovieByName = new GetMoviesByNameQuery(name);

            if(getMovieByName == null)
                throw new Exception("Entity could not be found");

            var movies = await mediator.Send(getMovieByName);

            return mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByGender(Gender gender)
        {
            var getMoviesByGender = new GetMoviesByGenderQuery(gender);

            if(getMoviesByGender == null)
                throw new Exception("Entity could not be found");

            var movies = await mediator.Send(getMoviesByGender);

            return mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task UpdateMovieAsync(MovieDTO movieDTO)
        {
            var movieUpdateCommand = mapper.Map<MovieUpdateCommand>(movieDTO); 
            await mediator.Send(movieUpdateCommand);
        }
    }
}