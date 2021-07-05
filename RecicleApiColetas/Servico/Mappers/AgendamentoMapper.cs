using AutoMapper;
using Dominio.Contratos.Commands;
using Dominio.Entidades;

namespace Servico.Mappers
{
    public class AgendamentoMapper : Profile
    {
        public AgendamentoMapper()
        {
            CreateMap<AddAgendamentoCommand, Agendamento>()
                .AfterMap((src, dest) => dest.Validar());
            CreateMap<AtualizarAgendamentoCommand,Agendamento>()
                .AfterMap((src, dest) => dest.Validar());
        }
    }
}
