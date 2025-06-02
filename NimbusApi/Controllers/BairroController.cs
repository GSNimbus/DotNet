using Microsoft.AspNetCore.Mvc;
using NimbusApi.Services;
using NimbusApi.Models;
using NimbusApi.Exceptions;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BairroController : ControllerBase
    {
        private readonly BairroService _service;

        public BairroController(BairroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bairro>>> Get()
        {
            var bairros = await _service.GetAllAsync();
            return Ok(bairros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bairro>> GetById(int id)
        {
            try
            {
                var bairro = await _service.GetByIdAsync(id);
                if (bairro == null)
                {
                    return NotFound();
                }
                return Ok(bairro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpGet("nome/{nomeBairro}")]
        public async Task<ActionResult<Bairro>> GetByName(string nomeBairro)
        {
            try
            {
                var bairro = await _service.GetByNameAsync(nomeBairro);
                if (bairro == null)
                {
                    return NotFound();
                }
                return Ok(bairro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Bairro>> Post(Bairro bairro)
        {
            try
            {
                var createdBairro = await _service.AddAsync(bairro);
                return CreatedAtAction(nameof(GetById), new { id = createdBairro.IdBairro }, createdBairro);
            }
            catch (ArgumentNullException ex)
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
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bairro>> Put(int id, Bairro bairro)
        {
            try
            {
                if (id != bairro.IdBairro)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do bairro não corresponde ao ID fornecido." });
                }
                var updatedBairro = await _service.UpdateAsync(id, bairro);
                return Ok(updatedBairro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (NomeObrigatorioException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, ex.Message });
            }
        }
    }
}
