using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LotId { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual AppUser User { get; set; }
    }
}
