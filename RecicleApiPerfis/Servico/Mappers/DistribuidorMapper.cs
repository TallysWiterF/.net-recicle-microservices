using AutoMapper;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;
using Crosscuting.Extensoes;

namespace Servico.Mappers
{
    public class DistribuidorMapper : Profile
    {
        public DistribuidorMapper()
        {
            CreateMap<AddDistribuidorCommand, Distribuidor>()
                .ForMember(dest => dest.Latitude, options => options.MapFrom(src => src.Latitude.ToStringIfContainsValue()))
                .ForMember(dest => dest.Longitude, options => options.MapFrom(src => src.Longitude.ToStringIfContainsValue()))
                .ForMember(dest => dest.Nome, options => options.MapFrom(src => src.Nome.ToUpper()))
                .ForMember(dest => dest.NumeroResidencia, options => options.MapFrom(src => src.NumeroResidencia.ToUpper()))
                .ForMember(dest => dest.Telefone, options => options.MapFrom(src => src.Telefone));
            CreateMap<AtualizarDistribuidorCommand, Distribuidor>()
                .ForMember(dest => dest.Latitude, options => options.MapFrom(src => src.Latitude.ToStringIfContainsValue()))
                .ForMember(dest => dest.Longitude, options => options.MapFrom(src => src.Longitude.ToStringIfContainsValue()))
                 .ForMember(dest => dest.Nome, options => options.MapFrom(src => src.Nome.ToUpper()))
                .ForMember(dest => dest.NumeroResidencia, options => options.MapFrom(src => src.NumeroResidencia.ToUpper()))
                .ForMember(dest => dest.Telefone, options => options.MapFrom(src => src.Telefone));
        }
    }
}
