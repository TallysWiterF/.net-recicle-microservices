using Core.Base;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Mensagens
{
    public class ItemMessage : IMessageResponse
    {
        public Item Item { get; set; }
        public EnumTipoSincronizacaoMessage Tipo { get; set; }

        public BaseCommand<Item> CriarCommandEspecifico()
        {
            return Tipo switch
            {
                EnumTipoSincronizacaoMessage.ADICIONAR => new AddItemCommand { Item = Item },
                EnumTipoSincronizacaoMessage.ATUALIZAR => new AtualizarItemCommand { Item = Item },
                _ => null
            };
        }

        public BaseCommand<bool> CriarCommandRemover()
        {
            return new RemoverItemCommand { Id = Item.Id };
        }
    }
}
