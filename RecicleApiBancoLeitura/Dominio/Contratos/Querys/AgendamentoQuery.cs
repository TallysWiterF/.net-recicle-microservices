using Core.Base;
using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Querys
{
    public class AgendamentoQuery : BaseCommand<IEnumerable<Agendamento>>
    {
        public Guid? IdDistribuidor { get; init; }
        public Guid? IdItem { get; init; }
        public Guid? IdColetor { get; init; }
        public bool Ativo { get; init; }
    }
}
