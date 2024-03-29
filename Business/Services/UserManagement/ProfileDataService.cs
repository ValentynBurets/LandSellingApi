﻿using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Services.Authentication;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Authentication
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IAuthentificationUnitOfWork _unitOfWork;
        private readonly IProfileManager _profileManager;
        private readonly IMapper _mapper;

        public ProfileDataService(IAuthentificationUnitOfWork unitOfWork, IMapper mapper, IProfileManager profileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _profileManager = profileManager;
        }

        public async Task<UserInfoViewModel> GetUserProfileInfoByIdLink(Guid idLink)
        {
            var customer = await _unitOfWork.UserRepository.FirstOrDefault(x => x.IdLink == idLink);
            var email = await _profileManager.GetEmailByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, UserInfoViewModel>(customer);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task<UserInfoViewModel> GetUserProfileInfoById(Guid id)
        {
            var idLink = await _unitOfWork.UserRepository.GeIdLinkById(id);
            var customer = await _unitOfWork.UserRepository.FirstOrDefault(x => x.Id == idLink);
            var email = await _profileManager.GetEmailByUserId(idLink);
            var phoneNumber = await _profileManager.GetPhoneNumberByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, UserInfoViewModel>(customer);
            profileInfo.Email = email;
            profileInfo.PhoneNumber = phoneNumber;

            return profileInfo;
        }

        public async Task<UserInfoViewModel> GetAdminProfileInfoById(Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.FirstOrDefault(x => x.IdLink == id);
            var email = await _profileManager.GetEmailByUserId(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            var profileInfo = _mapper.Map<Admin, UserInfoViewModel>(admin);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task UpdateCustomerProfileInfoById(ProfileInfoModel model, Guid id)
        {
            var student = await _unitOfWork.UserRepository.GetById(id);

            if (student == null)
            {
                throw new Exception("Employee with this id was not found!");
            }

            student.Name = model.Name;
            student.SurName = model.SurName;

            await _unitOfWork.Save();
        }

        public async Task UpdateAdminProfileInfoById(ProfileInfoModel model, Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.GetById(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            admin.Name = model.Name;
            admin.SurName = model.SurName;

            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<UserInfoViewModel>> GetAllUsersInfo()
        {
            List<UserInfoViewModel> userList = new List<UserInfoViewModel>();

            var users = (await _unitOfWork.UserRepository.GetAll()).ToList();

            if (users == null)
            {
                throw new Exception("Customer not found!");
            }

            foreach (var item in users)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<User, UserInfoViewModel>(item);
                user.Email = email;
                userList.Add(user);
            }

            var admins = (await _unitOfWork.AdminRepository.GetAll()).ToList();

            if (admins == null)
            {
                throw new Exception("Admins not found!");
            }

            foreach (var item in admins)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<Admin, UserInfoViewModel>(item);
                user.Email = email;
                userList.Add(user);
            }

            return userList;
        }

        public async Task<string> GetRole(Guid userId)
        {
            var tempUser = await _unitOfWork.UserRepository.GetById(userId);
            var user = _mapper.Map<User, UserInfoViewModel>(tempUser);
            return user.Role;
        }
    }
}
