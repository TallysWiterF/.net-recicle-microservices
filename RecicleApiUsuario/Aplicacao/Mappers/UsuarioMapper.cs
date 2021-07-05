using Aplicacao.Commands;
using AutoMapper;
using System.Security.Claims;

namespace Aplicacao.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<ClaimsCommand, Claim>()
                .ConstructUsing(src => new Claim(src.Tipo, src.Valor));
        }
    }
}
