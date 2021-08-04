using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class DistribuidorMessage : IMessageResponse
    {
        public Distribuidor Entidade { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Distribuidor> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddDistribuidorCommand { Distribuidor = Entidade },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarDistribuidorCommand { Distribuidor = Entidade },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverDistribuidorCommand { Id = Entidade.Id };
        }
    }
}
