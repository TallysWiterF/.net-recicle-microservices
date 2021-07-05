using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class Coletor : Entity
    {
        public Guid IdUser { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public Coletor() : base()
        {

        }

        public Coletor DefinirTelefone(string telefone)
        {
            Telefone = telefone;
            Validar();
            return this;
        }

        public Coletor DefinirEmail(string email)
        {
            Email = email;
            Validar();
            return this;
        }

        public Coletor DefinirNome(string nome)
        {
            Nome = nome;
            Validar();
            return this;
        }

        public override void Validar()
        {
            base.Validar(new ColetorValidador(), this);
        }
    }
}
