using Application.DTOs.Entidades.MarcaDTOs;
using Application.Interfaces.Entidades.MarcaInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.DTOs.Entidades.PaisDTOs;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcaController:ControllerBase
    {
            private readonly IMarcaService _marcaService;

            public MarcaController(IMarcaService marcaService)
            {
                _marcaService = marcaService;
            }

            [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var marcas = await _marcaService.GetAllAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
               var marca = await _marcaService.GetByIdAsync(id);
               if (marca == null)
                   return NotFound();

               return Ok(marca);
            }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MarcaRequestDTO dto)
        {
            var marca = await _marcaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = marca.Id }, marca);
        }

            
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MarcaRequestDTO dto)
        {
            var updated = await _marcaService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _marcaService.DeleteAsync(id); 
            if (!deleted)
                return NotFound();

                return NoContent();
        }
    }
}

