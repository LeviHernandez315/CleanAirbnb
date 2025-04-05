using Application.DTOs.Entidades.PropiedadDTOs;
using Application.Interfaces.Entidades.PropiedadInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/propiedads")]
    public class PropiedadController : ControllerBase
    {
        private readonly IPropiedadService _propiedadService;

        public PropiedadController(IPropiedadService propiedadService)
        {
            _propiedadService = propiedadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _propiedadService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _propiedadService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropiedadRequestDTO dto)
        {
            var created = await _propiedadService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PropiedadRequestDTO dto)
        {
            var updated = await _propiedadService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _propiedadService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}