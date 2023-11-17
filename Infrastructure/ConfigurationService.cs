using Application.Common.Interfaces;
using Infrastructure.Common.Services;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IAppDbContextInitializer, AppDbContextInitializer>();
            services.AddScoped<IDateTime, DateTimeService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, AppDbContext>();
            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("CanPurge", policy =>
                {
                    policy.RequireRole("Admin");
                });
            });
            return services;
        }
    }
}
