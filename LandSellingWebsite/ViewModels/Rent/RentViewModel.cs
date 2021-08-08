using LandSellingWebsite.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Price { get; set; }
        public string RentStatus { get; set; }

        public virtual UserViewModel Customer { get; set; }
        public virtual LotViewModel Lot { get; set; }
        public virtual UserViewModel Manager { get; set; }
    }
}
