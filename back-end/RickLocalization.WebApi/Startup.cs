using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RickLocalization.Domain;
using RickLocalization.Repository;
using RickLocalization.Service;

namespace RickLocalization.WebAPI
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
            services.AddTransient<IRickRepository, RickRepository>();
            services.AddTransient<IRickService, RickService>();
            services.AddTransient<IViagemRepository, ViagemRepository>();
            services.AddTransient<IViagemService, ViagemService>();

            services.AddDbContext<AppDbContext>(
               options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddControllers();

            services.AddControllers()
                       .AddNewtonsoftJson(x =>
                       {
                           x.SerializerSettings.ReferenceLoopHandling
                           = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                       });
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                       .AllowAnyMethod()
                            .AllowAnyHeader()
                                .SetIsOriginAllowed((host) => true)
                                    .AllowCredentials());
            });

            services.AddCors();
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

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
