﻿using AutoMapper;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Address;
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
            CreateMap<Lot, LotViewModel>().MaxDepth(2);
            CreateMap<LotViewModel, Lot>().MaxDepth(2);

            CreateMap<Address, AddressViewModel>().MaxDepth(2);
            CreateMap<AddressViewModel, Address>().MaxDepth(2);

            CreateMap<Bid, BidViewModel>().MaxDepth(2);
            CreateMap<BidViewModel, Bid>().MaxDepth(2);

            CreateMap<AppUser, UserViewModel>().MaxDepth(2);
            CreateMap<UserViewModel, AppUser>().MaxDepth(2);

            CreateMap<Role, RoleViewModel>().MaxDepth(2);
            CreateMap<RoleViewModel, Role>().MaxDepth(2);

            CreateMap<LotStatusType, LotStatusTypeViewModel>().MaxDepth(2);
            CreateMap<LotStatusTypeViewModel, LotStatusType>().MaxDepth(2);

            CreateMap<RentStatusType, RentStatusTypeViewModel>().MaxDepth(2);
            CreateMap<RentStatusTypeViewModel, RentStatusType>().MaxDepth(2);

            CreateMap<SellingStatusType, SellingStatusTypeViewModel>().MaxDepth(2);
            CreateMap<SellingStatusTypeViewModel, SellingStatusType>().MaxDepth(2);

            CreateMap<Selling, SellingViewModel>().MaxDepth(2);
            CreateMap<SellingViewModel, Selling>().MaxDepth(2);

            CreateMap<Selling, PostSellingViewModel>().MaxDepth(2);
            CreateMap<PostSellingViewModel, Selling>().MaxDepth(2);

            CreateMap<Address, PostAddressViewModel>().MaxDepth(2);
            CreateMap<PostAddressViewModel, Address>().MaxDepth(2);
            
        }
    }
}
