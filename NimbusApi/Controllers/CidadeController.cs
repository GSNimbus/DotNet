using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {

        private readonly CidadeService _service;

        public CidadeController(CidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get()
        {
            var cidades = await _service.GetAllAsync();
            return Ok(cidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetById(int id)
        {
            try
            {
                var cidade = await _service.GetByIdAsync(id);
                if (cidade == null)
                {
                    return NotFound();
                }
                return Ok(cidade);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpGet("nome/{nomeCidade}")]
        public async Task<ActionResult<Cidade>> GetByName(string nomeCidade)
        {
            try
            {
                var cidade = await _service.GetByNameAsync(nomeCidade);
                if (cidade == null)
                {
                    return NotFound();
                }
                return Ok(cidade);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cidade>> Post([FromBody] Cidade cidade)
        {
            try
            {
                var createdCidade = await _service.AddAsync(cidade);
                return CreatedAtAction(nameof(GetById), new { id = createdCidade.IdCidade }, createdCidade);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Cidade>> Put(int id, [FromBody] Cidade cidade)
        {
            try
            {
                var updatedCidade = await _service.UpdateAsync(id, cidade);
                return Ok(updatedCidade);
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
