using Autofac;
using Autofac.Extensions.DependencyInjection;
using MensageriaRabbitMq.Contratos.Consumidores;
using MensageriaRabbitMq.Handlers;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Contratos;
using Microsoft.AspNetCore.Builder;
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
            services.AddScoped<IAgendamentoMessageHandler, AgendamentoConsumerMessageHandler>();
            services.AddScoped<IColetorMessageHandler, ColetorConsumerMessageHandler>();
            services.AddScoped<IDistribuidorMessageHandler, DistribuidorConsumerMessageHandler>();
            services.AddScoped<IItemMessageHandler, ItemConsumerMessageHandler>();
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
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(_services);
            var lifeScope = containerBuilder.Build().BeginLifetimeScope();
            lifeScope.Resolve<IAgendamentoMessageHandler>().RegisterAll();
            lifeScope.Resolve<IColetorMessageHandler>().RegisterAll();
            lifeScope.Resolve<IDistribuidorMessageHandler>().RegisterAll();
            lifeScope.Resolve<IItemMessageHandler>().RegisterAll();
            return Task.CompletedTask;
        }
    }
}
