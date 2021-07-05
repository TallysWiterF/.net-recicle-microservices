using Dominio.Validadores;
using Dominio.ValuesTypes;
using System;

namespace Dominio.Entidades
{
    public class Agendamento : Entity
    {
        public Guid IdItem { get; private set; }
        public Guid IdColetor { get; private set; }
        public int HoraColeta { get; private set; }
        public int MinutoColeta { get; private set; }
        public EnumDiasDaSemana DiaDaSemanaColeta { get; private set; }
        public bool Ativo { get; private set; }
        public Agendamento()
        {

        }
        public override void Validar()
        {
            Validar(new AgendamentoValidador(), this);
        }

        public Agendamento DefinirItem(Guid idItem)
        {
            IdItem = idItem;
            Validar();
            return this;
        }

        public Agendamento DefinirColetor(Guid idColetor)
        {
            IdColetor = idColetor;
            Validar();
            return this;
        }

        public Agendamento DefinirHorario(EnumDiasDaSemana diaDaSemana, int hora, int minuto)
        {
            DiaDaSemanaColeta = diaDaSemana;
            HoraColeta = hora;
            MinutoColeta = minuto;
            Validar();
            return this;
        }

        public Agendamento Desativar()
        {
            Ativo = false;
            Validar();
            return this;
        }

        public Agendamento Ativar()
        {
            Ativo = true;
            Validar();
            return this;
        }
    }
}
