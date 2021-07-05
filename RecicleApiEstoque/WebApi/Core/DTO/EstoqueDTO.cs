using System;

namespace WebApi.Core.DTO
{
    public class EstoqueDTO : BaseDTO
    {
        public double Quantidade { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
    }
}
