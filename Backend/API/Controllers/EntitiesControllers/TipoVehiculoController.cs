using Application.DTOs.Entidades.AreaTrabajoDTOs;
using Application.DTOs.Entidades.TipoVehiculoDTOs;
using Application.Interfaces.Entidades.TipoVehiculoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/tipovehiculo")]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ITipoVehiculoService _tipoVehiculoService;

        public TipoVehiculoController(ITipoVehiculoService tipoVehiculoService)
        {
            _tipoVehiculoService = tipoVehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _tipoVehiculoService.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _tipoVehiculoService.GetByIdAsync(id);
            if (tipo == null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoVehiculoRequestDTO dto)
        {
            var created = await _tipoVehiculoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoVehiculoRequestDTO dto)
        {
            var updated = await _tipoVehiculoService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tipoVehiculoService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
