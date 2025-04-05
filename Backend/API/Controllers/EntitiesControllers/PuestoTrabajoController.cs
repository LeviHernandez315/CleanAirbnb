using Application.DTOs.Entidades.PuestoTrabajoDTOs;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/puestos-trabajo")]
    public class PuestoTrabajoController : ControllerBase
    {
        private readonly IPuestoTrabajoService _puestoService;

        public PuestoTrabajoController(IPuestoTrabajoService puestoService)
        {
            _puestoService = puestoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var puestos = await _puestoService.GetAllAsync();
            return Ok(puestos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var puesto = await _puestoService.GetByIdAsync(id);
            return puesto is null ? NotFound() : Ok(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PuestoTrabajoRequestDTO dto)
        {
            var nuevo = await _puestoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PuestoTrabajoRequestDTO dto)
        {
            var actualizado = await _puestoService.UpdateAsync(id, dto);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _puestoService.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
