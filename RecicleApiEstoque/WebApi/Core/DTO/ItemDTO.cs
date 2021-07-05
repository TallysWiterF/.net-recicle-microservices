using Dominio.ValuesTypes;
using System;

namespace WebApi.Core.DTO
{
    public class ItemDTO : BaseDTO
    {
        public Guid IdDistribuidor { get; private set; }
        public string Nome { get; private set; }
        public EnumTipoMaterial TipoMaterial { get; private set; }
        public EstoqueDTO Estoque { get; private set; }
    }
}
