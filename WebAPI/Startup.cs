using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.InterfacesBll;
using Commun.Constant;
using DAL.Repository;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.generic;

namespace WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: Constant.AllowFront,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:58517")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            
            services.AddControllers();
            services.AddScoped<CustomExceptionFilter>();
            services.AddScoped<IRouletteBll, RouletteBll>();
            services.AddScoped<IRouletteDAL, RouletteDAL>();
            services.AddScoped<IStartRouletteBll, StartRouletteBll>();
            services.AddScoped<IStartRouletteDAL, StartRouletteDAL>();
            services.AddScoped<IBetRouletteBll, BetRouletteBll>();
            services.AddScoped<IBetRouletteDAL, BetRouletteDAL>();
            services.AddScoped<IUserBll, UserBll>();
            services.AddScoped<IUserDAL, UserDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
