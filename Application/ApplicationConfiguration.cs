using Application.AutoMapper;
using Application.Offers.Queries.Role;
using Domain.Interfaces;
using Infrastructure.Health;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(GetRoleQueryHandler).Assembly
            //,typeof(GetRoleQueryRequest).Assembly,
            //typeof(GetUtilisateurQueryHandler).Assembly,
            //typeof(GetUtilisateurQueryRequest).Assembly
            ));
            

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddHealthChecks()
                    .AddCheck<ApiHealthCheck>("ExterneApiChecks", tags: new string[] { "ExterneApiChecks" })
                    .AddCheck<UserApiCheck>("InterneApiChecks", tags: new string[] { "InterneApiChecks" });
            return services;
        }
    }

}
