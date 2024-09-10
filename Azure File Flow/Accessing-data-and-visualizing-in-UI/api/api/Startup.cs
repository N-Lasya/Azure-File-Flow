using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Database6.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Database6
{


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDBSettings"));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var mongoDBSettings = sp.GetRequiredService <IOptions<MongoDBSettings>>().Value;
                return new MongoClient(mongoDBSettings.ConnectionString);
            });
            services.AddScoped<EmployeeContext>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("6.5.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Database6", Version = "6.0" } );
            
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });
        }
       


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
           
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/6.5.0/swagger.json", "Database6 6.0");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}