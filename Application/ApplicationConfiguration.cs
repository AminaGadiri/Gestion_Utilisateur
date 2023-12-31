using Application.AutoMapper;
using Domain.Interfaces;
using Infrastructure.Health;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Offers.Queries;
using Infrastructure.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionApplication(this IServiceCollection services)
        {
            
            // versioning
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            }
             );

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // mediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(GetRoleQueryHandler).Assembly
            //,typeof(GetRoleQueryRequest).Assembly,
            //typeof(GetUtilisateurQueryHandler).Assembly,
            //typeof(GetUtilisateurQueryRequest).Assembly
            ));
            // auth 2
            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Gestion_Utilisateur")
                .AddEntityFrameworkStores<BiblioAuthDBContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            

            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddHealthChecks()
                    .AddCheck<ApiHealthCheck>("ExterneApiChecks", tags: new string[] { "ExterneApiChecks" })
                    .AddCheck<UserApiCheck>("InterneApiChecks", tags: new string[] { "InterneApiChecks" })
                    .AddCheck<SqlHealthCheck>("custom-sql", HealthStatus.Unhealthy);
                    
                    
            return services;
        }
    }

}
