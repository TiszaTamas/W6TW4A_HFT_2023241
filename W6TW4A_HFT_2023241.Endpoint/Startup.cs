using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository;
using W6TW4A_HFT_2023241.Endpoint;
using W6TW4A_HFT_2023241.Repository.Database;
using W6TW4A_HFT_2023241.Repository.Interfaces;
using W6TW4A_HFT_2023241.Repository.ModelRepositories;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Logic.LogicModels;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace W6TW4A_HFT_2023241.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<AdventurerGuildDbContext>();

            services.AddTransient<IRepository<Monster>, MonsterRepository>();
            services.AddTransient<IRepository<Mark>, MarkRepository>();
            services.AddTransient<IRepository<Adventurer>, AdventurerRepository>();
            services.AddTransient<IRepository<Quest>, QuestRepository>();

            services.AddTransient<IMonsterLogic, MonsterLogic>();
            services.AddTransient<IMarkLogic, MarkLogic>();
            services.AddTransient<IAdventurerLogic, AdventurerLogic>();
            services.AddTransient<IQuestLogic, QuestLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "W6TW4A_HFT_2023241.Endpoint.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "W6TW4A_HFT_2023241.Endpoint.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
