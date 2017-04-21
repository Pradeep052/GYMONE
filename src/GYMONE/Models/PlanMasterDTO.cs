using GYM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMONE.Models
{
    public class PlanMasterDTO : PlanMaster
    {
        public PlanMasterDTO(PlanMaster pm) :base()
        {
            this.PlanId = pm.PlanId;
            this.PlanName = pm.PlanName;
        }        
    }
}
