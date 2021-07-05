using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class ItemValidador : AbstractValidator<Item>
    {
        public ItemValidador()
        {
            RuleFor(x => x.Estoque).SetValidator(new EstoqueValidador());
            RuleFor(x => x.IdDistribuidor).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric("Distribuidor"));
            RuleFor(x => x.TipoMaterial).IsInEnum().WithMessage(MensagensValidador.NotEnum("Tipo Material"));
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric("Nome"))
                                .MaximumLength(100).WithMessage(MensagensValidador.MaxLengthInvalid("Nome"));
        }
    }
}
