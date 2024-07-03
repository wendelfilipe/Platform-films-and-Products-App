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
    public class GetMoviesByGenderQueryHandler : IRequestHandler<GetMoviesByGenderQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository movieRepository;
        public GetMoviesByGenderQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<IEnumerable<Movie>> Handle(
            GetMoviesByGenderQuery request, 
            CancellationToken cancellationToken
        )
        {
            return await movieRepository.GetMoviesByGender(request.Gender);
        }
    }
}