using Core.Base;
using Dominio.ValuesTypes;
using System;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class BaseItemCommand<TReturn> : BaseCommand<TReturn>
    {
        public Guid IdDistribuidor { get; init; }
        public string Nome { get; init; }
        public EnumTipoMaterial TipoMaterial { get; init; }
        public double Quantidade { get; init; }
        public EnumTipoQuantidade TipoQuantidade { get; init; }
    }
}
