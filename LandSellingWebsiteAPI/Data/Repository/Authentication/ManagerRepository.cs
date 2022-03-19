using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Authentication
{
    public class ManagerRepository : EntityRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(LandSellingContext exerciseDbContext) : base(exerciseDbContext)
        {
        }

    }
}
