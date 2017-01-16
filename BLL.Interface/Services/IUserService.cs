using BLL.Interface.Entities;
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
        /*bool*/
        void CreateUser(UserEntity user);
        UserEntity GetUserEntityByEmail(string email);
        /*bool*/
        void UpdateUser(UserEntity user);
        /*bool*/
        void RemoveUser(/*int id*/UserEntity user);
    }
}
