using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;

namespace WebApi.Core.Configuracoes
{
    public static class DataBaseConfiguracao
    {
        public static IServiceCollection AddConfiguracaoEntity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(x => new ContextMongo(configuration.GetConnectionString("MongoDB"), "RecicleApiBancoLeitura"));
            return services;
        }
    }
}
