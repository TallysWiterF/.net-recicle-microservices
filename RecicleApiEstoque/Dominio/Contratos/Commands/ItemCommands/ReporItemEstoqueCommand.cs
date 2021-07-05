using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class ReporItemEstoqueCommand : BaseCommand<Estoque>
    {
        public Guid Id { get; init; }
        public double Quantidade { get; init; }
    }
}
