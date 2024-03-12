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
using Microsoft.OpenApi.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;
using System.Text.Json.Serialization;
using Models;

namespace WebApi
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
            services.AddDbContext<PawpersDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("pawpers")));
            services.AddDbContext<PawpersDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("pawpers")));
            services.AddScoped<IFavoriteBL, FavoriteBL>();
            services.AddScoped<IProfileBL, ProfileBL>();
            services.AddScoped<IReplyBL, ReplyBL>();
            services.AddScoped<ITopicBL, TopicBL>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));


            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            services.AddDbContext<PawpersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("pawpers")));

            
            services.AddCors(
                (builder) => {
                    builder.AddDefaultPolicy((policy) => {
                        policy.WithOrigins("http://pawpers-angular.azurewebsites.net", "https://pawpers-angular.azurewebsites.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                }
            );   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
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
