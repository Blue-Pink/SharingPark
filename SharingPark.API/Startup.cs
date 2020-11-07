using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SharingPark.API.Controllers;
using SharingPark.BLL;
using SharingPark.DAL;
using SharingPark.IBLL;
using SharingPark.IDAL;

namespace SharingPark.API
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
            services.AddLogging();
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IUserBLL, UserBLL>();
            //services.AddSingleton()
            //services.AddScoped<>()
            services.AddTransient<ILogger, Logger<UserChannelController>>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("1.0.0", new OpenApiInfo()
                {
                    Title = "SharingPark.API",
                    Version = "1.0.0",
                    Description = "SharingPark.API.1.0.0 for ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Blue Pink",
                        Email = "blue_pink_girl@outlook.com",
                        Url = new Uri("https://space.bilibili.com/33854254")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "未知许可证",
                        Url = new Uri("https://space.bilibili.com/33854254")
                    }
                });
                options.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location) ?? string.Empty, "SharingPark.API.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "SharingPark.API"));

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
