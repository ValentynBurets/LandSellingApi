using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement
{
    public class ImageDTO
    {
        public Guid LotId { get; set; }
        public string ImageData { get; set; }
    }
}
