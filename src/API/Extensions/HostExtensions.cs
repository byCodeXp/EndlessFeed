using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Extensions
{
    public static class HostExtensions
    {
        public static IHost Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole<Guid>>>();
            new Seed(roleManager).Invoke();
            
            return host;
        }
    }
}