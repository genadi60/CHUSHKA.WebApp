using System;
using System.Linq;
using CHUSHKA.Models;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CHUSHKA.Web.Services
{
    public class AccountService : IAccountService
    {

        private readonly SignInManager<ChushkaUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ILogger<ChushkaUser> _logger;

        public AccountService(SignInManager<ChushkaUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<ChushkaUser> logger)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public bool Create(RegisterViewModel model)
        {
            model.Role = _signInManager.UserManager.Users.Any() ? "User" : "Administrator";

            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == model.Role);

            var user = new ChushkaUser { UserName = model.Username, FullName = model.FullName, Role = role, Email = model.Email };

            
            var result = _signInManager.UserManager.CreateAsync(user, model.Password).Result;

            if (!result.Succeeded)
            {
                return false;
            }

            result = _signInManager.UserManager.AddToRoleAsync(user, model.Role).Result;

            if (!result.Succeeded)
            {
               return false;
            }

            _logger.LogInformation($"User {model.FullName} created a new account with password on: {DateTime.UtcNow:dd/MM/yyyy hh:mm:ss}.");

            return true;
        }
    }
}
