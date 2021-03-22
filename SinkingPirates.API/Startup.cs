using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SinkingPirates.API.DataAccess;
using SinkingPirates.API.DataAccess.Student;
using SinkingPirates.API.Manager;
using SinkingPirates.API.Manager.Student;
using SinkingPirates.API.Manager.TokenService;
using SinkingPirates.API.Manager.User;

namespace SinkingPirates.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            IConfigurationBuilder builder = new ConfigurationBuilder()
.SetBasePath(env.ContentRootPath)
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IStudentManager, StudentManager>();
            services.AddTransient<IStudentDataAccess, StudentDataAccess>();
            services.AddTransient<IEntryDataAccess, EntryDataAccess>();
            services.AddTransient<IUserRoleDataAccess, UserRoleDataAccess>();
            services.AddTransient<IUserDataAccess, UserDataAccess>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
