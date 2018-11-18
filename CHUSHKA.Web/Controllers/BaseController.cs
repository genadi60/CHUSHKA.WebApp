using CHUSHKA.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(ChushkaDbContext context)
        {
            Db = context;
        }

        protected ChushkaDbContext Db { get; }
    }
}
