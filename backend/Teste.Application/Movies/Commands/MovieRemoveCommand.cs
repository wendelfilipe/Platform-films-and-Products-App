using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Application.Movies.Commands
{
    public class MovieRemoveCommand : MovieCommand
    {
        public int Id { get; set; }

        public MovieRemoveCommand(int id)
        {
            Id = id;
        }
    }
}