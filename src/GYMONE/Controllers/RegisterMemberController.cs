using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GYMONE.Models;
using GYM.DAL.Repository;
using GYM.DAL.Repository.Interfaces;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GYMONE.Controllers
{
    public class RegisterMemberController : Controller
    {

        private IGYMRepository _gymRepository = null;

        public RegisterMemberController(IGYMRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Create()
        {
            MemberRegistrationDTO objMR = new MemberRegistrationDTO();

            objMR.ListScheme = BindListScheme();
            //objMR.ListPlan = BindListPlan();
            //objMR.Listgender = BindGender();
            //ViewData["SelectedPlan"] = string.Empty;

            return View(objMR);
        }

        #region Binding_Dropdown_code
        [NonAction] // if Method is not Action method then use NonAction
        public List<SchemeMasterDTO> BindListScheme()
        {
            List<SchemeMasterDTO> listscheme = new List<SchemeMasterDTO>()
            { new
            SchemeMasterDTO
            { SchemeID = 0,
                SchemeName = "Select" } };

            foreach (var item in _gymRepository.GetSchemes())
            {
                SchemeMasterDTO sm = new SchemeMasterDTO();
                sm.SchemeID = item.SchemeID;
                sm.SchemeName = item.SchemeName;
                listscheme.Add(sm);
            }
            return listscheme;

        }
        #endregion
    }
}


