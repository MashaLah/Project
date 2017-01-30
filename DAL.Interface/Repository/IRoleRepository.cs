using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<DALRole> GetAllRoles();
        void CreateNewRole(DALRole role);
        DALRole GetById(int? roleId);
        DALRole GetByName(string name);
    }
}
