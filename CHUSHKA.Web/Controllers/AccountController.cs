using System;
using System.Linq;
using System.Threading.Tasks;
using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Web.Services.Contracts;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CHUSHKA.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ChushkaUser> _signIn;

        private readonly ILogger<ChushkaUser> _logger;

        private readonly IAccountService _accountService;

        public AccountController(SignInManager<ChushkaUser> signIn, UserManager<ChushkaUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<ChushkaUser> logger, IAccountService accountService, ChushkaDbContext context) : base(context)
        {
            _signIn = signIn;
            _logger = logger;
            _accountService = accountService;
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            var user = _signIn.UserManager.Users.FirstOrDefault(u => u.UserName == loginModel.Username);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = _signIn.PasswordSignInAsync(
                loginModel.Username,
                loginModel.Password,
                loginModel.RememberMe,
                lockoutOnFailure: false
            ).Result;

            if (result.Succeeded)
            {
                _logger.LogInformation(message: $"MyIdentity: {user.FullName}. Logged in on: {DateTime.UtcNow:dd/MM/yyyy hh:mm:ss}");
                
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               bool isCreated = _accountService.Create(model);

                if (!isCreated)
                {
                    return View();
                }

                return View("~/Views/Account/Registered.cshtml");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();

            _logger.LogInformation(message: $"User logged out on: {DateTime.UtcNow:dd/MM/yyyy hh:mm:ss}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Manage()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
