
namespace Domain.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public byte[] ImageData { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
