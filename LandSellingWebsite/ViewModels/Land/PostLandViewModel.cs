using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Land
{
    public class PostLandViewModel
    {
        public string Description { get; set; }
        public float? Square { get; set; }
        public int OwnerId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Building { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string ImageUrl { get; set; }
    }
}
