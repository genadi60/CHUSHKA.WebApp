using System.Collections.Generic;

namespace CHUSHKA.Web.ViewModels
{
    public class AllOrdersViewModel
    {
        public virtual ICollection<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}
