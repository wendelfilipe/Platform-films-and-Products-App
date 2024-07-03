using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Domain.Entites;

namespace Teste.Application.Users.Commands
{
    public class UserCommand : IRequest<User>
    {
        public int? Classification { get; set; }
        public int MovieId { get; set; }
    }
}