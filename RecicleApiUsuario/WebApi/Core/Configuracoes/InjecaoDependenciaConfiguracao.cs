using Aplicacao.Contratos;
using Aplicacao.Handlers;
using Core.Base;
using Crosscuting.Notificacao;
using MediatR;
using MensageriaRabbitMq.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;
using WebApi.Core.Implementacoes;

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
            services.AddScoped<ContextoEntity>();
            #endregion

            #region Core
            services.AddScoped<IMediatorCustom, MediatorCustom>();
            #endregion

            #region MediatR
            services.AddMediatR(typeof(UsuarioHandler).Assembly);
            services.AddMediatR(typeof(MediatorCustom).Assembly);
            services.AddMediatR(typeof(Rabbit).Assembly);
            #endregion

            #region Integracao
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(UsuarioHandler).Assembly);
            services.AddAutoMapper(typeof(InjecaoDependenciaConfiguracao).Assembly);
            #endregion

            #region Apresentacao
            services.AddScoped<IUsuarioRequisicao, UsuarioRequisicao>();
            #endregion

            return services;
        }
    }
}
