using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService 
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            userRepository = repository;
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAllUsers().Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.CreateUser(user.ToDalUser());
            uow.Commit();
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            var user = userRepository.GetUserByEmail(email);
            if (ReferenceEquals(user, null)) return null;
            //return userRepository.GetUserByEmail(email).ToBllUser();
            return user.ToBllUser();

            //return null;
        }

        public void RemoveUser(UserEntity user)
        {
            userRepository.RemoveUser(user.ToDalUser());
            uow.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            userRepository.UpdateUser(user.ToDalUser());
            uow.Commit();
        }

        public void ChangeRole(UserEntity user)
        {
            userRepository.ChangeRole(user.ToDalUser());
            uow.Commit();
        }
    }
}
