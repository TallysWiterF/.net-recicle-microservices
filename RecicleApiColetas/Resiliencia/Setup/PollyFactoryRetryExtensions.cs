using Polly;
using Polly.Wrap;
using Resiliencia.Objetos;

namespace Resiliencia.Setup
{
    public static class PollyFactoryRetryExtensions
    {
        public static AsyncPolicyWrap<TReturn> CreateRetryAsync<TReturn>(
            this PollyFactory pollyFactory, PollyParametrizacaoRetryAndWait<TReturn> setup)
        {
            var policy = Policy<TReturn>
                        .HandleResult(setup.PollyCondicao)
                        .RetryAsync(setup.Tentativas, (result, retry) 
                        => setup.PollyHandler(result.Result, result.Exception, retry));
            return Policy.WrapAsync(pollyFactory.CreateFallback(setup.ValorDefault), policy);
        }
    }
}
