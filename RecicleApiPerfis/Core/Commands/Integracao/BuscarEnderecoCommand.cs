using Core.Base;

namespace Core.Commands.Integracao
{
    public class BuscarEnderecoCommand<TReturn> : BaseCommand<TReturn>
    {
        public string Cep { get; set; }

        public BuscarEnderecoCommand(string cep)
        {
            Cep = cep;
        }
    }
}
