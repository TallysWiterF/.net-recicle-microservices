using AutoMapper;
using Dominio.Contratos.Commands.AgendamentoCommands;
using Dominio.Entidades;

namespace Services.Mapper
{
    public class AgendamentoMapper : Profile
    {
        public AgendamentoMapper()
        {
            CreateMap<AddAgendamentoCommand, Agendamento>();
            CreateMap<AtualizarAgendamentoCommand, Agendamento>();
        }
    }
}
