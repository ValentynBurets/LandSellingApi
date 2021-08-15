using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class VHouse
    {
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
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Building { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
