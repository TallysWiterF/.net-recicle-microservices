using AutoMapper;
using Dominio.Contratos.Commands.ItemCommands;
using MensageriaRabbitMq.Mensagens;

namespace MensageriaRabbitMq.Mapper
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<RemoverItemMessage, RemoverItensCommand>();
        }
    }
}
