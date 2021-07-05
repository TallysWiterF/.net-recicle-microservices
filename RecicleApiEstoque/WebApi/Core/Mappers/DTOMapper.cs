using AutoMapper;
using Dominio.Entidades;
using WebApi.Core.DTO;

namespace WebApi.Core.Mappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<Estoque, EstoqueDTO>();
            CreateMap<Item, ItemDTO>()
                .AfterMap((src, dest, context) => context.Mapper.Map<EstoqueDTO>(src.Estoque));
        }
    }
}
