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
using Resiliencia.Setup;
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
            services.AddScoped<IPollyFactory, PollyFactory>();
            #endregion

            #region Repositorio
            services.AddScoped<BaseRepositoryInjector>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISincronizacaoEvent, SincronizacaoEvent>();

            services.AddScoped<ContextoEntity>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            #endregion

            #region Core
            services.AddScoped<IMediatorCustom, MediatorCustom>();
            #endregion

            #region MediatR
            services.AddMediatR(typeof(BaseRepositoryInjector).Assembly);
            services.AddMediatR(typeof(AgendamentoHandler).Assembly);
            services.AddMediatR(typeof(ApiBancoLeituraInjector).Assembly);
            services.AddMediatR(typeof(Rabbit).Assembly);
            #endregion

            #region Integracao
            services.AddScoped<IApiBancoLeituraClient, ApiBancoLeituraClient>();
            services.AddScoped<ApiBancoLeituraInjector>();
            #endregion

            #region Mapper
            services.AddAutoMapper(typeof(Rabbit).Assembly);
            services.AddAutoMapper(typeof(AgendamentoHandler).Assembly);
            services.AddAutoMapper(typeof(InjecaoDependenciaConfiguracao).Assembly);
            #endregion


            return services;
        }
    }
}
