using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.User;
using Repositorio.Contexto;
using System;

namespace WebApi.Core.Configuracoes
{
    public static class AutenticacaoConfiguracao
    {
        public static IServiceCollection AddAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAspNetUserConfiguration();
            services.AddCustomIdentity<Usuario>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ContextoEntity>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<IdentityMensagensBR>();
            services.AddJwtConfiguration(configuration, "AppSettings");
            return services;
        }
    }
}
