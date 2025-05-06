using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface ISecaoApplicationService
    {
        Task<SecaoEntity?> BuscarSecaoPorIdAsync(int id);
        Task<SecaoEntity> SalvarAsync(SecaoEntity secao);
        Task<bool> AtualizarSecaoAsync(int id, SecaoEntity secao);
        Task<bool> DeletarSecaoAsync(int id);
    }
}
