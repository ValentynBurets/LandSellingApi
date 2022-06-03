using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Location : EntityBase
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
