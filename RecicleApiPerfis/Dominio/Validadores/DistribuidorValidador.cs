using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;
using Crosscuting.Extensoes;

namespace Dominio.Validadores
{
    public class DistribuidorValidador : AbstractValidator<Distribuidor>
    {
        public DistribuidorValidador()
        {
            RuleFor(x => x.IdUser).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Usuário"));
            RuleFor(x => x.Email).NotNull().WithMessage(MensagensValidador.NotNullGeneric("E-mail")).EmailAddress()
                .WithMessage(MensagensValidador.EmailInvalid("E-mail")).MaximumLength(50)
                .WithMessage(MensagensValidador.MaxLengthInvalid("E-mail"));
            RuleFor(x => x.Nome).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Nome"));
            RuleFor(x => x.NumeroResidencia).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Número Residência"));
            RuleFor(x => x.Telefone).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Usuário"))
                .Must(x => x.FullNumber()).WithMessage(MensagensValidador.DontNumber("Telefone"))
                .MinimumLength(10).WithMessage(MensagensValidador.MinLengthInvalid("Telefone"))
                .MaximumLength(11).WithMessage(MensagensValidador.MaxLengthInvalid("Telefone"));

        }
    }
}