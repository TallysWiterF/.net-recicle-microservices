using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class DebitarItemEstoqueCommand : BaseCommand<Estoque>
    {
        public Guid Id { get; init; }
        public double Quantidade { get; init; }
    }
}
