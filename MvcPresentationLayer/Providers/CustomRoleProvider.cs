using BLL.Interface.Entities;
using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcPresentationLayer.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
        => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
          => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {

            UserEntity user = UserService.GetUserEntityByEmail(email);

            if (user == null) return false;

            RoleEntity userRole = RoleService.GetRoleEntityById(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {

            var roles = new string[] { };
            var user = UserService.GetUserEntityByEmail(email);
            if (user == null) return roles;

            int roleId = user.RoleId;
            var userRole = RoleService.GetRoleEntityById(roleId);

            if (userRole != null) 
            {
                roles = new string[] { userRole.Name };
            }
            return roles;
            
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { Name = roleName };
            RoleService.CreateRole(newRole);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    
}
}