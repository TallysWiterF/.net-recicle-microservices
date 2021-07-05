using Core.Base;
using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Querys
{
    public class DistribuidorQuery : BaseCommand<IEnumerable<Distribuidor>>
    {
        public Guid? Id { get; init; }
        public Guid? IdUser { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
    }
}
