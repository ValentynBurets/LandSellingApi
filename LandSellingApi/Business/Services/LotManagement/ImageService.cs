using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.LotManagement
{
    public class ImageService: IImageService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public ImageService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(ImageDTO createImage, Guid lotId)
        {
            Image newImage = _mapper.Map<Image>(createImage);
            newImage.LotId = lotId;
            await _unitOfWork.ImageRepository.Add(newImage);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var image = await _unitOfWork.ImageRepository.GetById(id);
            await _unitOfWork.ImageRepository.Remove(image);
            await _unitOfWork.Save();
        }

        public async Task Update(ImageDTO updateImage, Guid imageId)
        {
            Image newImage = _mapper.Map<Image>(updateImage);
            await _unitOfWork.ImageRepository.Update(newImage);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<ImageDTO>> GetAllByLotId(Guid lotId)
        {
            IEnumerable<Image> images = await _unitOfWork.ImageRepository.GetByLotId(lotId);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }
    }
}
