using AutoMapper;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Entidades;

namespace Servico.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<AddItemCommand, Item>()
                .AfterMap((src, dest) => 
                {
                    dest.IniciarNovoEstoqe();
                    dest.Estoque.DefinirQuantidade(src.Quantidade);
                    dest.Estoque.DefinirTipoQuantidade(src.TipoQuantidade);
                    dest.Validar();
                });
            CreateMap<AtualizarItemCommand, Item>()
                 .AfterMap((src, dest) =>
                 {
                     dest.Validar();
                 });
        }
    }
}
