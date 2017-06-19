using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
           => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {

            var user = UserService.GetAll().FirstOrDefault(u => u.Email == email);

            if (user == null) return false;

            var userRoles = UserService.GetRoles(user);
            foreach(var userRole in userRoles)
            {
                if (userRole != null && userRole.Name == roleName)
                {
                    return true;
                }
            }

            return false;
        }
        public override string[] GetRolesForUser(string email)
        {
            if (ReferenceEquals(UserService.GetUserByEmail(email), null)) return null;
            var roles = UserService.GetRoles(UserService.GetUserByEmail(email));
            if (ReferenceEquals(roles, null)) return null;
            string [] arrayRoles = new string[roles.Count()];
            int i = 0;
            foreach (var role in roles)
            {
                arrayRoles[i] = role.Name;
                i++;
            }
                return arrayRoles;
        }

        public void SetOrRemoveRole(ProfileViewModel model)
        {
            if (model.Administrator == false && IsUserInRole(model.Email, "Administrator"))
                UserService.RemoveUserFromRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("Administrator"));
            if (model.Administrator == true && !IsUserInRole(model.Email, "Administrator"))
                UserService.AddRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("Administrator"));
            if (model.Moderator == false && IsUserInRole(model.Email, "Moderator"))
                UserService.RemoveUserFromRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("Moderator"));
            if (model.Moderator == true && !IsUserInRole(model.Email, "Moderator"))
                UserService.AddRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("Moderator"));
            if (model.User == false && IsUserInRole(model.Email, "User"))
                UserService.RemoveUserFromRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("User"));
            if (model.User == true && !IsUserInRole(model.Email, "User"))
                UserService.AddRole(UserService.GetUserByEmail(model.Email), RoleService.GetByName("User"));
        }

        public override void CreateRole(string roleName)
        {
            RoleService.Create(roleName);
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