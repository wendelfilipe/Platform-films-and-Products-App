using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Domain.Entites;
using Teste.Domain.Entites.Enums;

namespace Teste.Application.Movies.Queries
{
    public class GetMoviesByGenderQuery : IRequest<IEnumerable<Movie>>
    {
        public Gender Gender { set; get; }

        public GetMoviesByGenderQuery(Gender gender)
        {
            Gender = gender;
        }
    }
}