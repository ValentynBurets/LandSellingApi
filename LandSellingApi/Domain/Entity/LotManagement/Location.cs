using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Location : EntityBase
    {

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
