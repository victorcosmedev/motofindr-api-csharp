using Microsoft.EntityFrameworkCore;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Infrastructure.Data.AppData;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class SecaoRepository : ISecaoRepository
    {
        ApplicationContext _context;

        public SecaoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<SecaoEntity> AdicionarAsync(SecaoEntity secao)
        {
            try
            {
                _context.Secao.Add(secao);
                await _context.SaveChangesAsync();
                return secao;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AtualizarAsync(int id, SecaoEntity secaoAtualizada)
        {
            try
            {
                var secaoExistente = await _context.Secao.FindAsync(id);
                if (secaoExistente == null)
                    return false;
            
                secaoExistente.Patio = secaoAtualizada.Patio;
                secaoExistente.PatioId = secaoAtualizada.PatioId;
                secaoExistente.Vagas = secaoAtualizada.Vagas;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<SecaoEntity?> BuscarPorIdAsync(int id)
        {
            try
            {
                var secao = await _context.Secao.FindAsync(id);
                if (secao == null) return null;
                return secao;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SecaoEntity>> BuscarTodosAsync()
        {
            var secoes = await _context.Secao.ToListAsync();
            if (secoes == null || secoes.Count == 0) return Enumerable.Empty<SecaoEntity>();
            return secoes;
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SecaoEntity> SalvarAsync(SecaoEntity secao)
        {
            throw new NotImplementedException();
        }
    }
}
