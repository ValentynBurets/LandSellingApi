using System;

namespace Domain.Entity
{
    public partial class Rent
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int RentStatusId { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Price { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Customer Manager { get; set; }
        public virtual RentStatusType RentStatus { get; set; }
    }
}
