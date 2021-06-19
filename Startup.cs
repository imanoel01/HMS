using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper;
using HMS.Data;
using HMS.Helpers;
using HMS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace HMS
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
            services.AddDbContext<HMSDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HMSConnection")));
            // services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                var resolver = s.SerializerSettings.ContractResolver;
                if (resolver == null)
                {
                    (resolver as DefaultContractResolver).NamingStrategy = null;
                }
            });
            //   var appSettings=  services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // services.AddScoped<IChurchRepo,MockProgrammeRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                        {
                            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(x =>
                        {
                            x.RequireHttpsMetadata = false;
                            x.SaveToken = true;
                            x.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(key),
                                ValidateIssuer = false,
                                ValidateAudience = false,

                                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                                ClockSkew = TimeSpan.Zero
                            };
                        });

            services.AddScoped<IHMSRepo, SQLHMSRepo>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseApiResponseAndExceptionWrapper();

            app.UseRouting();

            app.UseCors(us => us.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => 
                { 
                    await context.Response.WriteAsync("Welcome to HMS API.");
                
                });
            });
        }
    }
}
