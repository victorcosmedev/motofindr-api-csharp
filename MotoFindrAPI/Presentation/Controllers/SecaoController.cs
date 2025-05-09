using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFindrAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecaoController : ControllerBase
    {
        private readonly ISecaoApplicationService _secaoService;
        public SecaoController(ISecaoApplicationService secaoService)
        {
            _secaoService = secaoService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = ApiDoc.SalvarSecaoSummary,
            Description = ApiDoc.SalvarSecaoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Seção cadastrada com sucesso", typeof(SecaoEntity))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
        public async Task<IActionResult> SalvarSecao([FromBody] SecaoEntity entity)
        {
            if (entity == null)
                return BadRequest("Seção inserida é nula");

            try
            {
                var secao = await _secaoService.SalvarAsync(entity);
                return Ok(secao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.ObterSecaoPorIdSummary,
            Description = ApiDoc.ObterSecaoPorIdDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Seção encontrada", typeof(SecaoEntity))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Seção não encontrada")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
        public async Task<IActionResult> ObterSecaoPorId([FromRoute] int id)
        {
            try
            {
                var secao = await _secaoService.BuscarSecaoPorIdAsync(id);
                if (secao == null)
                    return BadRequest("Seção com este ID não existe");
                return Ok(secao);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.AtualizarSecaoSummary,
            Description = ApiDoc.AtualizarSecaoDescription
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Seção atualizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Seção não encontrada para atualização")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
        public async Task<IActionResult> AtualizarSecao([FromRoute] int id, [FromBody] SecaoEntity secao)
        {
            try
            {
                var sucesso = await _secaoService.AtualizarSecaoAsync(id, secao);
                if (!sucesso)
                    return NotFound("Seção não encontrada para atualização.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.DeletarSecaoSummary,
            Description = ApiDoc.DeletarSecaoDescription
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Seção removida com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Seção não encontrada para exclusão")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da requisição")]
        public async Task<IActionResult> DeletarSecao(int id)
        {
            try
            {
                var sucesso = await _secaoService.DeletarSecaoAsync(id);
                if (!sucesso)
                    return NotFound("Seção não encontrada para exclusão");
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
