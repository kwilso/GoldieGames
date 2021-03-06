﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GoldieGames.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Comp229!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
           
            UserManager<IdentityUser> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<IdentityUser>>();


            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .GetRequiredService<RoleManager<IdentityRole>>();
            if (user == null)
            {
 
                    user = new IdentityUser("Admin");
                    await userManager.CreateAsync(user, adminPassword);

            }


        }
    }
}
