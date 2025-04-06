namespace API.Controllers.EntitiesControllers
{
    using Application.DTOs.Entidades.ValoracionDTOs;
    using Application.Interfaces.Entidades.ValoracionInterfaces;
    using Microsoft.AspNetCore.Mvc;

    namespace API.Controllers.EntitiesControllers
    {
        [ApiController]
        [Route("api/valoraciones")]
        public class ValoracionController : ControllerBase
        {
            private readonly IValoracionService _valoracionService;

            public ValoracionController(IValoracionService valoracionService)
            {
                _valoracionService = valoracionService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var lista = await _valoracionService.GetAllAsync();
                return Ok(lista);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var valoracion = await _valoracionService.GetByIdAsync(id);
                return Ok(valoracion);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ValoracionRequestDTO dto)
            {
                var creada = await _valoracionService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ValoracionRequestDTO dto)
            {
                var update = await _valoracionService.UpdateAsync(id, dto);
                if (!update)
                    return NotFound();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var delete = await _valoracionService.DeleteAsync(id);
                if (!delete)
                    return NotFound();

                return NoContent();
            }
        }
    }

}
