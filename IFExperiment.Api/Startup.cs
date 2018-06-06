using IFExperiment.Domain.ExperimentContext.Handlers;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using IFExperiment.Infra.Repositorio;
using IFExperiment.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IFExperiment.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddResponseCompression();

            #region Injeção de Dependencia
            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<IExperimentoRepository, ExperimentoRepository>();
            services.AddTransient<ITratamentoRepository, TratamentoRepository>();
            services.AddTransient<TratamentoHandler, TratamentoHandler>();
            services.AddTransient<ExperimentoHandler, ExperimentoHandler>();
            services.AddTransient<TratamentoOutputHandler, TratamentoOutputHandler>();


            #endregion Injeção de Dependencia



            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Experimento", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Experimentos - V1");
            });

        }
    }
}
