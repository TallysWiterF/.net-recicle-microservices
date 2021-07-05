using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Core.Configuracoes
{
    public static class MensageriaConfiguracao
    {
        public static IServiceCollection AddMensageria(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbit, Rabbit>(x => new Rabbit(configuration.GetConnectionString("RabbitMq")));
            services.AddScoped<MensageriaInjector>();
            return services;
        }
    }
}
