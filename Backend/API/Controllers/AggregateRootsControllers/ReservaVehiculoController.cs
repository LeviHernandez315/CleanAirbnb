using Application.DTOs.AggregateRoots.ReservaVehiculoDTOs;
using Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AggregateRootsControllers
{
    [ApiController]
    [Route("api/reservavehiculos")]
    public class ReservaVehiculoController : ControllerBase
    {
        private readonly IReservaVehiculoService _reservavehiculoService;

        public ReservaVehiculoController(IReservaVehiculoService reservavehiculoService)
        {
            _reservavehiculoService = reservavehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reservavehiculoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reservavehiculoService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservaVehiculoRequestDTO dto)
        {
            var created = await _reservavehiculoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReservaVehiculoRequestDTO dto)
        {
            var updated = await _reservavehiculoService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reservavehiculoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}