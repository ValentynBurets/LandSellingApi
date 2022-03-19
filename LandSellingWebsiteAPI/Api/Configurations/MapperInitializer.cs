using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Model.LotManagement;
using Data.Identity;
using Domain.Entity;

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