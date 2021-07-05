using Dominio.ValuesTypes;
using System;

namespace WebApi.Core.DTO
{
    public class DistribuidorDTO : BaseDTO
    {
        public Guid IdUser { get; init; }
        public string Nome { get; init; }
        public string NumeroResidencia { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Latitude { get; init; }
        public string Longitude { get; init; }
        public Guid IdEndereco { get; init; }
        public EnderecoDTO Endereco { get; init; }
    }

    public class EnderecoDTO : BaseDTO
    {
        public string Cep { get; init; }
        public string Rua { get; init; }
        public string Cidade { get; init; }
        public string Bairro { get; init; }
        public string Complemento { get; init; }
        public EnumUf Uf { get; init; }
    }
}
