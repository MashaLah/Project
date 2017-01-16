using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService 
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            roleRepository = repository;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAllRoles().Select(role => role.ToBllRole());
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.CreateNewRole(role.ToDalRole());
            uow.Commit();
        }

        public RoleEntity GetRoleEntityById(int? id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }

        public RoleEntity GetRoleEntityByName(string name)
        {
            return roleRepository.GetByName(name).ToBllRole();
        }
    }
}
