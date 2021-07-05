using Core.Base;
using Dominio.Entidades;
using System;

namespace Repositorio.Sincronizacao
{
    public class AddSincronizacaoEvent<TEntidade> : BaseEvent where TEntidade : Entity
    {
        public TEntidade Entidade { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get => EnumTipoSincronizacaoMessage.ADICIONAR; }
    }

    public class AtualizarSincronizacaoEvent<TEntidade> : BaseEvent where TEntidade : Entity
    {
        public TEntidade Entidade { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get => EnumTipoSincronizacaoMessage.ATUALIZAR; }
    }

    public class RemoverSincronizacaoEvent<TEntidade> : BaseEvent where TEntidade : Entity
    {
        public TEntidade Entidade { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get => EnumTipoSincronizacaoMessage.REMOVER; }
    }

    public enum EnumTipoSincronizacaoMessage
    {
        ADICIONAR = 1,
        ATUALIZAR = 2,
        REMOVER = 3,
    }
}
