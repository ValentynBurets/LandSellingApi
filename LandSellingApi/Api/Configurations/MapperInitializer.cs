using AutoMapper;
using Business.Contract.Model;
using Data.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Configurations
{ 
     public class MapperInitializer : Profile
     {
           public MapperInitializer()
            {   
                CreateMap<AuthorisationUser, RegisterUserModel>().ReverseMap();

            }
     }

}