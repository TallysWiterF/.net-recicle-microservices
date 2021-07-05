using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using MediatR;
using MensageriaRabbitMq.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Repositorios;
using Repositorio.Repositorios.Base;
using Servico.Handlers;

namespace WebApi.Core.Configuracoes
{
    public static class InjecaoDependenciaConfiguracao
    {
        public static IServiceCollection AddInjecaoDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            #region Crosscuting
            services.AddScoped<INotificador, Notificador>();
            #endregion

            #region Repositorio
            services.AddScoped<BaseRepositoryInjector>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IColetorRepository, ColetorRepository>();
            services.AddScoped<IDistribuidorRepository, DistribuidorRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            #endregion

            #region Core
            services.AddScoped<IMediatorCustom, MediatorCustom>();
            #endregion

            #region Servico
            services.AddScoped<HandlerInjector>();
            #endregion

            #region MediatR
            services.AddAutoMapper(typeof(InjecaoDependenciaConfiguracao).Assembly);
            services.AddMediatR(typeof(BaseRepositoryInjector).Assembly);
            services.AddMediatR(typeof(HandlerInjector).Assembly);
            services.AddMediatR(typeof(Rabbit).Assembly);
            #endregion

            #region Integracao
            #endregion

            return services;
        }
    }
}
