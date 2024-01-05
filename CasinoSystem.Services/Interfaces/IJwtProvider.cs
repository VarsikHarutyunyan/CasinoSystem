using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Shared.Enums;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Interfaces
{
    public interface IJwtProvider
    {
        AuthModel Create(int userId, string firstName, string lastName, string email, Role role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}
