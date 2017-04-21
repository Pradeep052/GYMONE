using GYM.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.DAL.Domain;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace GYM.DAL.Repository
{
    public class GYMRepository : IGYMRepository
    {
        private readonly GYMDBContext _context;
        public GYMRepository(GYMDBContext context)
        {
            _context = context;
        }
        public List<Users> GetUsers()
        {
            return _context.User.ToList();
        }

        public IEnumerable<SchemeMaster> GetSchemes()
        {
            return _context.SchemeMaster.ToList();
            //DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            //throw new NotImplementedException();
        }

        public IEnumerable<PlanMaster> GetPlan()
        {
            //var list = _context.Set<PlanMaster>().FromSql("dbo.sprocPlanMasterSelectList");
            var list = _context.PlanMaster.ToList();
            return list;
        }

        public IEnumerable<PlanMaster> GetPlanByWorkTypeID(string SchemeID)
        {
            int _schemeId = Convert.ToInt32(SchemeID);
            List<PlanMaster> list = _context.PlanMaster.Where(p => p.SchemeId == _schemeId).ToList();
            return list;
        }

        public string GetAmount(string PlanID, string WorkTypeID)
        {
            int _planID = Convert.ToInt32(PlanID);
            int _workTypeID = Convert.ToInt32(WorkTypeID);
            var planMaster = _context.PlanMaster
                .FirstOrDefault(p => p.PlanId == _planID && p.SchemeId == _workTypeID);
            string totAmt = planMaster.TotalAmout.ToString();            
            return totAmt;
        }

        public int InsertMember(MemberRegistration objMRDTO)
        {            
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
            int memId = Convert.ToInt32(_context.MemberRegistration.Max(m => m.MemId).ToString());
            objMRDTO.MemberNo = "GYMONE/" + memId +"/"+ DateTime.Now.Year.ToString();
            objMRDTO.CreatedDate = DateTime.Now;
            objMRDTO.MainMemberId = memId + 1;
            _context.MemberRegistration.Add(objMRDTO);
            _context.SaveChanges();            
            return memId + 1;
        }

        public IEnumerable<MemberRegistration> GetMember()
        {
            var list = _context.MemberRegistration.ToList();
            return list;
        }
    }
}
