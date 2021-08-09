using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Rent
{
    public class PostRentViewModel
    {
        public int LotId { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
