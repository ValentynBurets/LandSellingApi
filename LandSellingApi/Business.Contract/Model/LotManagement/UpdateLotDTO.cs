using System;
using Domain.Entity.Constants;

namespace Business.Contract.Model.LotManagement
{
    public class UpdateLotDTO
    {
        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public LocationDTO Location { get; set; }
    
    }
}
