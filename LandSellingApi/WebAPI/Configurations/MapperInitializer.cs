using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using Business.Contract.Model.LotManagement.Lot;
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
           
            CreateMap<Lot, UpdateLotDTO>()
                .ForMember("State", opt => opt.MapFrom(lot => lot.Status.ToString()));
            CreateMap<CreateLotDTO, Lot>();
            CreateMap<Lot, ReturnLotDTO>()
                .ForMember("State", opt => opt.MapFrom(lot => lot.Status.ToString()));
            CreateMap<UpdateLotDTO, Lot>()
                .ForMember("State", opt => opt.MapFrom(lot => (State)Enum.Parse(typeof(State), lot.Status)));

            CreateMap<CreateAgreementDTO, Agreement>();

            CreateMap<Agreement, AgreementDTO>()
                .ForMember("State", opt => opt.MapFrom(lot => lot.Status.ToString()));
            
            CreateMap<AgreementDTO, Agreement > ()
                .ForMember("State", opt => opt.MapFrom(lot => (State)Enum.Parse(typeof(State), lot.Status)));

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Bid, BidDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<PriceCoef, PriceCoefDTO>().ReverseMap();
        }
    }
}