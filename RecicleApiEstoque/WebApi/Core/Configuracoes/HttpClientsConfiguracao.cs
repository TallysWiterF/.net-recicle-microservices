using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace WebApi.Core.Configuracoes
{
    public static class HttpClientsConfiguracao
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("ApiBancoLeitura", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("ApiBancoLeitura").Value);
            })
            .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
            .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30))); ;
            return services;
        }
    }
}
