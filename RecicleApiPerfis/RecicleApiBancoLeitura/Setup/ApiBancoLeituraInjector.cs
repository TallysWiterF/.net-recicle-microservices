namespace RecicleApiBancoLeitura.Setup
{
    public class ApiBancoLeituraInjector
    {
        internal readonly IApiBancoLeituraClient Client;

        public ApiBancoLeituraInjector(IApiBancoLeituraClient client)
        {
            Client = client;
        }
    }
}
