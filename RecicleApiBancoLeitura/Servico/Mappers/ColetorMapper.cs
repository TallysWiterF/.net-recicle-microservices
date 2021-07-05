using AutoMapper;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Entidades;

namespace Services.Mapper
{
    public class ColetorMapper : Profile
    {
        public ColetorMapper()
        {
            CreateMap<AddColetorCommand, Coletor>();
            CreateMap<AtualizarColetorCommand, Coletor>();
        }
    }
}
