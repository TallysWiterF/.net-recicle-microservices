using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Querys
{
    public class ColetorQuery : BaseCommand<Coletor>
    {
        public Guid? Id { get; init; }
        public Guid? IdUser { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
    }
}
