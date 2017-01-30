using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        RoleEntity GetRoleEntityById(int? roleId);
        RoleEntity GetRoleEntityByName(string name);
    }
}
