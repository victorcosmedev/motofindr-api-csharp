using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Utils;
using Oracle.EntityFrameworkCore.Query.Internal;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFindrAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoController : ControllerBase
    {   
        private readonly IMotoApplicationService _motoService;
        private readonly ISecaoApplicationService _secaoService;
        public MotoController(IMotoApplicationService motoService, ISecaoApplicationService secaoService)
        {
            _motoService = motoService;
            _secaoService = secaoService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = ApiDoc.SalvarMotoSummary,
            Description = ApiDoc.SalvarMotoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Moto cadastrada com sucesso", typeof(MotoDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
        public async Task<IActionResult> SalvarMoto(MotoDTO dto)
        {
            try
            {
                var moto = _motoService.SalvarAsync(dto);
                return Ok(moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.BuscarMotoSummary,
            Description = ApiDoc.BuscarMotoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Moto encontrada", typeof(MotoDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Moto não encontrada")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetro inválido ou erro no processamento")]
        public async Task<IActionResult> BuscarMotoPorId([FromRoute] int id)
        {
            try
            {
                var moto = await _motoService.BuscarMotoPorIdAsync(id);
                if (moto == null) return NoContent();
                return Ok(moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.AtualizarMotoSummary,
            Description = ApiDoc.AtualizarMotoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Moto atualizada com sucesso", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Moto não encontrada para atualização")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos ou erro no processamento")]
        public async Task<IActionResult> AtualizarMoto(int id, MotoDTO moto)
        {
            try
            {
                var sucesso = await _motoService.AtualizarMotoAsync(id, moto);
                if (!sucesso) 
                    return NotFound("Moto não encontrada para atualização");
                return Ok(sucesso);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = ApiDoc.DeletarMotoSummary,
            Description = ApiDoc.DeletarMotoDescription
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Moto removida com sucesso", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Moto não encontrada para exclusão")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no processamento da requisição")]
        public async Task<IActionResult> DeletarMoto(int id)
        {
            try
            {
                var sucesso = await _motoService.DeletarMotoAsync(id);
                if (!sucesso)
                    return NotFound("Moto não encontrada");
                return Ok(sucesso);
            }
            catch(Exception e)
            {  
                return BadRequest(e.Message);
            }
        }
    }
}
