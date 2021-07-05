using Core.Base;
using Dominio.Contratos.Commands.AgendamentoCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class AgendamentoMessage : IMessageResponse
    {
        public Agendamento Agendamento { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Agendamento> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddAgendamentoCommand { Agendamento = Agendamento },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarAgendamentoCommand { Agendamento = Agendamento },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverAgendamentoCommand { Id = Agendamento.Id };
        }
    }
}
