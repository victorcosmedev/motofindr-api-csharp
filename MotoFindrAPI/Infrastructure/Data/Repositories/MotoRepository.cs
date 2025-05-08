using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Infrastructure.Data.AppData;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationContext _context;

        public MotoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<MotoEntity> SalvarAsync(MotoEntity entity)
        {
            try
            {
                await _context.Moto.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MotoEntity?> BuscarPorIdAsync(int id)
        {
            try
            {
                return await _context.Moto.FindAsync(id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> AtualizarAsync(int id, MotoEntity moto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoEntity?>> BuscarTodasPorPatioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoEntity?>> BuscarTodasPorSecaoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
