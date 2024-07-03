using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Domain.Entites;
using Teste.Domain.Entites.Enums;

namespace Teste.Application.Movies.Commands
{
    public class MovieCommand : IRequest<Movie>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int? Classification { get; set; }
        public string Date { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
    }
}