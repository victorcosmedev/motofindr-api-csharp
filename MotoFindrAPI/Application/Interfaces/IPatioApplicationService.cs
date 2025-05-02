using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IPatioApplicationService
    {
        Task<IEnumerable<PatioEntity>> BuscarTodosPatiosAsync();
        Task<PatioEntity?> BuscarPatioPorIdAsync(int id);
        Task<PatioEntity> SalvarAsync(PatioEntity patio);
        Task<bool> AtualizarPatioAsync(int id, PatioEntity patio);
        Task<bool> DeletarPatioAsync(int id);
    }
}
