using Crosscuting.Notificacao;
using Repositorio.Contexto;

namespace Repositorio.Repositorios.Base
{
    public class BaseRepositoryInjector
    {
        internal ContextMongo Context;
        internal INotificador Notificador;

        public BaseRepositoryInjector(
                    ContextMongo context,
                    INotificador notificador)
        {
            Context = context;
            Notificador = notificador;
        }
    }
}
