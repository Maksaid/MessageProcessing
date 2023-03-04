using System.Security.Claims;
using MessageProcessingService.Presentation.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MessageProcessingService.Presentation.Extensions;
public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddCookiesAuthentication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;

                // Where to redirect browser if there is no active session
                options.LoginPath = "/api/Authentication/error";

                // Where to redirect browser if there ForbidResult acquired.
                options.AccessDeniedPath = "/api/Authentication/error";
            });

        return serviceCollection;
    }

    internal static IServiceCollection AddRoles(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            options.AddPolicy(PolicyName.EmployeePolicy, policyBuilder =>
            {
                string[] allowedRoles = { "employee", "admin" };
                policyBuilder
                    .RequireClaim(ClaimTypes.Role, allowedRoles)
                    .Build();
            });
            options.AddPolicy(PolicyName.ManagerPolicy, policyBuilder =>
            {
                string[] allowedRoles = { "manager", "admin" };
                policyBuilder
                    .RequireClaim(ClaimTypes.Role, allowedRoles)
                    .Build();
            });
            options.AddPolicy(PolicyName.AdminPolicy, policyBuilder =>
            {
                string allowedRole = "admin";
                policyBuilder.RequireClaim(ClaimTypes.Role, allowedRole)
                    .Build();
            });
        });
    }
}