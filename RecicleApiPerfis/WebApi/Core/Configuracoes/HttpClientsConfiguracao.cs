using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApi.Core.Configuracoes
{
    public static class HttpClientsConfiguracao
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddHttpClient("ApiBancoLeitura", (provider, http) =>
            {
                http.BaseAddress = new Uri(configuration.GetSection("ApiBancoLeitura").Value);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken(provider));

            })
            .ConfigurePrimaryHttpMessageHandler(() => CriarLiberacaoSSL());

            services.AddHttpClient("ApiViaCep", http =>
            {
                http.BaseAddress = new Uri(configuration.GetSection("ApiViaCep").Value);
            });
            
            return services;
        }

        private static string GetToken(IServiceProvider provider)
        {
            var headerAutorizacao = provider.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.Headers[HeaderNames.Authorization];
            return headerAutorizacao.ToString().Replace("Bearer ", "");
        }

        private static HttpClientHandler CriarLiberacaoSSL()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) 
                => { return true; };
            return clientHandler;
        }
    }
}
