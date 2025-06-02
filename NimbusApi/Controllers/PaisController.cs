using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {

        private readonly PaisService _service;

        public PaisController(PaisService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var paises = await _service.GetAllAsync();
            return Ok(paises);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetById(int id)
        {
            try
            {
                var pais = await _service.GetByIdAsync(id);
                if (pais == null)
                {
                    return NotFound();
                }
                return Ok(pais);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
        [HttpGet("nome/{nomePais}")]
        public async Task<ActionResult<Pais>> GetByName(string nomePais)
        {
            try
            {
                var pais = await _service.GetByNameAsync(nomePais);
                if (pais == null)
                {
                    return NotFound();
                }
                return Ok(pais);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<Pais>> Post([FromBody] Pais pais)
        {
            try
            {
                var createdPais = await _service.AddAsync(pais);
                return CreatedAtAction(nameof(GetById), new { id = createdPais.Id }, createdPais);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pais>> Put(int id, [FromBody] Pais pais)
        {
            try
            {
                var updatedPais = await _service.UpdateAsync(id, pais);
                return Ok(updatedPais);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
