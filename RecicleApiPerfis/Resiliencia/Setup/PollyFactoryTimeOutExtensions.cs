using Polly;
using Polly.Timeout;
using Polly.Wrap;

namespace Resiliencia.Setup
{
    public static class PollyFactoryTimeOutExtensions
    {
        public static AsyncPolicyWrap<TReturn> CreateTimeoutAsync<TReturn>(this PollyFactory pollyFactory, TReturn defaultValue, int tempo = 30)
        {
            var policy = Policy.TimeoutAsync<TReturn>(tempo, TimeoutStrategy.Optimistic);
            return Policy.WrapAsync(pollyFactory.CreateFallback(defaultValue), policy);
        }
    }
}
