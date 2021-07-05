using Core.Objetos;
using Crosscuting.Extensoes;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class EnderecoValidador : AbstractValidator<Endereco>
    {
        public EnderecoValidador()
        {
            RuleFor(x => x.Cep).NotNull().WithMessage(MensagensValidador.NotNullGeneric("CEP"))
                .Must((e, x) => x.FullNumber()).WithMessage("CEP informado está inválido.");
        }
    }
}
