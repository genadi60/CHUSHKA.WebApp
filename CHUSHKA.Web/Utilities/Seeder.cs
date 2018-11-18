﻿namespace CHUSHKA.Web.Utilities
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;

            if (!adminRoleExists)
            {
               roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            var userRoleExists = roleManager.RoleExistsAsync("User").Result;

            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
