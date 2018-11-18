using CHUSHKA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CHUSHKA.Web.ViewModels
{
    public class LogoutViewModel
    {
        private readonly SignInManager<ChushkaUser> _signInManager;
        private readonly ILogger<LogoutViewModel> _logger;

        public LogoutViewModel(SignInManager<ChushkaUser> signInManager, ILogger<LogoutViewModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        
    }
}
