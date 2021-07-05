using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class DistribuidorMessage : IMessageResponse
    {
        public Distribuidor Distribuidor { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Distribuidor> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddDistribuidorCommand { Distribuidor = Distribuidor },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarDistribuidorCommand { Distribuidor = Distribuidor },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverDistribuidorCommand { Id = Distribuidor.Id };
        }
    }
}
