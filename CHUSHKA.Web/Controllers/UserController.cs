using System;
using System.Linq;
using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Models.Enums;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly SignInManager<ChushkaUser> _signInManager;

        public UserController(SignInManager<ChushkaUser> signInManager, ChushkaDbContext context) : base(context)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var products = Db.Products.ToList();
            var userId = _signInManager.UserManager.GetUserId(User);
            var user = Db.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                Products = products
            };

            if (userViewModel.Role != null && userViewModel.Role.Name == "Administrator")
            {
                return View("~/Views/Users/AdminHome.cshtml", userViewModel);
            }

            return View("~/Views/Users/UserHome.cshtml", userViewModel);
        }

        public IActionResult Create()
        {
            var userId = _signInManager.UserManager.GetUserId(User);

            var user = Db.Users.FirstOrDefault(u => u.Id == userId);

            if (user?.RoleId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var role = Db.Roles.FirstOrDefault(r => r.Id == user.RoleId);

            if (role == null || role.Name != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Products/ProductCreate.cshtml");
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductViewModel model)
        {
            var userId = _signInManager.UserManager.GetUserId(User);

            var user = Db.Users.FirstOrDefault(u => u.Id == userId);

            var userRoleId = user?.RoleId;

            var role = Db.Roles.FirstOrDefault(r => r.Id == userRoleId);
            

            if (user == null || role?.Name != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            string productTypeString = ((ProductType) Enum.ToObject(typeof (ProductType), model.Type)).ToString();

            ProductType type;

            bool isEnum = Enum.TryParse(productTypeString, out type);

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Type = type
            };
            
            Db.Products.Add(product);
            Db.SaveChanges();
            
            return RedirectToAction("Index", "User" );
        }

        public IActionResult AllOrders()
        {
            return RedirectToAction("AllOrders", "Orders");
        }
    }
}
