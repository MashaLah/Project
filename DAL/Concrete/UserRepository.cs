using DAL.Interface.DTO;
using DAL.Interface.Repository;
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
                //Image = user.Image,
                RoleId = user.RoleId,

            });
        }

        public /*bool*/void CreateUser(DALUser user)
        {
            /* if (user.Id != 0) return false;
             context.Users.Add(user);
             context.SaveChanges();
             return true;*/
            var newUser = new User()
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                CreationDate = user.CreationDate,
                //Image = user.Image,
                RoleId = user.RoleId
            };
            context.Set<User>().Add(newUser);
        }

        public DALUser GetUserByEmail(string email)
        {
            if (context.Set<User>().Any(u => u.Email == email) == true) return null;
            var ormUser = context.Set<User>().FirstOrDefault(u => u.Email == email);
            //if (ormUser == null) return null;
            return new DALUser()
            {
                Id = ormUser.Id,
                Password = ormUser.Password,
                Email = ormUser.Email,
                CreationDate = ormUser.CreationDate,
                //Image = user.Image,
                RoleId = ormUser.RoleId
            };
            //return null;
        }

        public /*bool*/void UpdateUser(DALUser user)
        {
            var updatedUser = context.Set<User>().FirstOrDefault(u => u.Id == user.Id);

            updatedUser.Id = user.Id;
            updatedUser.Password = user.Password;
            updatedUser.Email = user.Email;
            updatedUser.CreationDate = user.CreationDate;
            //Image = user.Image,
            updatedUser.RoleId = user.RoleId;
        }

        public /*bool*/void RemoveUser(/*int id*/DALUser user)
        {
            /*User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;*/
            var userToRemove = new User()
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                CreationDate = user.CreationDate,
                //Image = user.Image,
                RoleId = user.RoleId
            };
            userToRemove = context.Set<User>().FirstOrDefault(frm => frm.Id == user.Id);
            context.Set<User>().Remove(userToRemove);
        }
    }
}
