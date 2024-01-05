using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities;
using CasinoSystem.Data.Repository.Interfaces;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared;

namespace CasinoSystem.Services.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IGenericRepository<RefreshToken> _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRng _rng;

        public RefreshTokenService(IGenericRepository<RefreshToken> refreshTokenRepository,
            IUserRepository userRepository, IJwtProvider jwtProvider, IRng rng)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _rng = rng;
        }

        public async Task<string> CreateAsync(int userId)
        {
            var token = _rng.Generate(30, true);
            var refreshToken = new RefreshToken(new Int32(), userId, token, DateTime.UtcNow);
            await _refreshTokenRepository.InsertAsync(refreshToken);

            return token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = (await _refreshTokenRepository.GetWhereAsync(_=>_.Token== refreshToken) ).FirstOrDefault()?? throw new Exception("Token Invalid");
            token.Revoke(DateTime.UtcNow);
            await _refreshTokenRepository.UpdateAsync(token);
        }

        public async Task<AuthModel> UseAsync(string refreshToken)
        {
            var token = (await _refreshTokenRepository.GetWhereAsync(_ => _.Token == refreshToken)).FirstOrDefault() ?? throw new Exception("Invalid Refresh Token Exception");
            if (token.Revoked)
            {
                throw new Exception();
            }

            var user = await _userRepository.GetAsync(token.UserId) ?? throw new Exception("User Not Found Exception");

            //var claims = user.Permissions.Any()
            //    ? new Dictionary<string, IEnumerable<string>>
            //    {
            //        ["permissions"] = user.Permissions
            //    }
            //    : null;
            var auth = _jwtProvider.Create(token.UserId, user.Surname, user.Name, user.Email, user.Role, claims: null);
            auth.RefreshToken = refreshToken;

            return auth;
        }
    }
}
