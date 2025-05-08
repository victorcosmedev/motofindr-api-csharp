using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;

namespace MotoFindrAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VagaController : ControllerBase
    {
        private readonly IVagaApplicationService _vagaApplicationService;

        public VagaController(IVagaApplicationService vagaApplicationService)
        {
            _vagaApplicationService = vagaApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasVagasPorSecao([FromQuery] int secaoId)
        {
            try
            {
                var vagas = await _vagaApplicationService.BuscarTodasVagasPorSecaoAsync(secaoId);
                if(vagas == null)
                    return Ok();

                return Ok(vagas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasVagasPorPatio([FromQuery] int patioId)
        {
            try
            {
                var vagas = await _vagaApplicationService.BuscarTodasVagasPorPatioAsync(patioId);
                if (vagas == null)
                    return Ok();
                return Ok(vagas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarVagaPorId(int id)
        {
            try
            {
                var vaga = await _vagaApplicationService.BuscarVagaPorIdAsync(id);
                if (vaga == null)
                    return NotFound();
                return Ok(vaga);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarVaga([FromBody] VagaDTO dto)
        {
            try
            {
                var vaga = await _vagaApplicationService.SalvarVagaAsync(dto);
                return Ok(vaga);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarVaga(int id, [FromBody] VagaDTO dto)
        {
            try
            {
                var sucesso = await _vagaApplicationService.AtualizarVagaAsync(id, dto);
                if (sucesso)
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVaga(int id)
        {
            try
            {
                var sucesso = await _vagaApplicationService.DeletarVagaAsync(id);
                if (sucesso)
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
