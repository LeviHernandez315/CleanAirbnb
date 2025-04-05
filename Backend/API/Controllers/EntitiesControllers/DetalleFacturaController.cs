using Application.DTOs.Entidades.DetalleFacturaDTOs;
using Application.Interfaces.Entidades.DetalleFacturaInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/detallefacturas")]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IDetalleFacturaService _detallefacturaService;

        public DetalleFacturaController(IDetalleFacturaService detallefacturaService)
        {
            _detallefacturaService = detallefacturaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _detallefacturaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _detallefacturaService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetalleFacturaRequestDTO dto)
        {
            var created = await _detallefacturaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetalleFacturaRequestDTO dto)
        {
            var updated = await _detallefacturaService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _detallefacturaService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}