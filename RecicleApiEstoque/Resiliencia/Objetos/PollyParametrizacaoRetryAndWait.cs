namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoRetryAndWait<TReturn> : PollyParametrizacaoRetry<TReturn>
    {
        public int Milissegundos { get; init; }
    }
}
