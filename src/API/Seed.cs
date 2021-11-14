using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API
{
    public class Seed
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public Seed(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
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
            }).Wait();
            
        }
    }
}