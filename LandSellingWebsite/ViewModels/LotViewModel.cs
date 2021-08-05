using LandSellingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels
{
    public class LotViewModel
    {
        public LotViewModel()
        {
            //PriceCoefLots = new HashSet<PriceCoef>();   
        }

        public int Id { get; set; }
        public int? AddressId { get; set; }
        public int? OwnerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public int LotStatusId { get; set; }
        public float? Square { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        //public virtual Address Address { get; set; }
        //public virtual AppUser Owner { get; set; }
        //public virtual ICollection<PriceCoef> PriceCoefDurationTypes { get; set; }
        //public virtual ICollection<PriceCoef> PriceCoefLots { get; set; }
    }
}

