using Microsoft.AspNetCore.Mvc;
using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Services;

namespace NimbusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        public readonly AlertaService _service;
        public AlertaController(AlertaService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var alertas = await _service.GetAllAsync();
            return Ok(alertas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var alerta = await _service.GetByIdAsync(id);
                if (alerta == null)
                {
                    return NotFound();
                }
                return Ok(alerta);
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
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] Alerta alerta)
        {
            try
            {
                var newAlert = await _service.AddAsync(alerta);
                return CreatedAtAction(nameof(GetById), new { id = newAlert.IdAlerta }, newAlert);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message});
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message});
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
        public async Task<IActionResult> Update([FromBody] Alerta alerta,int id)
        {
            try
            {
               
                if (id != alerta.IdAlerta)
                {
                    return BadRequest(new { StatusCode = 400, Message = "O ID do alerta não corresponde ao ID fornecido na URL." });
                }
                var updatedAlert = await _service.UpdateAsync(alerta);
                return Ok(updatedAlert);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (TamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message});
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
                var alerta = await _service.GetByIdAsync(id);
                if (alerta == null)
                {
                    return NotFound();
                }
                await _service.DeleteAsync(alerta);
                return NoContent();
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
