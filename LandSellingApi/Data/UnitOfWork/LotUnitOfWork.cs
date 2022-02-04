using Data.Contract.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class LotUnitOfWork : ILotUnitOfWork
    {
        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
