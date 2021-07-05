using Core.Base;
using System;

namespace Dominio.Contratos.Commands.Comum
{
    public class AdicionarRegrasAcessoPerfilCommand : BaseCommand<bool>
    {
        public Guid IdPerfil { get; init; }

        public AdicionarRegrasAcessoPerfilCommand(Guid idPerfil)
        {
            IdPerfil = idPerfil;
        }
    }
}
