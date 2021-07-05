using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Querys
{
    public class DistribuidorQuery : BaseCommand<Distribuidor>
    {
        public Guid? Id { get; set; }
        public Guid? IdItem { get; set; }
        public Guid? IdUser { get; set; }
    }
}
