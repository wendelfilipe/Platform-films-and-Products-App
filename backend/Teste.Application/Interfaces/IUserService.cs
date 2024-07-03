using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Application.DTOs;

namespace Teste.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetUsersByMovieId(int movieId);
        public Task CreateUser(UserDTO userDTO);
    }
}