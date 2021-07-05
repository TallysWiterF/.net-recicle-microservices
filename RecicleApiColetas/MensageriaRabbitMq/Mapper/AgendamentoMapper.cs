using AutoMapper;
using Dominio.Contratos.Commands;
using MensageriaRabbitMq.Mensagens;

namespace MensageriaRabbitMq.Mapper
{
    public class AgendamentoMapper : Profile
    {
        public AgendamentoMapper()
        {
            CreateMap<RemoverAgendamentoMessage, RemoverAgendamentosCommand>();
        }
    }
}
