using System;

namespace Dominio.Entidades
{
    public class Coletor : Entity
    {
        public Guid IdUser { get; init; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public string Email { get; init; }
    }
}
