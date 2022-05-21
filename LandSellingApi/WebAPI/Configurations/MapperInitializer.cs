using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Data.Identity;
using Domain.Entity;
using Domain.Entity.Constants;
using System;

namespace WebAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<AuthorisationUser, RegisterUserModel>().ReverseMap();
           
            CreateMap<Lot, LotDTO>()
                .ForMember("State", opt => opt.MapFrom(lot => lot.Status.ToString()));
            CreateMap<LotDTO, Lot>()
                .ForMember("State", opt => opt.MapFrom(lot => (State)Enum.Parse(typeof(State), lot.Status)));


            CreateMap<Agreement, AgreementDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Bid, BidDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<PriceCoef, PriceCoefDTO>().ReverseMap();
        }
    }
}