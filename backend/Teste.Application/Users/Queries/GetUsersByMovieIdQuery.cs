using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Domain.Entites;

namespace Teste.Application.Users.Queries
{
    public class GetUsersByMovieIdQuery : IRequest<IEnumerable<User>>
    {
        public int MovieId { get; set; }

        public GetUsersByMovieIdQuery(int movieId)
        {
            MovieId = movieId;
        }
    }
}