using Application.DTOs.Entidades.CiudadDTOs;
using Application.Interfaces.Entidades.CiudadInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ciudadService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ciudad = await _ciudadService.GetByIdAsync(id);
            return ciudad is null ? NotFound() : Ok(ciudad);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CiudadRequestDTO dto)
        {
            var ciudad = await _ciudadService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ciudad.Id }, ciudad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CiudadRequestDTO dto)
        {
            var update = await _ciudadService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ciudadService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
