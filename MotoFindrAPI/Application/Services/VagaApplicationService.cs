using AutoMapper;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Domain.Entities;


namespace MotoFindrAPI.Application.Services
{
    public class VagaApplicationService : IVagaApplicationService
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;
        private readonly ISecaoRepository _secaoRepository;
        private readonly IMotoRepository _motoRepository;

        public VagaApplicationService(IVagaRepository repository, IMapper mapper, ISecaoRepository secaoRepository, IMotoRepository motoRepository)
        {
            _vagaRepository = repository;
            _mapper = mapper;
            _secaoRepository = secaoRepository;
            _motoRepository = motoRepository;
        }

        public async Task<VagaDTO> SalvarVagaAsync(VagaDTO dto)
        {
            var entity = _mapper.Map<VagaEntity>(dto);
            if (entity == null)
                throw new Exception("Não é possível salvar uma entrada nula");
            entity.Secao = await AtribuirSecao(entity);
            entity.Moto = await AtribuirMoto(entity);

            entity = await _vagaRepository.SalvarAsync(entity);
            return _mapper.Map<VagaDTO>(entity);
        }

        public async Task<bool> AtualizarVagaAsync(int id, VagaDTO dto)
        {
            try
            {
                var entity = _mapper.Map<VagaEntity>(dto);
                entity.Moto = await AtribuirMoto(entity);
                entity.Secao = await AtribuirSecao(entity);
                return await _vagaRepository.AtualizarAsync(id, entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<VagaDTO?>> BuscarTodasVagasPorPatioAsync(int patioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VagaDTO?>> BuscarTodasVagasPorSecaoAsync(int secaoId)
        {
            throw new NotImplementedException();
        }

        public async Task<VagaDTO?> BuscarVagaPorIdAsync(int id)
        {
            try
            {
                var vaga = await _vagaRepository.BuscarVagaPorIdAsync(id);
                var dto = _mapper.Map<VagaDTO>(vaga);
                return dto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Task<bool> DeletarVagaAsync(int id)
        {
            throw new NotImplementedException();
        }

        private async Task<SecaoEntity?> AtribuirSecao(VagaEntity entity)
        {
            var secao = await _secaoRepository.BuscarPorIdAsync(entity.SecaoId);
            if (secao == null) 
                throw new Exception($"Seção de Id: {entity.SecaoId} não existe.");
            return secao;
        }

        private async Task<MotoEntity> AtribuirMoto(VagaEntity entity)
        {
            if (entity.MotoId == null)
                return null;

            var moto = await _motoRepository.BuscarPorIdAsync((int)entity.MotoId);
            if (moto == null)
                throw new Exception($"Moto de ID {entity.MotoId} não existe.");
            return moto;
        }
    }
}
