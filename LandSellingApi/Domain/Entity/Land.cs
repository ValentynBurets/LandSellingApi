
namespace Domain.Entity
{
    public partial class Land
    {
        public int Id { get; set; }
        public int? LotId { get; set; }

        public virtual Lot Lot { get; set; }
    }
}

