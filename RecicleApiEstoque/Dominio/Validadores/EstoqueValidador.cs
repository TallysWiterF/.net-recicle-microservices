using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class EstoqueValidador : AbstractValidator<Estoque>
    {
        public EstoqueValidador()
        {
            RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0).WithMessage("Quantidade de estoque não pode ficar abaixo de 0. Valor calculado foi de {PropertyValue}");
            RuleFor(x => x.TipoQuantidade).IsInEnum().WithMessage(MensagensValidador.NotEnum("Tipo Quantidade"));
        }
    }
}
