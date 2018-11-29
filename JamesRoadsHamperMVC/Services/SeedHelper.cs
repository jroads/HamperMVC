using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JamesRoadsHamperMVC.Services
{
    public static class SeedHelper
    {
        public static async Task Seed(IServiceProvider provider)
        {
            //set up the scope of our services that used 
            //our DI container
            var scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //......sample data......
                //add Admin role
                if (await roleManager.FindByNameAsync("Administrator") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Administrator"));
                }
                //add default admin
                if (await userManager.FindByNameAsync("admin1") == null)
                {
                    IdentityUser admin = new IdentityUser("admin1");
                    admin.Email = "admin1@yahoo.com";
                    await userManager.CreateAsync(admin, "Apple#333");//add user to Users tabel
                    await userManager.AddToRoleAsync(admin, "Administrator"); //add admin1 to role Admin
                }
                //add Customer role
                if (await roleManager.FindByNameAsync("Customer") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                }

            }
        }
    }
}
