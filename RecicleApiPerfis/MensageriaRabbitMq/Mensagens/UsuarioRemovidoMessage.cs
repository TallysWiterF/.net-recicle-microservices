using Aplicacao.Commands;
using Dominio.Contratos.Commands.Base;
using MensageriaRabbitMq.Setup.Contratos;
using System;

namespace MensageriaRabbitMq.Mensagens
{
    public class UsuarioRemovidoMessage : IMessageResponse
    {
        public Guid IdUser { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
        public UsuarioRemovidoMessage(Guid idUser, EnumTipoUsuario tipoUsuario)
        {
            IdUser = idUser;
            TipoUsuario = tipoUsuario;
        }
       
        public RemoverCommand CriarCommandRemocaoEspecifica() =>
            TipoUsuario switch
            {
                EnumTipoUsuario.COLETOR => new RemoverColetorPorUsuarioCommand(IdUser),
                EnumTipoUsuario.DISTRIBUIDOR => new RemoverDistribuidorPorUsuarioCommand(IdUser),
                _ => throw new ArgumentOutOfRangeException("USUÁRIO NÃO RECONHECIDO"),
            };
    }

    public enum EnumTipoUsuario
    {
        COLETOR = 1,
        DISTRIBUIDOR = 2,
    }
}
