using System;
using System.Collections.Generic;
using ApiRestASPNET.Business;
using ApiRestASPNET.Business.Implementation;
using ApiRestASPNET.Model.Context;
using ApiRestASPNET.Repository;
using ApiRestASPNET.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;

namespace ApiRestASPNET
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            services.AddControllers();
			//swagger
			services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API Asp Net Core",
                        Version = "v1",
                        Description = "API RESTful desenvolvida com: Asp Net Core, MySql and Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Kleiton Rufino",
                            Url = new Uri("https://github.com/KleitonRufino"),
                            Email = "kleiton.arufino@gmail.com"
                            
                        },
                        License = new OpenApiLicense { 
                            Name="Codigo Api do GitHub",
                            Url = new Uri("https://github.com/KleitonRufino/ApiRestAspNet")
                        }
                    });
            });
            //Formato resposta json e xml
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
           .AddXmlSerializerFormatters();

            //migrations
            //if (Environment.IsDevelopment()) 
            //{
            //    MigrateDatabase(connection);
            //}

            //versioning
            services.AddApiVersioning();

            //Dependency injection
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImpl>();
            services.AddScoped<IFileBusiness, FileBusinessImpl>();

            //hateoas
           // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Implementação de IUrlHelper para injetar a instância de UrlHelper
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>()
                .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

            //CROSS ORIGIN
            services.AddCors(options => options.AddDefaultPolicy(builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex) 
            {
                Log.Error("Database migrations failed", ex);
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           //if (env.IsDevelopment())
           // {
               app.UseDeveloperExceptionPage();
                app.UseSwagger();
               app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiRestASPNET v1"));
           // }

            app.UseHttpsRedirection();

            app.UseRouting();

            //cross origin depois de httpredirection e userouting e antes de useendpoints
            app.UseCors();
             
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
