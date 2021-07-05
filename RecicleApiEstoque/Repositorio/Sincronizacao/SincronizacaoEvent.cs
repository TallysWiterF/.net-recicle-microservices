using Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositorio.Sincronizacao
{
    public class SincronizacaoEvent : ISincronizacaoEvent
    {
        private readonly List<BaseEvent> _eventos;
        private readonly IMediatorCustom _mediatorCustom;

        public SincronizacaoEvent(IMediatorCustom mediatorCustom)
        {
            _eventos = new List<BaseEvent>();
            _mediatorCustom = mediatorCustom;
        }

        public IReadOnlyList<BaseEvent> Eventos() => _eventos;
        public void AddEvento<TEvent>(TEvent evento) where TEvent : BaseEvent => _eventos.Add(evento);
        public async Task SincronizarAsync()
        {
            foreach (var evento in _eventos)
                await _mediatorCustom.PublicarEventoAsync(evento);
        }
    }
}
