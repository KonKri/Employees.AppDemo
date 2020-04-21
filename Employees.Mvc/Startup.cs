    using System;
using System.IO;
using AutoMapper;
using Employees.Mvc.Extensions;
using Employees.Mvc.Models;
using Employees.Mvc.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Employees.Mvc
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
                    var connectionStringsFile = File.ReadAllText("../connectionStrings.json");
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

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            


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
                app.UseExceptionHandler("/Error/500");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
