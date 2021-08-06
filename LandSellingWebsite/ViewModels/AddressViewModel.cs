using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Address")]
        public string FullAddress { get; set; }


        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
