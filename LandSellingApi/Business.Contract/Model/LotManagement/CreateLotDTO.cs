using System;

namespace Business.Contract.Model.LotManagement
{
    public class CreateLotDTO
    {
        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public LocationDTO Location { get; set; }
    }
}
