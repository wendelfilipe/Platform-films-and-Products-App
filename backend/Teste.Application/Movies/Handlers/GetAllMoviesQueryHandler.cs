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
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {

        private readonly IMovieRepository movieRepository;
        public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(
            GetAllMoviesQuery request,
            CancellationToken cancellationToken
        )
        {
            return await movieRepository.GetAllMoviesAsync();
        }
    }
}