using Dominio.ValuesTypes;
using System;

namespace Dominio.Entidades
{
    public class Estoque : Entity
    {
        public Guid IdItem { get; init; }
        public double Quantidade { get; init; }
        public DateTime DataAtualizacao { get; init; }
        public EnumTipoQuantidade TipoQuantidade { get; private set; }
    }
}
