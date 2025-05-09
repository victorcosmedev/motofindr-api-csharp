using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFindrAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatioController: ControllerBase
    {
        private readonly IPatioApplicationService _service;

        public PatioController(IPatioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = ApiDoc.SalvarPatioSummary,
            Description = ApiDoc.SalvarPatioDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Pátio cadastrado com sucesso", typeof(PatioEntity))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.BuscarTodosPatiosSummary,
            Description = ApiDoc.BuscarTodosPatiosDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de pátios retornada com sucesso", typeof(List<PatioEntity>))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Nenhum pátio cadastrado")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da requisição")]
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
        [SwaggerOperation(
            Summary = ApiDoc.BuscarPatioPorIdSummary,
            Description = ApiDoc.BuscarPatioPorIdDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Pátio encontrado", typeof(PatioEntity))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pátio não encontrado")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.AtualizarPatioSummary,
            Description = ApiDoc.AtualizarPatioDescription
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pátio atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pátio não encontrado para atualização")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
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
        [SwaggerOperation(
            Summary = ApiDoc.DeletarPatioSummary,
            Description = ApiDoc.DeletarPatioDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Pátio removido com sucesso", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pátio não encontrado para exclusão")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da requisição")]
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
