
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Approovia.Core.Interface.Repositories;
using Approovia.Infrastructure.Configurations;
using Approovia.Infrastructure.Filters;
using Approovia.Infrastructure.Configurations.Interface;
using Approovia.Infrastructure.Repository;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Approovia.Api
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
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddControllers(config =>
            {
                config.Filters.Add<GlobalExceptionFilter>();
            })
                 .AddJsonOptions(opt =>
                 {
                     opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                     opt.JsonSerializerOptions.IgnoreNullValues = true;
                     opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                 });
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddCors(o => o.AddPolicy("AllowOrigins", builder =>
            {
                builder.WithOrigins("http://localhost:5500")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Approovia.Api", Version = "v1" });
            
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Approovia.Api v1"));
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowOrigins");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
