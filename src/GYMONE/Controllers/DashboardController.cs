using Microsoft.AspNetCore.Mvc;

namespace GYMONE.Controllers
{
    public class DashboardController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View("UserDashboard");
        }
    }
}
