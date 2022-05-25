﻿using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Lot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface ILotService  
    {
        public Task Create(CreateLotDTO createLot, Guid ownerId);
        public Task Delete(Guid id);
        public Task Update(UpdateLotDTO updateLot, Guid lotId);
        public Task<ReturnLotDTO> GetById(Guid lotId);
        public Task<IEnumerable<ReturnLotDTO>> GetAll();
    }
}
