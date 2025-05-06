using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Application.Services
{
    public class SecaoApplicationService : ISecaoApplicationService
    {
        private readonly ISecaoRepository _secaoRepository;
        private readonly IPatioRepository _patioRepository;
        public SecaoApplicationService(IPatioRepository patioRepository, ISecaoRepository secaoRepository)
        {
            _patioRepository = patioRepository;
            _secaoRepository = secaoRepository;
        }
        public async Task<SecaoEntity> SalvarAsync(SecaoEntity secao)
        {
            var patio = await _patioRepository.BuscarPorIdAsync(secao.PatioId);
            if (patio == null)
                throw new Exception("Pátio não encontrado.");
            secao.Patio = patio;
            
            try
            {
                return await _secaoRepository.SalvarAsync(secao);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public async Task<bool> AtualizarSecaoAsync(int id, SecaoEntity secao)
        {
            var patio = await _patioRepository.BuscarPorIdAsync(secao.PatioId);
            if (patio == null)
                throw new Exception("Pátio não encontrado.");

            var secaoExistente = await _secaoRepository.BuscarPorIdAsync(id);
            if (secaoExistente == null)
                throw new Exception("Seção não encontrada.");

            if(secaoExistente.IdSecao != id)
                return false;

            try
            {
                return await _secaoRepository.AtualizarAsync(id, secao);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SecaoEntity?> BuscarSecaoPorIdAsync(int id)
        {
            try
            {
                return await _secaoRepository.BuscarPorIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeletarSecaoAsync(int id)
        {
            var secao = await _secaoRepository.BuscarPorIdAsync(id);
            if (secao == null)
                throw new Exception("Não há seção com este ID");
            try
            {
                return await _secaoRepository.DeletarAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
