using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Application.Movies.Commands;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;

namespace Teste.Application.Movies.Handlers
{
    public class MovieRemoveCommandHandler : IRequestHandler<MovieRemoveCommand, Movie>
    {
        private readonly IMovieRepository movieRepository;

        public MovieRemoveCommandHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<Movie> Handle(
            MovieRemoveCommand request, 
            CancellationToken cancellationToken
        )
        {
            var movie = await movieRepository.GetMovieByIdAsync(request.Id);

            if(movie == null)
                throw new ArgumentException("Erro when deleting movie, entity could not be found");

            return await movieRepository.DeleteMovieAsync(movie);
        }
    }
}