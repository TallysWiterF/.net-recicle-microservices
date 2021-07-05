using Aplicacao.Contratos;
using Core.Base;
using Dominio.ValuesTypes;
using System;

namespace Aplicacao.Eventos
{
    public class UsuarioRemovidoEvent : BaseEvent
    {
        public UsuarioRemovidoEvent(IUsuarioRequisicao usuarioRequisicao)
        {
            IdUser = usuarioRequisicao.Id();
            TipoUsuario = usuarioRequisicao.TipoUsuario();
        }
        public Guid IdUser { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
    }
}
