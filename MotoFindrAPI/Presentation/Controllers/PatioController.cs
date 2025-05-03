using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatioController: ControllerBase
    {
        private readonly IPatioApplicationService _service;

        public PatioController(IPatioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] PatioEntity entity)
        {
            try
            {
                var patio = _service.SalvarAsync(entity);
                return Ok(patio);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosPatios()
        {
            try
            {
                var patios = await _service.BuscarTodosPatiosAsync();
                if (patios == null)
                    return NotFound("Não há patios cadastrados.");

                return Ok(patios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var patio = await _service.BuscarPatioPorIdAsync(id);

                if (patio == null)
                    return NotFound("Pátio não encontrado.");

                return Ok(patio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPatio(int id, [FromBody] PatioEntity entity)
        {
            try
            {
                var sucesso = await _service.AtualizarPatioAsync(id, entity);
                if (!sucesso)
                    return NotFound("Pátio não encontrado para atualização.");

                return NoContent();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPatio(int id)
        {
            try
            {
                var sucesso = await _service.DeletarPatioAsync(id);
                if (!sucesso)
                    return NotFound("Este pátio não existe");
                return Ok(sucesso);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
