using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.Lot
{
    public class CreateLotDTO
    {
        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Geometry Location { get; set; }
    }
}
