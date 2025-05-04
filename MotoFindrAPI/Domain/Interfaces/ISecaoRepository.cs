using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface ISecaoRepository
    {
        Task<IEnumerable<SecaoEntity>> BuscarTodosAsync();
        Task<SecaoEntity?> BuscarPorIdAsync(int id);
        Task<SecaoEntity> AdicionarAsync(SecaoEntity secao);
        Task<bool> AtualizarAsync(int id, SecaoEntity secaoAtualizada);
        Task<bool> DeletarAsync(int id);
        Task<SecaoEntity> SalvarAsync(SecaoEntity secao);
    }
}
