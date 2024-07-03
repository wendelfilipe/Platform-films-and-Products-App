using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Application.Movies.Queries;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;

namespace Teste.Application.Movies.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly IMovieRepository movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await movieRepository.GetMovieByIdAsync(request.Id);
        }
    }
}