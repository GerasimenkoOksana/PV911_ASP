﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebUserAjax.Data.Entities;

namespace WebUserAjax
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ProjectUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@admin.com";
            string password = "QweAsdZxc!23";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ProjectUser admin = new ProjectUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
