using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> CreateAsync(int userId);
        Task RevokeAsync(string refreshToken);
        Task<AuthModel> UseAsync(string refreshToken);
    }
}
