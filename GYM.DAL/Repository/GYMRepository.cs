using GYM.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.DAL.Domain;


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
    }
}
