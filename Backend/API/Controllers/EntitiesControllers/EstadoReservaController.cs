using Application.DTOs.Entidades.EstadoReservaDTOs;
using Application.Interfaces.Entidades.EstadoReservaInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/estadoreservas")]
    public class EstadoReservaController : ControllerBase
    {
        private readonly IEstadoReservaService _estadoreservaService;

        public EstadoReservaController(IEstadoReservaService estadoreservaService)
        {
            _estadoreservaService = estadoreservaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _estadoreservaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _estadoreservaService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoReservaRequestDTO dto)
        {
            var created = await _estadoreservaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoReservaRequestDTO dto)
        {
            var updated = await _estadoreservaService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _estadoreservaService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}