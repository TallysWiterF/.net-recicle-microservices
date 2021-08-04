using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class Distribuidor : Entity
    {
        public Guid IdUser { get; private set; }
        public string Nome { get; private set; }
        public string NumeroResidencia { get; private set; }
        public string Telefone { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public Guid IdEndereco { get; private set; }
        public Endereco Endereco { get; private set; }

        public override void Validar()
        {
            base.Validar(new DistribuidorValidador(), this);
        }

        public Distribuidor DefinirEndereco(Endereco endereco)
        {
            Endereco = endereco;
            if(Endereco is not null)
                IdEndereco = endereco.Id;
            Validar();
            return this;
        }

        public Distribuidor DefinirNome(string nome)
        {
            Nome = nome;
            Validar();
            return this;
        }

        public Distribuidor DefinirNumeroResidencia(string numeroResidencia)
        {
            NumeroResidencia = numeroResidencia;
            Validar();
            return this;
        }

        public Distribuidor DefinirTelefone(string telefone)
        {
            Telefone = telefone;
            Validar();
            return this;
        }
    }
}
