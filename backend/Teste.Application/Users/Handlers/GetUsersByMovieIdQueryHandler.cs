using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Application.Users.Queries;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;

namespace Teste.Application.Users.Handlers
{
    public class GetUsersByMovieIdQueryHandler : IRequestHandler<GetUsersByMovieIdQuery, IEnumerable<User>>
    {
        private readonly IUserRepository userRepository;
        public GetUsersByMovieIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> Handle(
            GetUsersByMovieIdQuery request, 
            CancellationToken cancellationToken
        )
        {
           return await userRepository.GetUsersByMovieId(request.MovieId);
        }
    }
}