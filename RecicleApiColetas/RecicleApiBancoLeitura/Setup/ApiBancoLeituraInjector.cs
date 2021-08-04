using Crosscuting.Notificacao;

namespace RecicleApiBancoLeitura.Setup
{
    public class ApiBancoLeituraInjector
    {
        internal readonly IApiBancoLeituraClient Client;
        internal readonly INotificador Notificador;

        public ApiBancoLeituraInjector(IApiBancoLeituraClient client, 
            INotificador notificador)
        {
            Client = client;
            Notificador = notificador;
        }
    }
}
