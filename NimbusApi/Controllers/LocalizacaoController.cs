using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly LocalizacaoService _service;

        public LocalizacaoController(LocalizacaoService service)
        {
            _service = service;
        }

        [HttpGet("localizacoes")]
        public async Task<ActionResult<IEnumerable<Localizacao>>> Get()
        {
            var localizacoes = await _service.GetAllAsync();
            return Ok(localizacoes);
        }

        [HttpGet("localizacao/{id}")]
        public async Task<ActionResult<Localizacao>> GetById(int id)
        {
            try
            {
                var localizacao = await _service.GetByIdAsync(id);
                if (localizacao == null)
                {
                    return NotFound();
                }
                return Ok(localizacao);
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
        [HttpPost("localizacao")]
        public async Task<ActionResult<Localizacao>> Post(Localizacao localizacao)
        {
            try
            {
                var createdLocalizacao = await _service.AddAsync(localizacao);
                return CreatedAtAction(nameof(GetById), new { id = createdLocalizacao.IdLocalizacao }, createdLocalizacao);
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

        [HttpPut("localizacao/{id}")]
        public async Task<ActionResult<Localizacao>> Put(int id, Localizacao localizacao)
        {
            try
            {
                if (id != localizacao.IdLocalizacao)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID da localização não corresponde ao ID fornecido." });
                }
                var updatedLocalizacao = await _service.UpdateAsync(id, localizacao);
                return Ok(updatedLocalizacao);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
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

        [HttpDelete("localizacao/{id}")]
        public async Task<IActionResult> Delete(int id)
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
