using AutoMapper;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Interfaces;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Services
{
    public class MotoqueiroApplicationService : IMotoqueiroApplicationService
    {
        private readonly IMotoqueiroRepository _motoqueiroRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly IMapper _mapper;

        public MotoqueiroApplicationService(IMotoqueiroRepository motoqueiroRepository, IMotoRepository motoRepository, IMapper mapper)
        {
            _motoqueiroRepository = motoqueiroRepository;
            _motoRepository = motoRepository;
            _mapper = mapper;
        }

        public async Task<MotoqueiroDTO> SalvarAsync(MotoqueiroDTO dto)
        {
            var entity = _mapper.Map<MotoqueiroEntity>(dto);
            if (entity == null)
                throw new Exception("Não é possível cadastrar esta entrada nula");
            entity.Moto = await AtribuirMotoAsync(entity);
            entity = await _motoqueiroRepository.SalvarAsync(entity);
            return _mapper.Map<MotoqueiroDTO>(entity);
        }
        public async Task<bool> AtualizarAsync(int id, MotoqueiroDTO dto)
        {
            var entity = _mapper.Map<MotoqueiroEntity>(dto);
            entity.Moto = await AtribuirMotoAsync(entity);
            return await _motoqueiroRepository.AtualizarAsync(id, entity);
        }

        public async Task<MotoqueiroDTO?> BuscarPorIdAsync(int id)
        {
            var entity = await _motoqueiroRepository.BuscarPorIdAsync(id);
            if (entity == null)
                return null;
            var dto = _mapper.Map<MotoqueiroDTO>(entity);
            return dto;
        }

        public async Task<IEnumerable<MotoqueiroDTO>?> BuscarTodosAsync()
        {
            var motoqueiros = await _motoqueiroRepository.BuscarTodosAsync();
            if (motoqueiros == null)
                return null;
            var motoqueirosDTO = motoqueiros.Select(x => _mapper.Map<MotoqueiroDTO>(x));
            return motoqueirosDTO;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _motoqueiroRepository.DeletarAsync(id);
        }
        private async Task<MotoEntity?> AtribuirMotoAsync(MotoqueiroEntity entity)
        {
            var moto = await _motoRepository.BuscarPorIdAsync(entity.MotoId);
            if (moto == null)
                throw new Exception($"Moto de Id: {entity.MotoId} não existe.");
            return moto;
        }
    }
}
