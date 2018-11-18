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
    public class ProductsController : BaseController
    {
        private readonly SignInManager<ChushkaUser> _signInManager;

        public ProductsController(SignInManager<ChushkaUser> signIn, ChushkaDbContext context) : base(context)
        {
            _signInManager = signIn;
        }

        public IActionResult ProductDetails(int id)
        {
            var userName = _signInManager.UserManager.GetUserName(User);

            var userViewModel = _signInManager.UserManager.Users
                .Select(u => new UserViewModel
                {
                    UserName = u.UserName,
                    FullName = u.FullName,
                    Email = u.Email,
                    Role = u.Role,
                })
                .FirstOrDefault(u => u.UserName == userName);

            var productViewModel = Db.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StringType = p.Type.ToString()
                })
                .FirstOrDefault(p => p.Id == id);

            if (productViewModel != null)
            {
                if (userViewModel != null) productViewModel.Role = userViewModel.Role.Name;
            }

            return View("~/Views/Products/ProductDetails.cshtml", productViewModel);
           
        }

        public IActionResult Order(int id)
        {
            var client = Db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var productToOrder = Db.Products.FirstOrDefault(p => p.Id == id);

            if (client == null || productToOrder == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            var order = new Order
            {
                Client = client,
                ClientId = client.Id,
                Product = productToOrder,
                ProductId = productToOrder.Id,
                OrderedOn = DateTime.UtcNow
            };

            Db.Orders.Add(order);
            Db.SaveChanges();

            return View("~/Views/Orders/Order.cshtml");
        }

        public IActionResult ProductEdit(int id)
        {
            var userId = _signInManager.UserManager.GetUserId(User);

            var user = Db.Users.FirstOrDefault(u => u.Id == userId);

            var userRoleId = user?.RoleId;

            var role = Db.Roles.FirstOrDefault(r => r.Id == userRoleId);
            

            if (user == null || role?.Name != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            var product = Db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = (int)product.Type,
                Role = role.Name
            };
            
            
            return View("~/Views/Products/ProductEdit.cshtml", productViewModel);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductViewModel model)
        {
            var product = Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return View();
            }

            string productTypeString = ((ProductType) Enum.ToObject(typeof (ProductType), model.Type)).ToString();

            ProductType type;

            bool isEnum = Enum.TryParse(productTypeString, out type);

            product.Type = type;
            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;

            Db.Products.Update(product);
            Db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ProductDelete(int id)
        {
            var userId = _signInManager.UserManager.GetUserId(User);

            var user = Db.Users.FirstOrDefault(u => u.Id == userId);

            var userRoleId = user?.RoleId;

            var role = Db.Roles.FirstOrDefault(r => r.Id == userRoleId);
            

            if (user == null || role?.Name != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            var product = Db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = (int)product.Type,
                Role = role.Name
            };
            
            
            return View("~/Views/Products/ProductDelete.cshtml", productViewModel);
        }

        [HttpPost]
        public IActionResult ProductDelete(ProductViewModel model)
        {
            var product = Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return View();
            }

            Db.Products.Remove(product);
            Db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
