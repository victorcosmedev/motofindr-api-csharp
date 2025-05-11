using AutoMapper;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Domain.Entities;
namespace MotoFindrAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MotoDTO, MotoEntity>()
                .ForMember(dest => dest.Motoqueiro, opt => opt.Ignore())
                .ForMember(dest => dest.Vaga, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<VagaDTO, VagaEntity>()
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Secao, opt => opt.Ignore())
                .ForMember(dest => dest.Disponivel, opt => opt.Ignore());

            CreateMap<MotoqueiroDTO, MotoqueiroEntity>()
                .ForMember(dest => dest.NomeUser, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataAniversarioUser, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.CpfUser, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Moto, opt => opt.Ignore()) // Ignora a navegação
                .ReverseMap() // Mapeamento inverso (opcional)
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeUser))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataAniversarioUser))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.CpfUser));
        }
    }
    }
}
