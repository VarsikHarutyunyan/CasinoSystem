using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities;
using CasinoSystem.Data.Repository.Interfaces;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<ApplicationUser> _user;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IJwtProvider _jwtProvider;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRefreshTokenService _refreshTokenService;
        public UserService(IGenericRepository<ApplicationUser> user, IMapper mapper,
            IPasswordService passwordService, IRefreshTokenService refreshTokenService)
        {
            _user = user;
            _mapper = mapper;
            _passwordService = passwordService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task AddAsync(UserCreateModel userModel)
        {
            var user = _mapper.Map<ApplicationUser>(userModel);
            await _user.InsertAsync(user);
            await _user.SaveAsync();

        }
        public async Task<UserModel> GetAsync(int id)
        {
            var userModel = await _user.GetByIdAsync(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<UserModel>(userModel);
            return user;
        }

        public async Task RemoveAsync(int id)
        {
            await _user.DeleteAsync(id); ;
            await _user.SaveAsync();
        }

        public async Task<bool> UpdateAsync(UserModel userModel)
        {
            var user = await _user.GetByIdAsync(userModel.Id);

            if (user == null)
                return false;

            user.Name = userModel.Name;
            user.Surname = userModel.Surname;

            await _user.UpdateAsync(user);
            await _user.SaveAsync();
            return true;
        }

        public UserModel Get(int id)
        {
            var userModel = _user.GetById(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<UserModel>(userModel);
            return user;
        }

        public IQueryable<UserModel> GetAll()
        {
            var users = _user.GetAll();

            if (users == null)
                return null;

            var user = (from item in users

                        select new UserModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Surname = item.Surname,
                        }).AsQueryable();

            return user;
        }

        public async Task<AuthModel> SignInAsync(SignIn command)
        {
            if (!Regexes.EmailRegex.IsMatch(command.Email))
            {

                throw new Exception(command.Email);
            }

            var user =( await _user.GetWhereAsync(_ => _.Email == command.Email)).FirstOrDefault();
            if (user is null || !_passwordService.IsValid(user.PasswordHash, command.Password))
            {
                _logger.LogError($"User with email: {command.Email} was not found.");
                throw new Exception(command.Email);
            }

            if (!_passwordService.IsValid(user.PasswordHash, command.Password))
            {
                _logger.LogError($"Invalid password for user with id: {user.Id}");
                throw new Exception(command.Email);
            }

            var claims = new Dictionary<string, IEnumerable<string>>();

            var auth = _jwtProvider.Create(user.Id, user.Surname, user.Name, user.Email, user.Role, claims: claims);
            auth.RefreshToken = await _refreshTokenService.CreateAsync(user.Id);


            return auth;
        }

        public Task<bool> SignUpAsync(UserCreateModel command)
        {
            throw new NotImplementedException();
        }
    }
}
