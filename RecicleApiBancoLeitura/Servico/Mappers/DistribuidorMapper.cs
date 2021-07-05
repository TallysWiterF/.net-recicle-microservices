using AutoMapper;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;

namespace Services.Mapper
{
    public class DistribuidorMapper : Profile
    {
        public DistribuidorMapper()
        {
            CreateMap<AddDistribuidorCommand, Distribuidor>();
            CreateMap<AtualizarDistribuidorCommand, Distribuidor>();
        }
    }
}
