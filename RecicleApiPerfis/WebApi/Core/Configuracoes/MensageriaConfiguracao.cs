using Autofac;
using Autofac.Extensions.DependencyInjection;
using MensageriaRabbitMq.Contratos;
using MensageriaRabbitMq.Handler.Consumidores;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Core.Configuracoes
{
    public static class MensageriaConfiguracao
    {
        public static IServiceCollection AddMensageria(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbit, Rabbit>(x => new Rabbit(configuration.GetConnectionString("RabbitMq")));
            services.AddScoped<MensageriaInjector>();
            services.AddScoped<IUsuarioConsumerMessageHandler, UsuarioConsumerMessageHandler>();
            services.AddHostedService(x => new InicializadoresRegisterHost(services));
            return services;
        }
    }

    public class InicializadoresRegisterHost : BackgroundService
    {
        private readonly IServiceCollection _services;
        public InicializadoresRegisterHost(IServiceCollection services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(_services);
            var scope = containerBuilder.Build().BeginLifetimeScope();
            await scope.Resolve<IUsuarioConsumerMessageHandler>().RegisterAll();
        }
    }
}
