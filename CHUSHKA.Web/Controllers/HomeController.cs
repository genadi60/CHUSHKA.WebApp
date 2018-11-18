using System.Diagnostics;
using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SignInManager<ChushkaUser> _signInManager;

        public HomeController(SignInManager<ChushkaUser> signInManager, ChushkaDbContext context) : base(context)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return View(); 
            }
            
            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
