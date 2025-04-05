
using Application.DTOs.Entidades.RolDTOs;
using Application.Interfaces.Entidades.RolInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.EntitiesControllers
{

    [ApiController]
    [Route("api/rol")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.GetByIdAsync(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolRequestDTO dto)
        {
            var id = await _rolService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolRequestDTO dto)
        {
            var updated = await _rolService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }


}

