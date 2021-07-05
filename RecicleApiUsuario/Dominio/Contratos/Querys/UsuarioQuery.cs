using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Querys
{
    public class UsuarioQuery : BaseCommand<Usuario>
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
    }
}
