using Business.Contract.Model.LotManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface IImageService
    {
        public Task Create(ImageDTO createImage);
        public Task Delete(Guid id);
        public Task Update(ImageDTO updateImage, Guid imageId);
        public Task<IEnumerable<ImageDTO>> GetAllByLotId(Guid lotId);
    }
}
