using Core.Base;
using System;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class BaseColetorCommand<TReturn> : BaseCommand<TReturn>
    {
        public Guid IdUser { get; set; }
        public string Nome { get; init; }
        public string Telefone { get; init; }
    }
}
