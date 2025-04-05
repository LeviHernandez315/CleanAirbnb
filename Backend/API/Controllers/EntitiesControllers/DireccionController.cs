using Application.DTOs.Entidades.DireccionDTOs;
using Application.Interfaces.Entidades.DireccionInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/direcciones")] 
    public class DireccionController : ControllerBase
    {
        private readonly IDireccionService _direccionService;

        public DireccionController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        // GET: api/direcciones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var direcciones = await _direccionService.GetAllAsync();
            return Ok(direcciones);
        }

        // GET: api/direcciones/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var direccion = await _direccionService.GetByIdAsync(id);
            if (direccion is null)
                return NotFound();

            return Ok(direccion);
        }

        // POST: api/direcciones
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DireccionRequestDTO dto)
        {
            var nuevaDireccion = await _direccionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevaDireccion.Id }, nuevaDireccion);
        }

        // PUT: api/direcciones/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DireccionRequestDTO dto)
        {
            var actualizado = await _direccionService.UpdateAsync(id, dto);
            return actualizado ? NoContent() : NotFound();
        }

        // DELETE: api/direcciones/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _direccionService.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
