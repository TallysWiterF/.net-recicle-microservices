using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class AgendamentoValidador : AbstractValidator<Agendamento>
    {
        public AgendamentoValidador()
        {
            RuleFor(x => x.IdColetor).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric("Coletor"));
            RuleFor(x => x.IdItem).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric("Item"));
            RuleFor(x => x.DiaDaSemanaColeta).IsInEnum().WithMessage(MensagensValidador.NotEnum);
            RuleFor(x => x.HoraColeta).GreaterThanOrEqualTo(8).WithMessage("Hora informada para a coleta está fora do horário permitido (08h às 20h).")
                .LessThanOrEqualTo(20).WithMessage("Hora informada para a coleta está fora do horário permitido (08h às 20h).");
            RuleFor(x => x.MinutoColeta).GreaterThanOrEqualTo(0).WithMessage(MensagensValidador.GreaterThanOrEqualToInvalid("Minuto"))
                .LessThanOrEqualTo(59).WithMessage(MensagensValidador.GreaterThanOrEqualToInvalid("Minuto"));
        }
    }
}
