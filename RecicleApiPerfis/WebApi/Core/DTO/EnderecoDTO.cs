using Dominio.ValuesTypes;

namespace WebApi.Core.DTO
{
    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public EnumUf Uf { get; set; }
    }
}
