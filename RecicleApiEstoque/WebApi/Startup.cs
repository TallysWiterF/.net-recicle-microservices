using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Core.Configuracoes;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguracaoEntity(Configuration);
            services.AddJsonCofig();
            services.AddCorsCustom();
            services.AddRouting(x => { x.LowercaseUrls = true; x.LowercaseQueryStrings = true; });
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Estoque", Description = "Direcionada para o gerenciamento de Itens dos Distribuidores", Version = "v1" }));
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddInjecaoDependencias(Configuration);
            services.AddHttpClients(Configuration);
            services.AddAutenticacao(Configuration);
            services.AddMensageria(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Estoque V1"));
            app.UseMiddleware<ExceptionMiddlware>();
            app.UseCors("CorsOptions");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
