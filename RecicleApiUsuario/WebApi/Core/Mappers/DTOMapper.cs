using AutoMapper;
using Dominio.Entidades;
using System;
using WebApi.Core.DTO;

namespace WebApi.Core.Mappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<UsuarioRegistroDTO, Usuario>()
               .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
               .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.Email))
               .ForMember(dest => dest.Tipo, options => options.MapFrom(src => src.Tipo))
               .AfterMap((src, dest) => dest.Id = Guid.NewGuid().ToString());

            CreateMap<Usuario, UsuarioDTO>()
               .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
               .ForMember(dest => dest.Tipo, options => options.MapFrom(src => src.Tipo.ToString()));
        }
    }
}
