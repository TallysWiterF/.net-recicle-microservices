using Polly;
using Polly.Wrap;
using Resiliencia.Objetos;
using System;

namespace Resiliencia.Setup
{
    public static class PollyFactoryRetryAndWaitExtensions
    {
        public static AsyncPolicyWrap<TReturn> CreateWaitAndRetryAsync<TReturn>(
            this PollyFactory pollyFactory, PollyParametrizacaoRetryAndWait<TReturn> setup)
        {
            var policy = Policy<TReturn>
                        .HandleResult(setup.PollyCondicao)
                        .WaitAndRetryAsync(setup.Tentativas, sleep => TimeSpan.FromMilliseconds(setup.Milissegundos),
                         (result, time, retry, context) => setup.PollyHandler(result.Result, result.Exception, retry));
            return Policy.WrapAsync(pollyFactory.CreateFallback(setup.ValorDefault), policy);
        }
    }
}
