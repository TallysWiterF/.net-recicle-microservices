using Dominio.ValuesTypes;
using System;

namespace Aplicacao.Contratos
{
    public interface IUsuarioRequisicao
    {
        Guid Id();
        EnumTipoUsuario TipoUsuario();
    }
}
