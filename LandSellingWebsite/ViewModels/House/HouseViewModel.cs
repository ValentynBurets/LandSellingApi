using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.House
{
    public class HouseViewModel
    {
        public byte? Rooms { get; set; }
        public byte? Storeys { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }

        public virtual LotViewModel Lot { get; set; }
    }
}
