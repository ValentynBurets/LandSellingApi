using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Lot.Image
{
    public class PostImageViewModel
    {
        public int LotId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
