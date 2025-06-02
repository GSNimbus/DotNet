using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly UsuarioService _service;
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }
        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                var usuario = await _service.GetByIdAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
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
        [HttpGet("usuario/email/{email}")]
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            try
            {
                var usuario = await _service.GetByEmailAsync(email);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
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

        [HttpPost("usuario")]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            try
            {
                var createdUsuario = await _service.AddAsync(usuario);
                return CreatedAtAction(nameof(GetById), new { id = createdUsuario.IdUsuario }, createdUsuario);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch(EmailInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }

        }

        [HttpPut("usuario/{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.IdUsuario)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do usuário não corresponde ao ID fornecido." });
                }
                var updatedUsuario = await _service.UpdateAsync(id, usuario);
                return Ok(updatedUsuario);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (EmailInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpDelete("usuario/{id}")]
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
    }
}
