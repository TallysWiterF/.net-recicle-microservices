using Core.Base;
using Dominio.Contratos.Commands.AgendamentoCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class AgendamentoMessage : IMessageResponse
    {
        public Agendamento Entidade { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Agendamento> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddAgendamentoCommand { Agendamento = Entidade },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarAgendamentoCommand { Agendamento = Entidade },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverAgendamentoCommand { Id = Entidade.Id };
        }
    }
}
