using Dominio.ValuesTypes;
using System;

namespace Dominio.Entidades
{
    public class Item : Entity
    {
        public Guid IdDistribuidor { get; init; }
        public string Nome { get; init; }
        public EnumTipoMaterial TipoMaterial { get; init; }
        public Estoque Estoque { get; init; }
    }
}
