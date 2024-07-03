using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Application.Movies.Commands
{
    public class MovieUpdateCommand : MovieCommand
    {
        public int Id { get; set; }
    }
}