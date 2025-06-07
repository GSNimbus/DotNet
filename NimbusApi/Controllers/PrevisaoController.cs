using Microsoft.AspNetCore.Mvc;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrevisaoController : ControllerBase
    {
        public readonly PrevisaoService _service;
        public PrevisaoController(PrevisaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Previsao>>> Get()
        {
            var previsao = await _service.GetAllAsync();
            return Ok(previsao);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Previsao>> GetById(int id)
        {
            try
            {
                var previsao = await _service.GetByIdAsync(id);
                if (previsao == null)
                {
                    return NotFound();
                }
                return Ok(previsao);
            }
            catch(ArgumentOutOfRangeException ex) 
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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
        [HttpGet("bairro/{id}")]
        public async Task<ActionResult<IEnumerable<Previsao>>> GetByBairro(int id)
        {
            try
            {
                var previsoes = await _service.GetByBairroAsync(id);
                if (previsoes == null || !previsoes.Any())
                {
                    return NotFound();
                }
                return Ok(previsoes);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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

        [HttpPost("prever/{idBairro}")]
        public async Task<IActionResult> Prever([FromBody] PreverCorpo obj,int idBairro)
        {
            try
            {
                var resposta = await _service.Prever(obj, idBairro);
                return Ok(resposta);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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
        public async Task<IActionResult> Add([FromBody] Previsao previsao)
        {
            try
            {
                var newPrevisao = await _service.AddAsync(previsao);
                return Ok(newPrevisao);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Previsao previsao)
        {
            try
            {
                if (id != previsao.IdPrevisao)
                {
                    return BadRequest(new { StatusCode = 400, Message = "ID da previsão não corresponde ao ID fornecido." });
                }
                var updatedPrevisao = await _service.UpdateAsync(previsao);
                return Ok(updatedPrevisao);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var previsao = await _service.GetByIdAsync(id);
                if (previsao == null)
                {
                    return NotFound();
                }
                await _service.DeleteAsync(previsao);
                return NoContent();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
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
    }
}
