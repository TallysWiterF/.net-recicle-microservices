using Dominio.Entidades;
using Dominio.ValuesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core.DTO
{
    public class ItemDTO : BaseDTO
    {
        public Guid IdDistribuidor { get; init; }
        public string Nome { get; init; }
        public EnumTipoMaterial TipoMaterial { get; init; }
        public EstoqueDTO Estoque { get; init; }
    }

    public class EstoqueDTO : BaseDTO
    {
        public Guid IdItem { get; init; }
        public double Quantidade { get; init; }
        public DateTime DataAtualizacao { get; init; }
        public EnumTipoQuantidade TipoQuantidade { get; private set; }
    }
}
