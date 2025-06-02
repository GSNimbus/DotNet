using Microsoft.AspNetCore.Mvc;
using NimbusApi.Connection;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service ;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enderecos = await _service.GetAllAsync();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var endereco = await _service.GetByIdAsync(id);
                if (endereco == null)
                {
                    return NotFound(new { StatusCode = 404, Message = "Endereço não encontrado." });
                }
                return Ok(endereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            try
            {
                var endereco = await _service.GetByCepAsync(cep);
                if (endereco == null)
                {
                    return NotFound(new { StatusCode = 404, Message = "Endereço não encontrado." });
                }
                return Ok(endereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Endereco endereco)
        {
            try
            {
                if (endereco == null)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O objeto Endereco não pode ser nulo." });
                }
                var createdEndereco = await _service.AddAsync(endereco);
                return CreatedAtAction(nameof(GetById), new { id = createdEndereco.IdEndereco }, createdEndereco);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (NomeObrigatorioException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Endereco endereco)
        {
            try
            {
                if (id != endereco.IdEndereco)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do endereço não corresponde ao ID fornecido." });
                }
                var updatedEndereco = await _service.UpdateAsync(id, endereco);
                return Ok(updatedEndereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
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
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}
