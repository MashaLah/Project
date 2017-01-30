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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            context = uow;
        }

        public void CreateNewRole(DALRole role)
        {
            var newRole = new Role()
            {
                Name = role.Name,
            };
            context.Set<Role>().Add(newRole);
        }

        public IEnumerable<DALRole> GetAllRoles()
        {
            return context.Set<Role>().Select(role => new DALRole()
            {
                Id = role.Id,
                Name = role.Name,
            });
        }

        public DALRole GetById(int? roleId)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(r => r.Id == roleId);
            return new DALRole()
            {
                Id = ormRole.Id,
                Name = ormRole.Name,
            };
        }

        public DALRole GetByName(string name)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(r => r.Name == name);
            return new DALRole()
            {
                Id = ormRole.Id,
                Name = ormRole.Name,
            };
        }
    }
}
