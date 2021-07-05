using System;

namespace WebApi.Core.DTO
{
    public class ColetorDTO : BaseDTO
    {
        public Guid IdUser { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
