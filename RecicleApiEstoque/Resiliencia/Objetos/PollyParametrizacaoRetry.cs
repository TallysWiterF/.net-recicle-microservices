namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoRetry<TReturn> : PollyParametrizacao<TReturn>
    {
        public int Tentativas { get; set; }
    }
}
