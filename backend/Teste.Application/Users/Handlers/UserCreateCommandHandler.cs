using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Teste.Application.Users.Commands;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;

namespace Teste.Application.Users.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository userRepository;
        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> Handle(
            UserCreateCommand request, 
            CancellationToken cancellationToken
        )
        {
            var user = new User(request.Classification, request.MovieId);

            if(user == null)
                throw new ArgumentException("Error creating entity user");

            return await userRepository.CreateUser(user);
        }
    }
}