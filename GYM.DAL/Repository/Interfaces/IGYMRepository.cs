using GYM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Repository.Interfaces
{
    public interface IGYMRepository
    {
        List<Users> GetUsers();

        IEnumerable<SchemeMaster> GetSchemes();

        IEnumerable<PlanMaster> GetPlan();

        IEnumerable<PlanMaster> GetPlanByWorkTypeID(string SchemeID);

        string GetAmount(string MemID, string WorkTypeID);

        int InsertMember(MemberRegistration objMRDTO);

        IEnumerable<MemberRegistration> GetMember();

    }
}
