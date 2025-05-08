using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<MotoEntity>> BuscarTodasPorPatioAsync(int patioId);
        Task<IEnumerable<MotoEntity>> BuscarTodasPorSecaoAsync(int secaoId  );
        Task<MotoEntity?> BuscarPorIdAsync(int id);
        Task<MotoEntity> SalvarAsync(MotoEntity moto);
        Task<bool> AtualizarAsync(int id, MotoEntity moto);
        Task<bool> DeletarAsync(int id);

    }
}
