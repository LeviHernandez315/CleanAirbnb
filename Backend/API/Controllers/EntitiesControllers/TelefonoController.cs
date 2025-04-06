using Application.DTOs.Entidades.TelefonoDTOs;
using Application.Interfaces.Entidades.TelefonoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/telefonos")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoService _telefonoservice;

        public TelefonoController(ITelefonoService telefonoservice)
        {
            _telefonoservice = telefonoservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var telefonos = await _telefonoservice.GetAllAsync();
            return Ok(telefonos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var telefono = await _telefonoservice.GetByIdAsync(id);
            return Ok(telefono);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelefonoRequestDTO dto)
        {
            var created = await _telefonoservice.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TelefonoRequestDTO dto)
        {
            var updated = await _telefonoservice.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _telefonoservice.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
