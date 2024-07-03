using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entites;
using Teste.Domain.Interfaces;
using Teste.Infra.Data.Context;

namespace Teste.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByMovieId(int movieId)
        {
            return await context.Users.Where(us => us.MovieId == movieId).ToListAsync();
        }
    }
}