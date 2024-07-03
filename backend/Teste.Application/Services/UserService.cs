using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Teste.Application.DTOs;
using Teste.Application.Interfaces;
using Teste.Application.Users.Commands;
using Teste.Application.Users.Queries;

namespace Teste.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public UserService(
            IMapper mapper,
            IMediator mediator 
        )
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task CreateUser(UserDTO userDTO)
        {
            var user = mapper.Map<UserCreateCommand>(userDTO);
            await mediator.Send(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByMovieId(int movieId)
        {
            var getUsersByMovieIdQuery = new GetUsersByMovieIdQuery(movieId);

            if(getUsersByMovieIdQuery == null)
                throw new Exception("Entity user can not be found");

            var users = await mediator.Send(getUsersByMovieIdQuery);

            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}