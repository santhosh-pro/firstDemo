using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using firstDemo.Common.Abstractions;
using firstDemo.Common.Helpers.Filters;
using firstDemo.Common.Helpers.Options;
using firstDemo.Common.Helpers.Services;
using firstDemo.Persistence;

namespace firstDemo.Common.Helpers.Installers.Mvc
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options => 
            { 
                options.Filters.Add(typeof(ExceptionFilter));
                options.Filters.Add(typeof(ValidateModelStateAttribute));
                options.Filters.Add(typeof(UserActivityLogger));
                options.Filters.Add(typeof(ValidationFilter));
            })
                .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Jwt security token provider
            var jwtSettings = new JwtOptions();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,

                        ValidateLifetime = jwtSettings.ShouldValidateLifeTime,
                        ValidateIssuerSigningKey = true,
                        
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });
            
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}