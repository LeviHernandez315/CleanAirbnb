using Application.DTOs.Entidades.MarcaDTOs;
using Application.DTOs.Entidades.ModeloDTOs;
using Application.DTOs.Entidades.PaisDTOs;
using Application.Interfaces.Entidades.ModeloInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/modelos")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modelos = await _modeloService.GetAllAsync();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var modelo = await _modeloService.GetByIdAsync(id);
            if (modelo == null) return NotFound();
            return Ok(modelo);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModeloRequestDTO dto)
        {
            var modelo = await _modeloService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = modelo.Id }, modelo);
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> Updated(int id, [FromBody] ModeloRequestDTO dto)
        {
            var updated = await _modeloService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _modeloService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
