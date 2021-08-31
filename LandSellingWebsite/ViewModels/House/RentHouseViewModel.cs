using LandSellingWebsite.ViewModels.Lot;
using LandSellingWebsite.ViewModels.Lot.PriceCoef;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.House
{
    public class RentHouseViewModel
    {
        public RentHouseViewModel()
        {
            PriceCoefs = new HashSet<PriceCoefViewModel>();
            Images = new HashSet<ImageViewModel>();

        }

        public int Id { get; set; }
        public byte? Rooms { get; set; }
        public byte? Storeys { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }
        public string Description { get; set; }
        public float? Square { get; set; }
        public DateTime PublicationDate { get; set; }
        public string LotStatus { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Display(Name = "Full Address")]
        public string FullAddress { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        [Display(Name = "AdditionalDescription")]
        public string AdditionalDescription { get; set; }

        public virtual ICollection<PriceCoefViewModel> PriceCoefs { get; set; }
        public virtual ICollection<ImageViewModel> Images { get; set; }
    }
}
