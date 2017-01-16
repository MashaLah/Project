using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IUserRepository
    {
        IEnumerable<DALUser> GetAllUsers();
        /*bool*/void CreateUser(DALUser user);
        DALUser GetUserByEmail(string email);
        /*bool*/void UpdateUser(DALUser user);
        /*bool*/void RemoveUser(/*int id*/DALUser user);


    }
}
