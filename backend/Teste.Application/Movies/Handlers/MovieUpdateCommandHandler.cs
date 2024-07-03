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
    public class MovieUpdateCommandHandler : IRequestHandler<MovieUpdateCommand, Movie>
    {
        private readonly IMovieRepository movieRepository;

        public MovieUpdateCommandHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<Movie> Handle(
            MovieUpdateCommand request, 
            CancellationToken cancellationToken
        )
        {
            var movie = await movieRepository.GetMovieByIdAsync(request.Id);

            if(movie == null)
                throw new ArgumentException("Error when updating movie, entity could not be found");

            movie.Update(request.Id, request.Name, request.Gender, request.Classification, request.Date, request.Comment, request.Image);

            return await movieRepository.UpdateMovieAsync(movie);
        }
    }
}