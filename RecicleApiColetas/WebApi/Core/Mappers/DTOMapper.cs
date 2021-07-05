using AutoMapper;
using Dominio.Entidades;
using WebApi.Core.DTO;

namespace WebApi.Core.Mappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<Agendamento, AgendamentoDTO>();
        }
    }
}
