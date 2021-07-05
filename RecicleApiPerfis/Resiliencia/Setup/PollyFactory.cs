using Polly;
using Polly.Fallback;
using System;

namespace Resiliencia.Setup
{
    public class PollyFactory
    {
        public AsyncFallbackPolicy<TReturn> CreateFallback<TReturn>(TReturn defaultValue) =>
            Policy<TReturn>.Handle<Exception>().FallbackAsync(defaultValue);
    }
}
