using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Ista.Api.Rest.AutoMapper;
using Ista.Api.Rest.AutoMapper.CardsList;
using Ista.Api.Rest.AutoMapper.GetCardListById;
using Ista.Api.Rest.AutoMapper.GetCardListByUser;

namespace Ista.Api.Rest
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ista.Api.Rest", Version = "v1" });
            });

            services.AddAutoMapper(typeof(BasicAutoMapper));
            services.AddAutoMapper(typeof(CardListAutoMapper));
             services.AddAutoMapper(typeof(GetCardListByIdAutoMapper));
            services.AddAutoMapper(typeof(GetCardListByUserAutoMapper));

            Ista.Setup.Bootstrapper.ConfigureServices(services);


            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.CardsList.CardListRequestModel, Ista.Application.Cards.Commands.CardsList.Create.CreateCardListRequest>();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ista.Api.Rest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
