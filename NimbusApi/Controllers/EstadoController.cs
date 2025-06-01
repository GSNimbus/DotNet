using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _service;

        public EstadoController(EstadoService service)
        {
            _service = service;
        }

        [HttpGet("estados")]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            var estados = await _service.GetAllAsync();
            return Ok(estados);
        }
        [HttpGet("estados/{id}")]
        public async Task<ActionResult<Estado>> GetById(int id)
        {
            try
            {
                var estado = await _service.GetByIdAsync(id);
                if (estado == null)
                {
                    return NotFound();
                }
                return Ok(estado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
        [HttpGet("estados/nome/{nomeEstado}")]
        public async Task<ActionResult<Estado>> GetByName(string nomeEstado)
        {
            try
            {
                var estado = await _service.GetByNameAsync(nomeEstado);
                if (estado == null)
                {
                    return NotFound();
                }
                return Ok(estado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost("estados")]
        public async Task<ActionResult<Estado>> Post([FromBody] Estado estado)
        {
            try
            {
                var novoEstado = await _service.AddAsync(estado);
                return CreatedAtAction(nameof(GetById), new { id = novoEstado.IdEstado }, novoEstado);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (NomeObrigatorioException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }
        [HttpPut("estados/{id}")]
        public async Task<ActionResult<Estado>> Put(int id, [FromBody] Estado estado)
        {
            try
            {
                if (id != estado.IdEstado)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do estado não corresponde ao ID fornecido." });
                }
                var estadoAtualizado = await _service.UpdateAsync(id, estado);
                return Ok(estadoAtualizado);
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (NomeObrigatorioException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }

        [HttpDelete("estados/{id}")]
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
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }


    }

}
