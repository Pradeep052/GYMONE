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
    }
}
