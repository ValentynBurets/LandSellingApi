
namespace Domain.Entity
{
    public partial class House
    {
        public int Id { get; set; }
        public int? LotId { get; set; }
        public byte? Rooms { get; set; }
        public byte? Storeys { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
