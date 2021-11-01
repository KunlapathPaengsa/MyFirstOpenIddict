using Autofac;
using FluentValidation.AspNetCore;
using Identity.Api.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api
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
            services.AddOptions();
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            //services.AddApiVersioning();
            //services.RegisterUriServiceHelper();

            //services.AddAutoMapper(CurrentAssembly);
            services.AddMvc().AddFluentValidation();
        }

        /// <summary>
        /// Configure container for autoface.
        /// </summary>
        /// <param name="builder">ContainerBuilder</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterConfiguration<DatabaseSettings>(Configuration, nameof(DatabaseSettings));
            //builder.RegisterConfiguration<PasswordConfigs>(Configuration, nameof(PasswordConfigs));
            //builder.RegisterConfiguration<JwtAppSettings>(Configuration, nameof(JwtAppSettings));
            //builder.RegisterConfiguration<EmailSettings>(Configuration, nameof(EmailSettings));

            //builder.RegisterModule(new AzureTableModule(Configuration));
            //builder.RegisterModule(new EFModule(Configuration));
            //builder.RegisterModule(new RepositoryModule());
            //builder.RegisterModule(new ServiceModule());
            //builder.RegisterModule(new CQRSModule());
            //builder.RegisterModule(new WebLoggerModule(Configuration, AssemblyName));
            builder.RegisterModule(new OpenIddictModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
