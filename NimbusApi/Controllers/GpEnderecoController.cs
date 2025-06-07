using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GpEnderecoController : ControllerBase
    {
        public readonly GpEnderecoService _service;
        public GpEnderecoController(GpEnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GpEndereco>>> Get()
        {
            var enderecos = await _service.GetAllAsync();
            return Ok(enderecos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GpEndereco>> GetById(int id)
        {
            try
            {
                var endereco = await _service.GetByIdAsync(id);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
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

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<GpEndereco>> GetByNomeGrupo(string nome)
        {
            try
            {
                var endereco = await _service.GetByNomeGrupo(nome);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
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

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<GpEndereco>>> GetByUsuarioId(int usuarioId)
        {
            try
            {
                var enderecos = await _service.GetByIdUsuarioAsync(usuarioId);
                if (enderecos == null || !enderecos.Any())
                {
                    return NotFound();
                }
                return Ok(enderecos);
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
        public async Task<ActionResult<GpEndereco>> Post([FromBody] GpEndereco gpEndereco)
        {
            try
            {
                var novoEndereco = await _service.AddAsync(gpEndereco);
                return CreatedAtAction(nameof(GetById), new { id = novoEndereco.IdGpEndereco }, novoEndereco);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<GpEndereco>> Put(int id, [FromBody] GpEndereco gpEndereco)
        {
            try
            {
                if (id != gpEndereco.IdGpEndereco)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do GpEndereco não corresponde ao ID fornecido." });
                }
                var enderecoAtualizado = await _service.UpdateAsync(id, gpEndereco);
                return Ok(enderecoAtualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
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
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}
