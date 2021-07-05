using System;

namespace Dominio.Entidades
{
    public class Distribuidor : Entity
    {
        public Guid IdUser { get; init; }
        public string Nome { get; init; }
        public string NumeroResidencia { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
        public string Latitude { get; init; }
        public string Longitude { get; init; }
        public Guid IdEndereco { get; init; }
        public Endereco Endereco { get; init; }
    }
}
