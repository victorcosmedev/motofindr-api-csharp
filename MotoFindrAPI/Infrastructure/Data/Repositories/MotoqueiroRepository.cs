using Microsoft.EntityFrameworkCore;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Infrastructure.Data.AppData;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class MotoqueiroRepository : IMotoqueiroRepository
    {
        private readonly ApplicationContext _context;

        public MotoqueiroRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<MotoqueiroEntity> SalvarAsync(MotoqueiroEntity entity)
        {
            try
            {
                _context.Motoqueiro.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AtualizarAsync(int id, MotoqueiroEntity entity)
        {
            try
            {
                var motoqueiroExistente = await _context.Motoqueiro.FindAsync(id);
                if (motoqueiroExistente == null)
                    throw new Exception($"Não há nenhum motoqueiro com o Id {id}.");

                motoqueiroExistente.NomeUser = entity.NomeUser;
                motoqueiroExistente.DataAniversarioUser = entity.DataAniversarioUser;
                motoqueiroExistente.CpfUser = entity.CpfUser;
                motoqueiroExistente.MotoId = entity.MotoId;
                motoqueiroExistente.Moto = entity.Moto;
                motoqueiroExistente.Cnh = entity.Cnh;
                motoqueiroExistente.Endereco = entity.Endereco;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MotoqueiroEntity?> BuscarPorIdAsync(int id)
        {
            try
            {
                var motoqueiro = await _context.Motoqueiro.FindAsync(id);
                return motoqueiro;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MotoqueiroEntity>> BuscarTodosAsync()
        {
            try
            {
                var motoqueiros = await _context.Motoqueiro.ToListAsync();
                return motoqueiros;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var motoqueiro = await _context.Motoqueiro.FindAsync(id);
                if (motoqueiro == null)
                    throw new Exception($"Motoqueiro de id {id} não existe");
                _context.Motoqueiro.Remove(motoqueiro);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
