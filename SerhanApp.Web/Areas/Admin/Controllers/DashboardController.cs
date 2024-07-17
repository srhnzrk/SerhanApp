using Microsoft.AspNetCore.Mvc;

namespace SerhanApp.Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }

     
    }
}
