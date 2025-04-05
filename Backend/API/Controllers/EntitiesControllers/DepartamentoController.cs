using Application.DTOs.Entidades.DepartamentoDTOs;
using Application.Interfaces.Entidades.DepartamentoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{

    [ApiController]
    [Route("api/departamentos")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var departamento = await _departamentoService.GetByIdAsync(id);
            return departamento is null ? NotFound() : Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartamentoRequestDTO dto)
        {
            var departamento = await _departamentoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = departamento.Id }, departamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartamentoRequestDTO dto)
        {
            var update = await _departamentoService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _departamentoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
