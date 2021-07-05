using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using MediatR;
using MensageriaRabbitMq.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecicleApiBancoLeitura.Setup;
using Repositorio.Contexto;
using Repositorio.Repositorios;
using Repositorio.Repositorios.Base;
using Repositorio.Sincronizacao;
using Servico.Handlers;
using System;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISincronizacaoEvent, SincronizacaoEvent>();

            services.AddScoped<ContextoEntity>();
            services.AddScoped<IItemRepository, ItemRepository>();
            #endregion

            #region Core
            services.AddScoped<IMediatorCustom, MediatorCustom>();
            #endregion

            #region MediatR
            services.AddMediatR(typeof(MediatorCustom).Assembly);
            services.AddMediatR(typeof(ItemHandler).Assembly);
            services.AddMediatR(typeof(BaseRepositoryInjector).Assembly);
            services.AddMediatR(typeof(ApiBancoLeituraInjector).Assembly);
            services.AddMediatR(typeof(Rabbit).Assembly);
            #endregion

            #region Integracao
            services.AddScoped<ApiBancoLeituraInjector>();
            services.AddScoped<IApiBancoLeituraClient, ApiBancoLeituraClient>();
            #endregion

            #region Mapper
            services.AddAutoMapper(typeof(Rabbit).Assembly);
            services.AddAutoMapper(typeof(InjecaoDependenciaConfiguracao).Assembly);
            services.AddAutoMapper(typeof(ItemHandler).Assembly);
            #endregion

            return services;
        }
    }
}
