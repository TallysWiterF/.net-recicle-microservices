namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoTimeout<TReturn> : PollyParametrizacaoRetry<TReturn>
    {
        public int Segundos { get; init; }
    }
}
