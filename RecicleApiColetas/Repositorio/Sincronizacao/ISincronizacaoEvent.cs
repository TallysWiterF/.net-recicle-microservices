using Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositorio.Sincronizacao
{
    public interface ISincronizacaoEvent
    {
        IReadOnlyList<BaseEvent> Eventos();
        void AddEvento<TEvent>(TEvent evento) where TEvent : BaseEvent;
        Task SincronizarAsync();
    }
}
