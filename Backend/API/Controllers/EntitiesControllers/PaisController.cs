using Application.DTOs.Entidades.PaisDTOs;
using Application.Interfaces.Entidades.PaisInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/paises")]

    public class PaisController : ControllerBase
    {
        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paisService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pais = await _paisService.GetByIdAsync(id);
            return pais is null ? NotFound() : Ok(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaisRequestDTO dto)
        {
            var ciudad = await _paisService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ciudad.Id }, ciudad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaisRequestDTO dto)
        {
            var update = await _paisService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _paisService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
