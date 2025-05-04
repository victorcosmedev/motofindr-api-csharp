using Microsoft.EntityFrameworkCore;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Infrastructure.Data.AppData;
using System.Linq.Expressions;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        ApplicationContext _context;
        public PatioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<PatioEntity> AdicionarAsync(PatioEntity patio)
        {
            try
            {
                _context.Patio.Add(patio);
                await _context.SaveChangesAsync();
                return patio;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AtualizarAsync(int id, PatioEntity patioAtualizado)
        {
            try
            {
                var patioExistente = await _context.Patio.FindAsync(id);
                if (patioExistente == null)
                    return false;

                patioExistente.Largura = patioAtualizado.Largura;
                patioExistente.Comprimento = patioAtualizado.Comprimento;
                patioExistente.Secoes = patioAtualizado.Secoes;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PatioEntity?> BuscarPorIdAsync(int id)
        {
            try
            {
                var patio = await _context.Patio.FindAsync(id);
                if (patio == null) return null;
                return patio;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PatioEntity>> BuscarTodosAsync()
        {
            var patios = await _context.Patio.ToListAsync();
            if(patios == null || patios.Count == 0) return Enumerable.Empty<PatioEntity>();
            return patios;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var patio = await _context.Patio.FindAsync(id);
                if (patio == null) return false;

                _context.Remove(patio);
                await _context.SaveChangesAsync();
                return true;
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
                await _context.Patio.AddAsync(patio);
                await _context.SaveChangesAsync();
                return patio;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
