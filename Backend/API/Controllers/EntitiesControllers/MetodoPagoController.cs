using Application.DTOs.Entidades.MetodoPagoDTOs;
using Application.Interfaces.Entidades.MetodoPagoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EntitiesControllers
{
    [ApiController]
    [Route("api/MetodoPagos")]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService _metodoPagoService;

        public MetodoPagoController(IMetodoPagoService metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
        }

  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _metodoPagoService.GetAllAsync();
            return Ok(lista); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var metodo = await _metodoPagoService.GetByIdAsync(id);
            return Ok(metodo); 
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MetodoPagoRequestDTO dto)
        {
            var metodoPago = await _metodoPagoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = metodoPago.Id },metodoPago); 
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MetodoPagoRequestDTO dto)
        {
            var update = await _metodoPagoService.UpdateAsync(id, dto);
            if (!update)
                return NotFound(); 

            return NoContent(); 
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _metodoPagoService.DeleteAsync(id);
            if (!delete)
                return NotFound(); 

            return NoContent(); 
        }
    }
}
