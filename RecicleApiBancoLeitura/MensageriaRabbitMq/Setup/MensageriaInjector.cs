using Core.Base;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Setup
{
    public class MensageriaInjector
    {
        public readonly IRabbit Rabbit;
        public readonly IMediatorCustom MediatorCustom;
        public MensageriaInjector(IRabbit rabbit, IMediatorCustom mediatorCustom)
        {
            Rabbit = rabbit;
            MediatorCustom = mediatorCustom;
        }
    }
}
