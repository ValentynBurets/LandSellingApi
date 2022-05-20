using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Data.Identity;
using Domain.Entity;

namespace WebAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<AuthorisationUser, RegisterUserModel>().ReverseMap();
            CreateMap<Lot, LotDTO>().ReverseMap();
            CreateMap<Agreement, AgreementDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Bid, BidDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<PriceCoef, PriceCoefDTO>().ReverseMap();
        }
    }
}