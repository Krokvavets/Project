using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IRepositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        void AddRole(DalUser user, DalRole role);
        void AddMessage(DalUser user, DalMessage message);
        void AddPrivateMessage(DalUser user, DalPrivateMessage message);
        IEnumerable<DalRole> GetRoles(DalUser user);
        IEnumerable<DalMessage> GetMessage(DalUser user);
        DalUser GetUserByEmail(string email);
        void RemoveUserFromRole(DalUser user, DalRole role);
    }
}
