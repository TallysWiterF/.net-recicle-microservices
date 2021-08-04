using Polly;
using Resiliencia.Objetos;
using System.Threading.Tasks;

namespace Resiliencia.Setup
{
    public static class PollyFactoryRetryExtensions
    {
        public static async Task<TReturn> CreateRetryAsync<TReturn>(
            this IPollyFactory pollyFactory, PollyParametrizacaoRetry<TReturn> setup)
        {
            var policy = Policy<TReturn>
                        .HandleResult(setup.PollyCondicao)
                        .RetryAsync(setup.Tentativas, (result, retry)
                        => setup.PollyExceptionHandler(result.Result, result.Exception, retry));

            return await Policy
                    .WrapAsync(pollyFactory.CreateFallback(setup.ValorDefault), policy)
                    .ExecuteAsync(async () => await setup.TaskHandler());
        }
    }
}
