namespace CHUSHKA.Web.ViewModels
{
    using System.Collections.Generic;

    public class AllOrdersViewModel
    {
        public virtual ICollection<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}
