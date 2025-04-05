using Application.DTOs.Entidades.DatosPagoDTOs;
using Application.Interfaces.Entidades.DatosPagoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/datospagos")]
    public class DatosPagoController : ControllerBase
    {
        private readonly IDatosPagoService _datospagoService;

        public DatosPagoController(IDatosPagoService datospagoService)
        {
            _datospagoService = datospagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _datospagoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _datospagoService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DatosPagoRequestDTO dto)
        {
            var created = await _datospagoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DatosPagoRequestDTO dto)
        {
            var updated = await _datospagoService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _datospagoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}