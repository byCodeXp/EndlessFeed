using System;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace API;

public class Seed
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<User> _userManager;

    public Seed(RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Invoke()
    {
        Task.Run(async () =>
        {
            if (!await _roleManager.RoleExistsAsync(Env.Roles.USER))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Env.Roles.USER));
            }

            if (!await _roleManager.RoleExistsAsync(Env.Roles.ADMIN))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Env.Roles.ADMIN));
            }

            var user = new User
            {
                Name = "John",
                Surname = "Doe",
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            string defaultPassword = "Qwerty-1"; 
                
            IdentityResult createResult = await _userManager.CreateAsync(user, defaultPassword);

            if (createResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Env.Roles.ADMIN);
            }
        }).Wait();
    }
}