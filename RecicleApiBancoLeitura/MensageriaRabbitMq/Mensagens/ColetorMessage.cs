using Core.Base;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class ColetorMessage : IMessageResponse
    {
        public Coletor Coletor { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Coletor> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddColetorCommand { Coletor = Coletor },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarColetorCommand { Coletor = Coletor },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverColetorCommand { Id = Coletor.Id };
        }
    }
}
