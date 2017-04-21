using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Domain
{
    public class MemberRegistration
    {
        public long MemId { get; set; }
        public string MemberNo { get; set; }
        public string MemberFname { get; set; }
        public string MemberLname { get; set; }
        public string MemberMname { get; set; }
        public DateTime? Dob { get; set; }
        public string Age { get; set; }
        public string Contactno { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public int? PlantypeId { get; set; }
        public int? WorkouttypeId { get; set; }
        public long? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string MemImagename { get; set; }
        public string MemImagePath { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Address { get; set; }
        public long? MainMemberId { get; set; }
    }
}
