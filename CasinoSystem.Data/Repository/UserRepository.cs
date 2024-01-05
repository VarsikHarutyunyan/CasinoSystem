using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Data.DataContext;
using CasinoSystem.Data.Entities;
using CasinoSystem.Data.Repository.Interfaces;

namespace CasinoSystem.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CasinoContext _dbContext;
        public UserRepository(CasinoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            return user;
        }

        public async Task<ApplicationUser> GetAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());
            return user;
        }

        public async Task<bool> AddAsync(ApplicationUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<ApplicationUser> GetAsync(string email, string include)
        {
            var user = await _dbContext.Users.Include(include)
                      .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());
            return user;
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

        }
    }
}
