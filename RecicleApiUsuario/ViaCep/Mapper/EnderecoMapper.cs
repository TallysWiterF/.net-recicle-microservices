using AutoMapper;
using Dominio.Entidades;
using ViaCep.Objetos;

namespace ViaCep.Mapper
{
    public class EnderecoMapper : Profile
    {
        public EnderecoMapper()
        {
            CreateMap<EnderecoResponse, Endereco>()
                .ForMember(dest => dest.Cep, options => options.MapFrom(src => src.Cep.Replace("-", string.Empty)))
                .ForMember(dest => dest.Rua, options => options.MapFrom(src => src.Logradouro.ToUpper()))
                .ForMember(dest => dest.Cidade, options => options.MapFrom(src => src.Localidade.ToUpper()))
                .ForMember(dest => dest.Bairro, options => options.MapFrom(src => src.Bairro.ToUpper()))
                ;
        }
    }
}
