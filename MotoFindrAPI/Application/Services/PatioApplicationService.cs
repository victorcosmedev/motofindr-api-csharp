using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Application.Services
{
    public class PatioApplicationService : IPatioApplicationService
    {
        private readonly IPatioRepository _repository;
        public PatioApplicationService(IPatioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AtualizarPatioAsync(int id, PatioEntity patio)
        {
            try
            {
                return await _repository.AtualizarAsync(id, patio);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PatioEntity?> BuscarPatioPorIdAsync(int id)
        {
            try
            {
                return await _repository.BuscarPorIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PatioEntity>> BuscarTodosPatiosAsync()
        {
            try
            {
                return await _repository.BuscarTodosAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeletarPatioAsync(int id)
        {
            try
            {
                return await _repository.DeletarAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PatioEntity> SalvarAsync(PatioEntity patio)
        {
            try
            {
                return await _repository.SalvarAsync(patio);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
