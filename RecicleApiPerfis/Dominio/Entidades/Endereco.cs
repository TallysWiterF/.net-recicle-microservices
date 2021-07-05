using Dominio.Validadores;
using Dominio.ValuesTypes;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Endereco : Entity
    {
        public string Cep { get; init; }
        public string Rua { get; init; }
        public string Cidade { get; init; }
        public string Bairro { get; init; }
        public string Complemento { get; init; }
        public EnumUf Uf { get; init; }

        public override void Validar()
        {
            base.Validar(new EnderecoValidador(), this);
        }
    }
}
