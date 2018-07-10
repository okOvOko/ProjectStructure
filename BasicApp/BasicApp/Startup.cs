using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BasicApp.DataAccess;
using BasicApp.DataAccess.Model;
using BasicApp.Services.Abstractions;
using BasicApp.Services.Handlers;
using BasicApp.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BasicApp
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
            services.AddMvc();

            services.AddOptions();

            services.Configure<DatabaseConfiguration>(Configuration.GetSection("DatabaseConfiguration"));

            services.AddDbContext<ToDoDbContext>();

            services.AddTransient<ICommandHandlerFactory, CommandHandlerFactory>();
            services.AddTransient<IQueryHandlerFactory, ToDoQueryHandler>();
            services.AddTransient<ICommandProcessor, ToDoCommandProcessor>();
            services.AddTransient<IQueryProcessor, ToDoQueryProcessor>();

            var mapper = MapperConfiguration().CreateMapper();
            services.AddScoped(_ => mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Label, Services.DTOs.Label>();
                cfg.CreateMap<Services.DTOs.Label, Label>()
                    .ForMember(l => l.IteamLabels, opt => opt.Ignore());


                cfg.CreateMap<Item, Services.DTOs.Item>()
                    .ForMember(i => i.Labels, opt => opt.MapFrom(i => i.IteamLabels.Select(il => il.Label)));
                cfg.CreateMap<Services.DTOs.Item, Item>()
                    .ForMember(i => i.IteamLabels, opt => opt.Ignore())
                    .ForMember(i => i.List, opt => opt.Ignore())
                    .ForMember(i => i.ListId, opt => opt.Ignore());

                cfg.CreateMap<List, Services.DTOs.List>();
                cfg.CreateMap<Services.DTOs.List, List>();
            });

            return config;
        }
    }
}
