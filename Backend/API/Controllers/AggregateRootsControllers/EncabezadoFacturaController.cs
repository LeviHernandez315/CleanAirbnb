using Application.DTOs.AggregateRoots.EncabezadoFacturaDTOs;
using Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AggregateRootsControllers
{
    [ApiController]
    [Route("api/encabezadofacturas")]
    public class EncabezadoFacturaController : ControllerBase
    {
        private readonly IEncabezadoFacturaService _encabezadofacturaService;

        public EncabezadoFacturaController(IEncabezadoFacturaService encabezadofacturaService)
        {
            _encabezadofacturaService = encabezadofacturaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _encabezadofacturaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _encabezadofacturaService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EncabezadoFacturaRequestDTO dto)
        {
            var created = await _encabezadofacturaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EncabezadoFacturaRequestDTO dto)
        {
            var updated = await _encabezadofacturaService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _encabezadofacturaService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}