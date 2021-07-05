using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using Repositorio.Contexto;
using Repositorio.Sincronizacao;

namespace Repositorio.Repositorios.Base
{
    public class BaseRepositoryInjector
    {
        internal ContextoEntity Context;
        internal INotificador Notificador;
        internal IUnitOfWork UnitOfWork;
        internal ISincronizacaoEvent Sincronizador;

        public BaseRepositoryInjector(
                    ContextoEntity context,
                    INotificador notificador,
                    IUnitOfWork unitOfWork, 
                    ISincronizacaoEvent sincronizador)
        {
            Context = context;
            Notificador = notificador;
            UnitOfWork = unitOfWork;
            Sincronizador = sincronizador;
        }
    }
}
