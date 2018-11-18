namespace CHUSHKA.Web.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    
    using System.Threading.Tasks;
    using Data;
    using ViewModels;

    [ViewComponent(Name = "action")]
    public class DynamicActionViewComponent : ViewComponent
    {
        private readonly ChushkaDbContext _context;
        public DynamicActionViewComponent(ChushkaDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new List<ActionViewModel>();

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return View("~/Views/Shared/Components/action/Default.cshtml",viewModel);
            }

            var userRoleId = user.RoleId;

            if (userRoleId == null)
            {
                return View("~/Views/Shared/Components/action/Default.cshtml",viewModel);
            }

            
            var role = _context.Roles.FirstOrDefault(r => r.Id == userRoleId);
            
            if (role == null || role.ToString() == "User")
            {
                return View("~/Views/Shared/Components/action/Default.cshtml",viewModel);
            }
            
            viewModel = new List<ActionViewModel>
            {
                new ActionViewModel{Controller = "User", Action = "Create", Title = "Create Product"},
                new ActionViewModel{Controller = "User", Action = "AllOrders", Title = "All Orders"}
            };

            return View("~/Views/Shared/Components/action/Default.cshtml",viewModel);
        }
    }
}
