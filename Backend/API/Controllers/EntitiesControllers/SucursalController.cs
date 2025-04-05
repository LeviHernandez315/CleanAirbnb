using Application.DTOs.Entidades.SucursalDTOs;
using Application.Interfaces.Entidades.SucursalInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/sucursals")]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sucursalService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sucursalService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SucursalRequestDTO dto)
        {
            var created = await _sucursalService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SucursalRequestDTO dto)
        {
            var updated = await _sucursalService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sucursalService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}