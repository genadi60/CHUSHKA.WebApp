using System.Linq;
using CHUSHKA.Data;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(ChushkaDbContext context) : base(context)
        {
        }

        public IActionResult AllOrders()
        {
            var allOrders = Db.Orders
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    Product = o.Product.Name,
                    Client = o.Client.FullName,
                    OrderedOn = o.OrderedOn.ToString("dd/MM/yyyy hh:mm:ss")
                })
                .ToList();

            var allOrdersViewModel = new AllOrdersViewModel
            {
                Orders = allOrders
            };

            return View(allOrdersViewModel);
        }
    }
}
