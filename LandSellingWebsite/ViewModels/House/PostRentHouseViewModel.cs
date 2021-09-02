using LandSellingWebsite.ViewModels.Address;
using LandSellingWebsite.ViewModels.Lot.PriceCoef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.House
{
    public class PostRentHouseViewModel
    {
        public int Id { get; set; }
        public byte? Rooms { get; set; }
        public byte? Storeys { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }

        public virtual LotViewModel Lot { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public virtual ICollection<PriceCoefViewModel> PriceCoefs { get; set; }
    }
}
