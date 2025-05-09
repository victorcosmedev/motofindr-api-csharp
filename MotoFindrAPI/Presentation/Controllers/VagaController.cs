using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Utils;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet("por-secao")]
        [SwaggerOperation(
            Summary = ApiDoc.BuscarVagasPorSecaoSummary,
            Description = ApiDoc.BuscarVagasPorSecaoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vagas encontradas", typeof(List<VagaDTO>))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Nenhuma vaga encontrada para esta seção")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
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

        [HttpGet("por-patio")]
        [SwaggerOperation(
            Summary = ApiDoc.BuscarVagasPorPatioSummary,
            Description = ApiDoc.BuscarVagasPorPatioDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vagas encontradas", typeof(List<VagaDTO>))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Nenhuma vaga encontrada para este pátio")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.BuscarVagaPorIdSummary,
            Description = ApiDoc.BuscarVagaPorIdDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vaga encontrada", typeof(VagaDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Vaga não encontrada")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.SalvarVagaSummary,
            Description = ApiDoc.SalvarVagaDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vaga cadastrada com sucesso", typeof(VagaDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.AtualizarVagaSummary,
            Description = ApiDoc.AtualizarVagaDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vaga atualizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.DeletarVagaSummary,
            Description = ApiDoc.DeletarVagaDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Vaga removida com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da requisição")]
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
