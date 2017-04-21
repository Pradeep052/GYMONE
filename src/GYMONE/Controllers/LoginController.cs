using Microsoft.AspNetCore.Mvc;
using GYMONE.Models;
using GYM.DAL.Repository.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginModel obj, FormCollection frm)
        {
            if (string.IsNullOrEmpty(obj.Username))
            {
                ModelState.AddModelError("Error", "Please enter Username");
            }
            //else if (string.IsNullOrEmpty(obj.Password))
            //{
            //    ModelState.AddModelError("Error", "Please enter Password");
            //}
           else
            {
                var users = _gymRepository.GetUsers();
                if (users.Any(u => u.EmailID == obj.Username))
                {
                    return RedirectToAction("UserDashboard", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("Error", "Please enter valid Username and Password");
                    //TempData["ValidationMessage"] = "Please enter valid Username and Password";
                    return View();
                }
            }

            return View();
        }
    }
}
