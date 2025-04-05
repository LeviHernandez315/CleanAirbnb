using Application.DTOs.AggregateRoots.ReseñaPropiedadDTOs;
using Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AggregateRootsControllers
{
    [ApiController]
    [Route("api/reseñapropiedads")]
    public class ReseñaPropiedadController : ControllerBase
    {
        private readonly IReseñaPropiedadService _reseñapropiedadService;

        public ReseñaPropiedadController(IReseñaPropiedadService reseñapropiedadService)
        {
            _reseñapropiedadService = reseñapropiedadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reseñapropiedadService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reseñapropiedadService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReseñaPropiedadRequestDTO dto)
        {
            var created = await _reseñapropiedadService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReseñaPropiedadRequestDTO dto)
        {
            var updated = await _reseñapropiedadService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reseñapropiedadService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}