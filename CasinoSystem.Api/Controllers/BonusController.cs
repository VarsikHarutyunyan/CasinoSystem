using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly IBonusService _service;
        public BonusController(IBonusService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetAsync(id);

            if (user == null)
                return BadRequest($"Item with id {id} does not exist");

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BonusCreateModel model)
        {
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BonusModel updateItem)
        {
            bool updateResult = await _service.UpdateAsync(updateItem);
            if (!updateResult)
            {
                return BadRequest($"Item with id {updateItem.Id} does not exist");
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);
            return Ok();
        }

    }
}
