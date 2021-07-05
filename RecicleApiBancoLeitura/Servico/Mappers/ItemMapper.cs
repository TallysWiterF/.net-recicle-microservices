using AutoMapper;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Entidades;

namespace Services.Mapper
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<AddItemCommand, Item>();
            CreateMap<AtualizarItemCommand, Item>();
        }
    }
}
