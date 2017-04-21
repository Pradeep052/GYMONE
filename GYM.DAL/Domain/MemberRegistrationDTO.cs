using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Domain
{
    public class MemberRegistrationDTO
    {

        
        public int MemID { get; set; }
        public string MemberNo { get; set; }

        
        public string MemberFName { get; set; }
        
        public string MemberLName { get; set; }
       
        public string MemberMName { get; set; }

      
        public DateTime? DOB { get; set; }


       
        public string Age { get; set; }

       
        public string Contactno { get; set; }

      
        public string EmailID { get; set; }

      
        public string Gender { get; set; }

       
        public int? PlantypeID { get; set; }

     
        public int? WorkouttypeID { get; set; }


        public int? Createdby { get; set; }

        public int? ModifiedBy { get; set; }

        public string MemImagename { get; set; }

        public string MemImagePath { get; set; }

       
        public DateTime? JoiningDate { get; set; }

     
        public string Address { get; set; }
        public int? MainMemberID { get; set; }
      
        public Decimal? Amount { get; set; }

       
        public IEnumerable<SchemeMaster> ListScheme { get; set; }
        
        public IEnumerable<PlanMaster> ListPlan { get; set; }
        
       // public IEnumerable<SelectListItem> Listgender { get; set; }

        
        public string FullName { get; set; }

        
        public string PaymentID { get; set; }
    }
}
