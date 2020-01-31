using AutoMapper;
using CopaFilmes.Domain;
using CopaFilmes.Domain.Service;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.Data.Service;
using CopaFilmes.WebApi.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CopaFilmes.WebApi
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
            services.AddControllers();
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddSingleton<RealizarCampeonatoService>();

            services.AddHttpClient<IFilmeRepository, FilmeService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("ApiCopaFilmes").Value);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Copa Filmes", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(option => { option.AllowAnyOrigin(); option.AllowAnyMethod(); option.AllowAnyHeader(); }); ;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Copa Filmes");
                options.RoutePrefix = "api/swagger";
            });
        }
    }
}
