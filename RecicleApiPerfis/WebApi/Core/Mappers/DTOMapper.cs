using AutoMapper;
using Dominio.Entidades;
using WebApi.Core.DTO;

namespace WebApi.Core.Mappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<Coletor, ColetorDTO>();
            CreateMap<Distribuidor, DistribuidorDTO>();
            CreateMap<Endereco, EnderecoDTO>();
        }
    }
}
