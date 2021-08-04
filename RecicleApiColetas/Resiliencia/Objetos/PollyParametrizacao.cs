using System;
using System.Threading.Tasks;

namespace Resiliencia.Objetos
{
    public class PollyParametrizacao<TReturn>
    {
        public Func<TReturn, bool> PollyCondicao { get; set; }
        public Action<TReturn, Exception, int> PollyExceptionHandler { get; set; }
        public Func<Task<TReturn>> TaskHandler { get; set; }
        public TReturn ValorDefault { get; set; }
    }
}
