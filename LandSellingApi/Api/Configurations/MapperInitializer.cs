using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Model.LotManagement.Lot;
using Data.Identity;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Configurations
{ 
     public class MapperInitializer : Profile
     {
           public MapperInitializer()
            {   
                CreateMap<AuthorisationUser, RegisterUserModel>().ReverseMap();
                CreateMap<Lot, CreateLotDTO>().ReverseMap();
                CreateMap<Lot, UpdateLotDTO>().ReverseMap();

            }
     }

}