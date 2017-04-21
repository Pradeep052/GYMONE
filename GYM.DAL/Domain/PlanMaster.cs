using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Domain
{
    public class PlanMaster
    {

        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal? PlanAmount { get; set; }
        public decimal? ServicetaxAmout { get; set; }
        public string ServiceTax { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }
        public string RecStatus { get; set; }
        public int? SchemeId { get; set; }
        public int? PeriodId { get; set; }
        public decimal? TotalAmout { get; set; }
        public string ServicetaxNo { get; set; }

    }
}
