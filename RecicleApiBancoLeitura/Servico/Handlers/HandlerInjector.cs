using AutoMapper;
using Core.Base;

namespace Servico.Handlers
{
    public class HandlerInjector
    {
        internal readonly IMapper Mapper;
        internal readonly IMediatorCustom Mediator;

        public HandlerInjector(IMapper mapper, IMediatorCustom mediator)
        {
            Mapper = mapper;
            Mediator = mediator;
        }
    }
}
