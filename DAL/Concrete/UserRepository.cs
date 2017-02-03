using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository 
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALUser> GetAllUsers()
        {
            return context.Set<User>().Select(user => new DALUser()
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                IsBanned=user.IsBanned
            });
        }

        public void CreateUser(DALUser user)
        {
            /*var newUser = new User()
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                IsBanned=user.IsBanned
            };*/
            context.Set<User>().Add(user.ToOrmUser());
        }

        public DALUser GetUserByEmail(string email)
        {
            if (context.Set<User>().Any(u => u.Email == email) == false) return null;
            var ormUser = context.Set<User>().FirstOrDefault(u => u.Email == email);
            if (ormUser == null) return null;
            /*DALUser dalUser = new DALUser()
            {
                Id = ormUser.Id,
                Password = ormUser.Password,
                Email = ormUser.Email,
                CreationDate = ormUser.CreationDate,
                RoleId = ormUser.RoleId,
                IsBanned=ormUser.IsBanned
            };
            if (ormUser.Profiles.FirstOrDefault() != null)
                dalUser.Profile = ormUser.Profiles.FirstOrDefault().ToDalProfile();
            return dalUser;*/
            return ormUser.ToDalUser();
        }

        public void UpdateUser(DALUser user)
        {
            var updatedUser = context.Set<User>().FirstOrDefault(u => u.Id == user.Id);

            updatedUser.Id = user.Id;
            updatedUser.Password = user.Password;
            updatedUser.Email = user.Email;
            updatedUser.CreationDate = user.CreationDate;
            updatedUser.RoleId = user.RoleId;
            updatedUser.IsBanned = user.IsBanned;
        }

        public void RemoveUser(DALUser user)
        {
           /* var userToRemove = new User()
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                IsBanned=user.IsBanned
            };*/
            var userToRemove = context.Set<User>().FirstOrDefault(frm => frm.Id == user.Id);
            context.Set<User>().Remove(userToRemove);
        }
    }
}
