using System;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Extensions;

public static class HostExtensions
{
    public static IHost Seed(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
            
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetService<RoleManager<IdentityRole<Guid>>>();
        UserManager<User> userManager = serviceProvider.GetService<UserManager<User>>();
            
        new Seed(roleManager, userManager).Invoke();
            
        return host;
    }
}