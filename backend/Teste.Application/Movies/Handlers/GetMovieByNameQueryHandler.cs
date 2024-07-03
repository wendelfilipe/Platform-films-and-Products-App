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
    public class GetMovieByNameQueryHandler : IRequestHandler<GetMoviesByNameQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository movieRepository;

        public GetMovieByNameQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(
            GetMoviesByNameQuery request, 
            CancellationToken cancellationToken
        )
        {
            return await movieRepository.GetMovieByNameAsync(request.Name);
        }
    }
}