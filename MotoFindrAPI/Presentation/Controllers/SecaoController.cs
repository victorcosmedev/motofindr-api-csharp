using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Presentation.Controllers
{
    public class SecaoController : ControllerBase
    {
        private readonly ISecaoApplicationService _secaoService;
        public SecaoController(ISecaoApplicationService secaoService)
        {
            _secaoService = secaoService;
        }

        [HttpPost]
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
