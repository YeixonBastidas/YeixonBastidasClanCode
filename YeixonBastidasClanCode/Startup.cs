using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Repository;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YeixonBastidasClanCode
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.AddDbContext<MyDatabaseContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("Data Source=DBRoultte.db")));

            services.Configure<MvcOptions>(options => { options.Filters.Add(new CorsAuthorizationFilterFactory("AllowFront")); });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFront", builder => builder.WithOrigins(
                    "http://localhost:4200",
                    "http://localhost:80",
                    "http://0.0.0.0:80",
                    "http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader());
            });

            services.AddScoped<IRouletteBll, RouletteBll>();
            services.AddScoped<IRouletteDAL, RouletteDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
