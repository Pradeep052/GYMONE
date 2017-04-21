using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GYMONE.Models;
using GYM.DAL.Repository;
using GYM.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


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
            return View(_gymRepository.GetMember());
        }

        [HttpGet]

        public IActionResult Create()
        {
            MemberRegistrationDTO objMR = new MemberRegistrationDTO();

            objMR.ListScheme = BindListScheme();
            objMR.ListPlan = BindListPlan();
            objMR.Listgender = BindGender();
            ViewData["SelectedPlan"] = string.Empty;


            return View(objMR);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberRegistrationDTO obj, FormCollection frm)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.MemberFName))
                {
                    ModelState.AddModelError("Error", "Please enter First Name");
                }
                else if (string.IsNullOrEmpty(obj.MemberMName))
                {
                    ModelState.AddModelError("Error", "Please enter Middle Name");
                }
                else if (string.IsNullOrEmpty(obj.MemberLName))
                {
                    ModelState.AddModelError("Error", "Please enter Last Name");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.DOB)))
                {
                    ModelState.AddModelError("Error", "Please select Birth Date");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.JoiningDate)))
                {
                    ModelState.AddModelError("Error", "Please select Joining Date");
                }
                else if (string.IsNullOrEmpty(obj.Age))
                {
                    ModelState.AddModelError("Error", "Please enter Age");
                }
                else if (string.IsNullOrEmpty(obj.EmailID))
                {
                    ModelState.AddModelError("Error", "Please enter EmailID");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.WorkouttypeID)))
                {
                    ModelState.AddModelError("Error", "Please select  Workouttype");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.PlantypeID)))
                {
                    ModelState.AddModelError("Error", "Please select Plan");
                }
                else if (string.IsNullOrEmpty(obj.Contactno))
                {
                    ModelState.AddModelError("Error", "Please enter Contactno");
                }
                else if (string.IsNullOrEmpty(obj.Address))
                {
                    ModelState.AddModelError("Error", "Please enter Address");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.Amount)))
                {
                    ModelState.AddModelError("Error", "Amount Cannot be Empty");
                }
                else
                {
                    string[] parttime = obj.DOB.ToString().Split('-');
                    int year1 = Convert.ToInt32(obj.DOB.Value.Year);
                    int month1 = Convert.ToInt32(obj.DOB.Value.Month);
                    int day1 = Convert.ToInt32(obj.DOB.Value.Day);
                    DateTime birthdate = new DateTime(year1, month1, day1);
                    obj.DOB = birthdate;

                    string[] joing = obj.JoiningDate.ToString().Split('-');
                    int year2 = Convert.ToInt32(obj.JoiningDate.Value.Year);
                    int month2 = Convert.ToInt32(obj.JoiningDate.Value.Month);
                    int day2 = Convert.ToInt32(obj.JoiningDate.Value.Day);
                    DateTime joining = new DateTime(year2, month2, day2);
                    obj.JoiningDate = joining;
                    obj.Createdby = Convert.ToInt32(2);
                    GYM.DAL.Domain.MemberRegistration objDomain = new GYM.DAL.Domain.MemberRegistration();
                    objDomain.MemberFname = obj.MemberFName;
                    objDomain.MemberLname = obj.MemberLName;
                    objDomain.Dob = obj.DOB;
                    objDomain.Age = obj.Age;
                    objDomain.Contactno = obj.Contactno;
                    objDomain.EmailId = obj.EmailID;
                    objDomain.Gender = obj.Gender;
                    objDomain.PlantypeId = obj.PlantypeID;
                    objDomain.WorkouttypeId = obj.WorkouttypeID;
                    objDomain.Createdby = obj.Createdby;
                    objDomain.JoiningDate = obj.JoiningDate;
                    objDomain.Address = obj.Address;
                    objDomain.MainMemberId = obj.MainMemberID;
                    objDomain.MemberNo = obj.MemberNo;
                    int MemberID = _gymRepository.InsertMember(objDomain); // Insert into MemberDetails
                    //if (MemberID > 0)
                    //{
                    //    int payresult = Pay(obj, MemberID); // Insert into Paymentdetails
                    //    if (payresult > 0)
                    //    {
                    //        TempData["Message"] = "Member Created Successfully.";
                    //    }
                    //    else
                    //    {
                    //        TempData["Message"] = "Some thing went wrong while Member Created .";
                    //    }
                    //}
                    //else
                    //{
                    //    TempData["Message"] = "Some thing went wrong while Member Created .";
                    //}

                    return RedirectToAction("Create");
                }

                obj.ListScheme = BindListScheme(); // binding scheme
                obj.ListPlan = BindListPlan(); // binding plan
                obj.Listgender = BindGender(); // binding gender
                ViewData["SelectedPlan"] = obj.PlantypeID; // Maintaining plan dropdowm list after postback

                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
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

        [NonAction]
        public List<PlanMasterDTO> BindListPlan()
        {
            List<PlanMasterDTO>
            ListPlan = new List<PlanMasterDTO>();
            ListPlan.Add(new PlanMasterDTO(new GYM.DAL.Domain.PlanMaster()) { PlanName = "Select", PlanId = 0 });

            foreach (var item in _gymRepository.GetPlan())
            {
                PlanMasterDTO pm = new PlanMasterDTO(item);
                ListPlan.Add(pm);
            }


            return ListPlan;
        }

        public List<SelectListItem> BindGender()
        {

            List<SelectListItem> lgender = new List<SelectListItem>(){
            new SelectListItem { Text="Select", Value="0", Selected=true},
            new SelectListItem {Text="Male", Value="1", Selected=false},
            new SelectListItem {Text="Female", Value="2", Selected=false}
            };
            return lgender;
        }

        #endregion

        

        public JsonResult GetPlan(string WorkTypeID)
        {
            var plandata = _gymRepository.GetPlanByWorkTypeID(WorkTypeID);
            return Json(plandata);
        }

        public JsonResult GetAmount(string PlanID, string WorkTypeID)
        {
            var amount = _gymRepository.GetAmount(PlanID, WorkTypeID);
            return Json(amount);
        }



    }
}


