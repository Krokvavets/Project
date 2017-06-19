using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserService : IService<UserEntity>
    {
        void AddRole(UserEntity user, RoleEntity role);
        void Create(UserEntity user, RoleEntity role = null);
        UserEntity GetUserByEmail(string email);
        IEnumerable<RoleEntity> GetRoles(UserEntity user);
        void RemoveUserFromRole(UserEntity user, RoleEntity role);
    }
}
