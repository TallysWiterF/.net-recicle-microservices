using System;
using Dominio.Validadores;
using Dominio.ValuesTypes;

namespace Dominio.Entidades
{
    public class Item : Entity
    {
        public Guid IdEstoque { get; private set; }
        public Guid IdDistribuidor { get; private set; }
        public string Nome { get; private set; }
        public EnumTipoMaterial TipoMaterial { get; private set; }
        public Estoque Estoque { get; private set; }
        public Item()
        {
        }
        public override void Validar()
        {
            base.Validar(new ItemValidador(), this);
        }

        public Item DefinirNome(string nome)
        {
            Nome = nome;
            Validar();
            return this;
        }

        public Item DefinirTipoMaterial(EnumTipoMaterial tipoMaterial)
        {
            TipoMaterial = tipoMaterial;
            Validar();
            return this;
        }

        public Item IniciarNovoEstoqe(Estoque estoque = null)
        {
            Estoque = estoque ?? new Estoque();
            IdEstoque = Estoque.Id;
            Validar();
            return this;
        }
    }
}
