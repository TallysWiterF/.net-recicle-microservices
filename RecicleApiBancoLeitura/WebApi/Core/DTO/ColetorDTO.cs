using System;

namespace WebApi.Core.DTO
{
    public class ColetorDTO : BaseDTO
    {
        public Guid IdUser { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
    }
}
