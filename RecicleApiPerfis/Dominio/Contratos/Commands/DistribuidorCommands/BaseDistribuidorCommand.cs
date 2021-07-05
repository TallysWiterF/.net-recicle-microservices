using Core.Base;
using System;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class BaseDistribuidorCommand<TReturn> : BaseCommand<TReturn>
    {
        public Guid IdUser { get; set; }
        public string Cep { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NumeroResidencia { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
