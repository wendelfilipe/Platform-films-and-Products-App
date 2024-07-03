using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Application.Movies.Commands;
using Teste.Application.Movies.Queries;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;

namespace Teste.Application.Movies.Handlers
{
    public class MovieCreateCommandHandler : IRequestHandler<MovieCreateCommand, Movie>
    {
        private readonly IMovieRepository movieRepository;

        public MovieCreateCommandHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<Movie> Handle(
            MovieCreateCommand request, 
            CancellationToken cancellationToken
        )
        {
            var movie = new Movie(request.Name, request.Gender, request.Classification, request.Date, request.Comment, request.Image);

            if( movie == null)
                throw new ArgumentException("Error creating entity movie");

            
            return  await movieRepository.CreateMovieAsync(movie);

            
        }
    }
}