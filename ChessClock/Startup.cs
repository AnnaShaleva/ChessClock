using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ChessClock.BLL.Configuration;
using ChessClock.DAL.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using ChessClock.DAL;
using Microsoft.Extensions.DependencyInjection;
using ChessClock.Configuration;

namespace ChessClock
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
            services.AddMapper();

            services.AddDbContext<PostgresContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));

            services.AddBLL();
            services.AddDAL();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Chess Clock API",
                    Description = "ASP.NET Core Web API for Chess Clock",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Anna Shaleva", Email = "shaleva.ann@gmail.com" }
                });
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seven Game API v1");
            });
        }
    }
}
