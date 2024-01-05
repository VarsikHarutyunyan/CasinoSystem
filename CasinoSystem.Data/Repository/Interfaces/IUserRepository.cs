using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities;

namespace CasinoSystem.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetAsync(int id);
        Task<ApplicationUser> GetAsync(string email);
        Task<ApplicationUser> GetAsync(string email, string include);
        Task<bool> AddAsync(ApplicationUser user);
        Task UpdateAsync(ApplicationUser user);
    }
}
