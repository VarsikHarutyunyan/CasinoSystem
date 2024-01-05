using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Services.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRole(CreateRoleModel createRoleModel);
        Task<bool> AddClaimToRole(AddClaimToRoleModel createRoleModel);
    }
}
