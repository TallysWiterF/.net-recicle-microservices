namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoRetryAndWait<TReturn> : PollyParametrizacaoRetry<TReturn>
    {
        public int Milissegundos { get; set; }

        public static PollyParametrizacaoRetryAndWait<TReturn> SetupDefault()
        {
            return new PollyParametrizacaoRetryAndWait<TReturn>
            {
                Milissegundos = 2000,
                PollyCondicao = x => x == null,
                Tentativas = 3,
            };
        }
    }
}
