using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;

namespace MotoFindrAPI.Presentation.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class MotoqueiroController : ControllerBase
    {
        private readonly IMotoqueiroApplicationService _service;
        public MotoqueiroController(IMotoqueiroApplicationService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> SalvarMotoqueiro([FromBody] MotoqueiroDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("O motoqueiro é nulo");
                var motoqueiro = await _service.SalvarAsync(dto);
                return CreatedAtAction(
                    nameof(BuscarMotoqueiroPorId),
                    new { id = motoqueiro.Id },
                    motoqueiro
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosMotoqueiros()
        {
            try
            {
                var motoqueiros = await _service.BuscarTodosAsync();
                return Ok(motoqueiros);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarMotoqueiroPorId(int id)
        {
            try
            {
                var motoqueiro = _service.BuscarPorIdAsync(id);
                if (motoqueiro == null)
                    return NotFound($"Motoqueiro com ID {id} não encontrado.");

                return Ok(motoqueiro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMoto(int id)
        {
            try
            {
                var sucesso = _service.DeletarAsync(id);
                if (sucesso == null)
                    return BadRequest("Não foi possível deletar");
                return Ok(sucesso);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMoto(int id, [FromBody] MotoqueiroDTO dto)
        {
            try
            {
                var sucesso = _service.AtualizarAsync(id, dto);
                if (sucesso == null)
                    return BadRequest("Não foi possível atualizar esta moto");
                return Ok(sucesso);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
