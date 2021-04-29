using ExemploDapper.Domain.Entities;
using ExemploDapper.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExemploDapper.Controllers
{
    [Route("/api/pets")]
    public class PetsController : Controller
    {
        private readonly IPetRepository _repository;

        public PetsController(IPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Pet pet)
        {
            await _repository.AddAsync(pet);
            return Created($"/api/pets/{pet.Id}", pet);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _repository.GetAsync());
        }

        [HttpPut("Id")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Pet pet)
        {
            pet.Id = id;
            return Ok(await _repository.PutAsync(pet));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await _repository.DeleteAsync(id);
            if ( response != null)
                return Ok(response);
            return BadRequest();
        }
    }
}
