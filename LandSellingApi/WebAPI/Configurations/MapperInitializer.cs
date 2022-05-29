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
                .ForMember("Status", opt => opt.MapFrom(lot => lot.Status.ToString()));
            CreateMap<CreateLotDTO, Lot>();
            CreateMap<Lot, ReturnLotDTO>()
                .ForMember("Status", opt => opt.MapFrom(lot => lot.Status.ToString()));
            CreateMap<Lot, ReturnSimpleLotDTO>();
            CreateMap<UpdateLotDTO, Lot>()
                .ForMember("Status", opt => opt.MapFrom(lot => (State)Enum.Parse(typeof(State), lot.Status)));

            CreateMap<CreateAgreementDTO, Agreement>();

            CreateMap<Agreement, AgreementDTO>()
                .ForMember("Status", opt => opt.MapFrom(lot => lot.Status.ToString()));
            
            CreateMap<AgreementDTO, Agreement > ()
                .ForMember("Status", opt => opt.MapFrom(lot => (State)Enum.Parse(typeof(State), lot.Status)));

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Bid, BidDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<PriceCoef, PriceCoefDTO>().ReverseMap();

            CreateMap<User, UserInfoViewModel>();

            CreateMap<User, UserInfoViewModel>()
                .ForMember("Role", opt => opt.MapFrom(c => "User"));
            CreateMap<Admin, UserInfoViewModel>()
                .ForMember("Role", opt => opt.MapFrom(a => "Admin"));

            CreateMap<User, ProfileInfoModel>();

            CreateMap<Admin, ProfileInfoModel>();

            CreateMap<GetLotOptionsDTO, GetLotOptions>()
                .ForMember("LotType", opt => opt.MapFrom(opt => Enum.Parse(typeof(LotType), opt.LotType)))
                .ForMember("SortType", opt => opt.MapFrom(opt => Enum.Parse(typeof(SortType), opt.SortType)))
                .ForMember("State", opt => opt.MapFrom(opt => Enum.Parse(typeof(State), opt.State)));

        }
    }
}