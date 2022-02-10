﻿using Data.Identity.Repository.Base;
using Domain.Entity.Users;

namespace Data.Contract.Repository.Authentication
{
    internal interface IManagerRepository : IEntityRepository<Manager>
    {
    }
}