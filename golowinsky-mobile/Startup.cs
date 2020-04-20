using System.Linq;
using golowinsky_mobile.Contract;
using golowinsky_mobile.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;

namespace golowinsky_mobile
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
            services.AddCors();
            services.AddOptions();
            services.AddMvc();
            services.AddControllers();
            services.Configure<ConfigureOptions>(Configuration);
            services.AddSwaggerDocument(d=> { d.Title = d.Title = "Mobile API"; });
            services.AddTransient<ICarPrc,Repository>();
                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            //app.UseAuthorization();
            app.UseOpenApi(s => s.PostProcess = (document, request) =>
            {
                if (env.IsDevelopment()) return;
                document.Schemes.Clear();
                document.Schemes.Add(NSwag.OpenApiSchema.Https);
            }).UseSwaggerUi3();
            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
        }
    }
}
