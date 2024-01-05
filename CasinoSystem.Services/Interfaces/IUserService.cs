using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Shared;

namespace CasinoSystem.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Get(int id);
        IQueryable<UserModel> GetAll();
        Task AddAsync(UserCreateModel user);
        Task<UserModel> GetAsync(int id);
        Task RemoveAsync(int id);
        Task<bool> UpdateAsync(UserModel user);
        Task<AuthModel> SignInAsync(SignIn command);
        Task<bool> SignUpAsync(UserCreateModel command);
    }
}
