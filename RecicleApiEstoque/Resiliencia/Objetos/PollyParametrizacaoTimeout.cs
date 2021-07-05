namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoTimeout<TReturn> : PollyParametrizacaoRetry<TReturn>
    {
        public int Milissegundos { get; init; }
    }
}
