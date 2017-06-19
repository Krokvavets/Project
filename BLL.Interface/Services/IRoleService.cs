using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IRoleService : IService<RoleEntity>
    {
        void Create(string name);
        RoleEntity GetByName(string name);
        List<string> GetNames(IEnumerable<RoleEntity> roles);
    }
}
