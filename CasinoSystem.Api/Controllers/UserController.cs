using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared;

namespace CasinoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
                return BadRequest($"Item with id {id} does not exist");

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserCreateModel user)
        {
            await _userService.AddAsync(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel updateItem)
        {
            bool updateResult = await _userService.UpdateAsync(updateItem);
            if (!updateResult)
            {
                return BadRequest($"Item with id {updateItem.Id} does not exist");
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignIn updateItem)
        {
            var result = await _userService.SignInAsync(updateItem);
           
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }

    }
}