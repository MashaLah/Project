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
        void CreateUser(DALUser user);
        DALUser GetUserByEmail(string email);
        void UpdateUser(DALUser user);
        void RemoveUser(DALUser user);
        void ChangeRole(DALUser user);

    }
}
