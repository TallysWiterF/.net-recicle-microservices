using Core.Base;
using Dominio.Entidades;
using Dominio.ValuesTypes;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Querys
{
    public class ItemQuery : BaseCommand<IEnumerable<Item>>
    {
        public Guid? Id { get; init; }
        public Guid? IdDistribuidor { get; init; }
        public string Nome { get; init; }
    }
}
