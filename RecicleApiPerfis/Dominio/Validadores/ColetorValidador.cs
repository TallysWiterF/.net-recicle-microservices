using Core.Objetos;
using Crosscuting.Extensoes;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class ColetorValidador : AbstractValidator<Coletor>
    {
        public ColetorValidador()
        {
            RuleFor(x => x.IdUser).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Usuário"));
            RuleFor(x => x.Nome).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Nome"));
            RuleFor(x => x.Telefone).NotNull().WithMessage(MensagensValidador.NotNullGeneric("Telefone"))
                .Must((e, x) => x.FullNumber()).WithMessage(MensagensValidador.DontNumber("Telefone"))
                .MinimumLength(10).WithMessage(MensagensValidador.MinLengthInvalid("Telefone"))
                .MaximumLength(11).WithMessage(MensagensValidador.MaxLengthInvalid("Telefone"));
        }
    }
}
