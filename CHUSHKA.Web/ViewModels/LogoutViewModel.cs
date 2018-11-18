//Not used!
namespace CHUSHKA.Web.ViewModels
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    using Models;

    public class LogoutViewModel
    {
        public LogoutViewModel(SignInManager<ChushkaUser> signInManager, ILogger<ChushkaUser> logger)
        {
            SignInManager = signInManager;
            Logger = logger;
        }

        public SignInManager<ChushkaUser> SignInManager { get; }

        public ILogger<ChushkaUser> Logger { get; }

        public void OnGet()
        {
        }
    }
}
