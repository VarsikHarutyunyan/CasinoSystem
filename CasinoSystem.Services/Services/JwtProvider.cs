using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared.Enums;
using Convey.Auth;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtHandler _jwtHandler;

        public JwtProvider(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        public AuthModel Create(int userId, string firstName, string lastName, string email,
            Role role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null)
        {
            var jwt = _jwtHandler.CreateToken(userId.ToString(), role.ToString(), audience, claims);

            return new AuthModel
            {
                AccessToken = jwt.AccessToken,
                Role = jwt.Role,
                Expires = jwt.Expires,
                Id = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}
