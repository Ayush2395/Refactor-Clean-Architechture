using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Generation.Processors.Security;
using NSwag;
using WebUI.Services;
using WebUI.Filters;
using FluentValidation.AspNetCore;

namespace WebUI
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddWebUiLayer(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHealthChecks();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews(opt => opt.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
            services.AddRazorPages();

            services.Configure<ApiBehaviorOptions>(options =>
           options.SuppressModelStateInvalidFilter = true);

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Learning CA API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            return services;
        }
    }
}
