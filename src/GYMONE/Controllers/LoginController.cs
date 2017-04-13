using Microsoft.AspNetCore.Mvc;
using GYMONE.Models;
using GYM.DAL.Repository.Interfaces;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GYMONE.Controllers
{
    public class LoginController : Controller
    {
        private IGYMRepository _gymRepository = null;

        public LoginController(IGYMRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                var users = _gymRepository.GetUsers();
                if (users.Any(u => u.EmailID == login.Username))
                {
                    return RedirectToAction("UserDashboard", "Dashboard");
                }
                else
                {
                    TempData["ValidationMessage"] = "Please enter valid Username and Password";
                    return View(login);
                }
            }

            return View(login);
        }
    }
}
