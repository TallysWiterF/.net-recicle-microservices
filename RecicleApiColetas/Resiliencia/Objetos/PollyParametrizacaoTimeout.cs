namespace Resiliencia.Objetos
{
    public class PollyParametrizacaoTimeout<TReturn> : PollyParametrizacao<TReturn>
    {
        public int Segundos { get; set; }
    }
}
