﻿using System;
using System.IO;
using System.IO.Compression;
using IFExperiment.Api.Controllers;
using IFExperiment.Domain.ExperimentContext.Commands.Handlers;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using IFExperiment.Infra.Repositorio;
using IFExperiment.Infra.Transacao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace IFExperiment.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

           // services.AddMvc(config => { config.Filters.Add(new ValidateModelAttribute()); });

            // Configura o modo de compressão
            services.Configure<GzipCompressionProviderOptions>(
                options => options.Level = CompressionLevel.Optimal
            );
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                //options.EnableForHttps = true; habilitar essa configuração no caso de api esta usando https
            });

            services.AddMvc(config => { config.Filters.Add(new ValidateModelAttribute()); }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddCors();

            #region Injeção de Dependencia
            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<IExperimentoRepository, ExperimentoRepository>();
            services.AddTransient<ITratamentoRepository, TratamentoRepository>();
            services.AddTransient<TratamentoHandler, TratamentoHandler>();
            services.AddTransient<ExperimentoHandler, ExperimentoHandler>();
            services.AddTransient<TratamentoOutputHandler, TratamentoOutputHandler>();
            services.AddTransient<ExperimentoOutputHandler, ExperimentoOutputHandler>();
            #endregion Injeção de Dependencia

            

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                    {
                        Title = "Experimento", Version = "v1",
                        Contact = new Contact
                        {
                            Name="Marcel Silva / Matheus Neves",
                            Url = String.Empty,
                            Email = "marcel.msmelo@gmail.com;matheusnevesdecarvalho@gmail.com"
                        }
                    }
                );

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
                x.IncludeXmlComments(caminhoXmlDoc);
            });

        }

     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
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
