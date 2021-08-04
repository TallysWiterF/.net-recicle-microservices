using Polly;
using Resiliencia.Objetos;
using System;
using System.Threading.Tasks;

namespace Resiliencia.Setup
{
    public static class PollyFactoryRetryAndWaitExtensions
    {
        public static async Task<TReturn> CreateWaitAndRetryAsync<TReturn>(
            this IPollyFactory pollyFactory, PollyParametrizacaoRetryAndWait<TReturn> setup)
        {
            var policy = Policy<TReturn>
                        .HandleResult(setup.PollyCondicao)
                        .WaitAndRetryAsync(setup.Tentativas, sleep => TimeSpan.FromMilliseconds(setup.Milissegundos),
                         (result, time, retry, context) => setup.PollyExceptionHandler(result.Result, result.Exception, retry));
            return await Policy
                    .WrapAsync(pollyFactory.CreateFallback(setup.ValorDefault), policy)
                    .ExecuteAsync(async () => await setup.TaskHandler());
        }
    }
}
