using System.IO;
using System.Text;
using AutoMapper;
using Employees.WebApi.Extensions;
using Employees.WebApi.Models;
using Employees.WebApi.Repositories;
using Employees.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Employees.WebApi
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
            //Add Db Context...
            services.AddDbContext<EmployeesDbContext>(options =>
            {
                //Try parse file into json and get value from it.
                try
                {
                    var connectionStringsFile = File.ReadAllText("./connectionStrings.json");
                    var connectionStrings = JObject.Parse(connectionStringsFile);
                    options.UseSqlServer(connectionStrings.Value<string>("employeesEvoDb"));
                }
                catch (IOException exc)
                {
                    throw exc;
                }
            });

            //Add AutoMapper...
            services.AddAutoMapper(typeof(DefaultMappingProfile));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Add Swagger and its configuration...
            services.ConfigureSwagger();

            //Add Cors...
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            //IoC
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees.WebApi API"));
        }
    }
}
