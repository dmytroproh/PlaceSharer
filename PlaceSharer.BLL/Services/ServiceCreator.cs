﻿using System;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.DAL.Repositories;

namespace PlaceSharer.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}