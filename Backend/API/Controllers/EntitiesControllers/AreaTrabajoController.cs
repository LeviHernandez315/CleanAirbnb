

using Application.DTOs.Entidades.AreaTrabajoDTOs;
using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/areasTrabajo")]
    public class AreaTrabajoController : ControllerBase
    {
        private readonly IAreaTrabajoService _areaTrabajoService;

        public AreaTrabajoController(IAreaTrabajoService areaTrabajoService)
        {
            _areaTrabajoService = areaTrabajoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _areaTrabajoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var areaTrabajo = await _areaTrabajoService.GetByIdAsync(id);
            return areaTrabajo is null ? NotFound() : Ok(areaTrabajo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AreaTrabajoRequestDTO dto)
        {
            var areaTrabajo = await _areaTrabajoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = areaTrabajo.Id }, areaTrabajo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AreaTrabajoRequestDTO dto)
        {
            var update = await _areaTrabajoService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _areaTrabajoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
