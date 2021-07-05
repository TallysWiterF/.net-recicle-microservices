using Core.Base;
using System;
using System.Collections.Generic;

namespace Aplicacao.Commands
{
    public class AdicionarClaimsCommand : BaseCommand<bool>
    {
        public List<ClaimsCommand> Claims { get; set; }
        public string Id { get; set; }

        public AdicionarClaimsCommand()
        {
            Claims = new List<ClaimsCommand>();
        }
    }
    public class ClaimsCommand
    {
        public string Tipo { get; set; }
        public string Valor { get; set; }
    }

}
