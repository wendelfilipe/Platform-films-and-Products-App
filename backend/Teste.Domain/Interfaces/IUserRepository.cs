using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Entites;

namespace Teste.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersByMovieId(int movieId);
        public Task<User> CreateUser(User user);
    }
}