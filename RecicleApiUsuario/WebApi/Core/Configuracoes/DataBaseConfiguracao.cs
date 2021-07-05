using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorio.Contexto;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Core.Configuracoes
{
    public static class DataBaseConfiguracao
    {
        public static IServiceCollection AddConfiguracaoEntity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextoEntity>(options => options
                                                 .EnableSensitiveDataLogging().EnableDetailedErrors()
                                                 .UseSqlServer(configuration.GetConnectionString("SqlServer"),
                                                                b => b.MigrationsAssembly("Repositorio"))
                                                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddHostedService(x => new AplicarMigracoesDataBase(services));
            return services;
        }
    }

    public class AplicarMigracoesDataBase : BackgroundService
    {
        private readonly IServiceCollection _services;
        public AplicarMigracoesDataBase(IServiceCollection services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(_services);
            var scope = containerBuilder.Build().BeginLifetimeScope();
            await scope.Resolve<ContextoEntity>().Database.MigrateAsync();
        }
    }
}
