using AutoMapper;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Entidades;

namespace Servico.Mappers
{
    public class ColetorMapper : Profile
    {
        public ColetorMapper()
        {
            CreateMap<AddColetorCommand, Coletor>()
                .ForMember(dest => dest.Nome, options => options.MapFrom(src => src.Nome.ToUpper()))
                .AfterMap((src, dest) => dest.Validar());
            CreateMap<AtualizarColetorCommand, Coletor>()
                .ForMember(dest => dest.Nome, options => options.MapFrom(src => src.Nome.ToUpper()))
                 .AfterMap((src, dest) => dest.Validar());
        }
    }
}
