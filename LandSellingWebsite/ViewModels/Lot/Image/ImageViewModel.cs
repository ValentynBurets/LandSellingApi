using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Lot
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
