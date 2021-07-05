using Dominio.Validadores;
using Dominio.ValuesTypes;
using System;

namespace Dominio.Entidades
{
    public class Estoque : Entity
    {
        public double Quantidade { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public EnumTipoQuantidade TipoQuantidade { get; private set; }
        public Item Item { get; private set; }


        public Estoque()
        {
            DataAtualizacao = DateTime.Now;
        }
        public override void Validar()
        {
            base.Validar(new EstoqueValidador(), this);
        }

        public Estoque DefinirQuantidade(double quantidade)
        {
            Quantidade = quantidade;
            return this;
        }

        public Estoque ReporQuantidade(double quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;
            Quantidade += quantidade;
            return this;
        }

        public Estoque DebitarQuantidade(double quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;
            Quantidade -= quantidade;
            return this;
        }

        public Estoque DefinirTipoQuantidade(EnumTipoQuantidade enumTipoQuantidade)
        {
            TipoQuantidade = enumTipoQuantidade;
            return this;
        }

        public Estoque DefinirItem(Item item)
        {
            Item = item;
            return this;
        }

        public Estoque DefinirDataAtualizacao()
        {
            DataAtualizacao = DateTime.Now;
            return this;
        }
    }
}
