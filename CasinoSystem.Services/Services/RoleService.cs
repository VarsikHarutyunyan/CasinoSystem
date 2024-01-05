using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using CasinoSystem.Data.Entities;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<CasinoRole> _roleManager;
        
        public RoleService(RoleManager<CasinoRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<bool> AddClaimToRole(AddClaimToRoleModel request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                foreach (var claim in request.Claims)
                {
                    //  Guard.Against.NullOrEmpty(claim, nameof(request.Claims));
                    await _roleManager.AddClaimAsync(role,null);
                }

                scope.Complete();
            }
            catch (Exception)
            {
                scope.Dispose();
                throw;
            }

            return true;
        }

        public async Task<bool> CreateRole(CreateRoleModel request)
        {
            if (await _roleManager.RoleExistsAsync(request.Name))
                throw new Exception("Role already exists");

            var result = await _roleManager.CreateAsync(new CasinoRole { Name = request.Name });
            if (!result.Succeeded)
                throw new Exception(string.Join(Environment.NewLine, result.Errors));

            return true;
        }

    }
}
