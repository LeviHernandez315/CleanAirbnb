using Application.DTOs.Entidades.PersonaDTOs;
using Application.Interfaces.Entidades.PersonaInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _personaService.GetAllAsync();
            return Ok(personas);
        }

        [HttpGet("{dni}")]
        public async Task<IActionResult> GetById(string dni)
        {
            var persona = await _personaService.GetByIdAsync(dni);
            return persona is null ? NotFound() : Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaRequestDTO dto)
        {
            var nueva = await _personaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { dni = nueva.DNI }, nueva);
        }

        [HttpPut("{dni}")]
        public async Task<IActionResult> Update(string dni, PersonaRequestDTO dto)
        {
            var actualizado = await _personaService.UpdateAsync(dni, dto);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{dni}")]
        public async Task<IActionResult> Delete(string dni)
        {
            var eliminado = await _personaService.DeleteAsync(dni);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
