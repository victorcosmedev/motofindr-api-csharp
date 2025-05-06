using Microsoft.AspNetCore.Mvc;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using Oracle.EntityFrameworkCore.Query.Internal;

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

        [HttpGet]
        public async Task<IActionResult> BuscarTodasMotos()
        {
            try
            {
                var motos = await _motoService.BuscarTodasMotosAsync();
                if (motos == null || !motos.Any())
                    return NoContent();
                return Ok(motos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> SalvarMoto(MotoEntity entity)
        {
            try
            {
                var moto = _motoService.SalvarAsync(entity);
                return Ok(moto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMoto(int id, MotoEntity moto)
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
