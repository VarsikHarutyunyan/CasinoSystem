using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared;

namespace CasinoSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("CreateRole")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleModel request)
        {
            var isCreate = await _roleService.CreateRole(request);
            return Ok(isCreate);
        }

       //  [Authorize(Policy = Permission.Roles.Edit)]

        [Authorize(Roles = "Admin")]
        [HttpPost("AddClaimToRole")]
        public async Task<IActionResult> AddClaimToRole([FromBody] AddClaimToRoleModel request)
        {
            var isCreate = await _roleService.AddClaimToRole(request);
            return Ok(isCreate);
        }
    }
}
