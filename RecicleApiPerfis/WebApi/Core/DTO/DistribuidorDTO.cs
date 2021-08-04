using System;

namespace WebApi.Core.DTO
{
    public class DistribuidorDTO : BaseDTO
    {
        public Guid IdUser { get; set; }
        public string Nome { get; set; }
        public string NumeroResidencia { get; set; }
        public string Telefone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
