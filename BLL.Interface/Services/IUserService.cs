﻿using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        UserEntity GetUserEntityByEmail(string email);
        void UpdateUser(UserEntity user);
        void RemoveUser(UserEntity user);
        void ChangeRole(UserEntity user);
    }
}
