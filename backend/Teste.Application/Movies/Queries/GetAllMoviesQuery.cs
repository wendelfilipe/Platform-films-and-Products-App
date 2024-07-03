using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Domain.Entites;

namespace Teste.Application.Movies.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {
    }
}