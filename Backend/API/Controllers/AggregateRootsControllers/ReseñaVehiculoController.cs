using Application.DTOs.AggregateRoots.ReseñaVehiculoDTOs;
using Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AggregateRootsControllers
{
    [ApiController]
    [Route("api/reseñavehiculos")]
    public class ReseñaVehiculoController : ControllerBase
    {
        private readonly IReseñaVehiculoService _reseñavehiculoService;

        public ReseñaVehiculoController(IReseñaVehiculoService reseñavehiculoService)
        {
            _reseñavehiculoService = reseñavehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reseñavehiculoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reseñavehiculoService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReseñaVehiculoRequestDTO dto)
        {
            var created = await _reseñavehiculoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReseñaVehiculoRequestDTO dto)
        {
            var updated = await _reseñavehiculoService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reseñavehiculoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}