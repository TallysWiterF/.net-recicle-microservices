using System;

namespace Resiliencia.Objetos
{
    public class PollyParametrizacao<TReturn>
    {
        public Func<TReturn, bool> PollyCondicao { get; init; }
        public Action<TReturn, Exception, int> PollyHandler { get; init; }
        public TReturn ValorDefault { get; init; }
    }
}
