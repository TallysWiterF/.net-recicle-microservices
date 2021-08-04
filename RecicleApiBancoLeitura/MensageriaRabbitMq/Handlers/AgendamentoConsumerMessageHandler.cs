using Dominio.Contratos.Commands.AgendamentoCommands;
using MensageriaRabbitMq.Contratos.Consumidores;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers
{
    public class AgendamentoConsumerMessageHandler : IAgendamentoMessageHandler
    {
        private readonly MensageriaInjector _injector;

        public AgendamentoConsumerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(ResponseHandler<AgendamentoMessage> response)
        {
            if(response.Dados.Tipo == EnumTipoSincronizacaoMessage.REMOVER)
                await _injector.MediatorCustom.EnviarComandoAsync(response.Dados.CriarCommandRemover());
            else
                await _injector.MediatorCustom.EnviarComandoAsync(response.Dados.CriarCommandEspecifico());
        }


        public async Task Register()
        {
            await _injector.Rabbit.CreateQueue(Filas.AGENDAMENTO_LEITURA.ToString());
            await _injector.Rabbit.Consumer(this, Filas.AGENDAMENTO_LEITURA.ToString());
        }

        public async Task RegisterAll()
        {
            await Register();
        }
    }
}
