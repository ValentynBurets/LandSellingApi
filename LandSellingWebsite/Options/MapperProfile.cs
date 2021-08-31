using AutoMapper;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Address;
using LandSellingWebsite.ViewModels.Bid;
using LandSellingWebsite.ViewModels.House;
using LandSellingWebsite.ViewModels.Lot;
using LandSellingWebsite.ViewModels.Lot.Favorite;
using LandSellingWebsite.ViewModels.Lot.Image;
using LandSellingWebsite.ViewModels.Lot.PriceCoef;
using LandSellingWebsite.ViewModels.LotStatusType;
using LandSellingWebsite.ViewModels.Rent;
using LandSellingWebsite.ViewModels.Selling;
using LandSellingWebsite.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Options
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

            #region AppUser

            CreateMap<AppUser, UserViewModel>().MaxDepth(2);
            CreateMap<UserViewModel, AppUser>().MaxDepth(2);

            CreateMap<AppUser, SimpleUserViewModel>().MaxDepth(2);
            CreateMap<SimpleUserViewModel, AppUser>().MaxDepth(2);

            CreateMap<Role, RoleViewModel>().MaxDepth(2);
            CreateMap<RoleViewModel, Role>().MaxDepth(2);

            
            #endregion

            #region Lot

            CreateMap<Lot, LotViewModel>().MaxDepth(2);
            CreateMap<LotViewModel, Lot>().MaxDepth(2);

            CreateMap<LotStatusType, LotStatusTypeViewModel>().MaxDepth(2);
            CreateMap<LotStatusTypeViewModel, LotStatusType>().MaxDepth(2);

            CreateMap<LotStatusType, PostLotStatusTypeViewModel>().MaxDepth(2);
            CreateMap<PostLotStatusTypeViewModel, LotStatusType>().MaxDepth(2);

            CreateMap<PriceCoef, PostPriceCoefViewModel>().MaxDepth(2);
            CreateMap<PostPriceCoefViewModel, PriceCoef>().MaxDepth(2);

            CreateMap<PriceCoef, PriceCoefViewModel>().MaxDepth(2);
            CreateMap<PriceCoefViewModel, PriceCoef>().MaxDepth(2);

            CreateMap<Address, AddressViewModel>().MaxDepth(2);
            CreateMap<AddressViewModel, Address>().MaxDepth(2);

            CreateMap<Address, PostAddressViewModel>().MaxDepth(2);
            CreateMap<PostAddressViewModel, Address>().MaxDepth(2);

            CreateMap<Image, ImageViewModel>().MaxDepth(2);
            CreateMap<ImageViewModel, Image>().MaxDepth(2);

            CreateMap<Image, PostImageViewModel>().MaxDepth(2);
            CreateMap<PostImageViewModel, Image>().MaxDepth(2);

            CreateMap<Favorite, FavoriteViewModel>().MaxDepth(2);
            CreateMap<FavoriteViewModel, Favorite>().MaxDepth(2);

            CreateMap<Favorite, PostFavoriteViewModel>().MaxDepth(2);
            CreateMap<PostFavoriteViewModel, Favorite>().MaxDepth(2);

            #endregion

            #region Rent
            CreateMap<RentStatusType, RentStatusTypeViewModel>().MaxDepth(2);
            CreateMap<RentStatusTypeViewModel, RentStatusType>().MaxDepth(2);

            CreateMap<Rent, RentViewModel>().MaxDepth(2);
            CreateMap<RentViewModel, Rent>().MaxDepth(2);

            CreateMap<Rent, PostRentViewModel>().MaxDepth(2);
            CreateMap<PostRentViewModel, Rent>().MaxDepth(2);

            //houses
            CreateMap<House, RentHouseViewModel>().MaxDepth(2);
            CreateMap<RentHouseViewModel, House>().MaxDepth(2);

            CreateMap<House, HouseViewModel>().MaxDepth(2);
            CreateMap<HouseViewModel, House>().MaxDepth(2);
            //------

            #endregion Rent

            #region Selling

            CreateMap<SellingStatusType, SellingStatusTypeViewModel>().MaxDepth(2);
            CreateMap<SellingStatusTypeViewModel, SellingStatusType>().MaxDepth(2);

            CreateMap<Selling, SellingViewModel>().MaxDepth(2);
            CreateMap<SellingViewModel, Selling>().MaxDepth(2);

            CreateMap<Selling, PostSellingViewModel>().MaxDepth(2);
            CreateMap<PostSellingViewModel, Selling>().MaxDepth(2);

            CreateMap<Bid, BidViewModel>().MaxDepth(2);
            CreateMap<BidViewModel, Bid>().MaxDepth(2);

            CreateMap<Bid, PostBidViewModel>().MaxDepth(2);
            CreateMap<PostBidViewModel, Bid>().MaxDepth(2);

            #endregion Selling
        }
    }
}
