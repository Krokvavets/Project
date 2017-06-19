using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IRepositories
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetByName(string name);
        IEnumerable<DalUser> GetUsers(DalRole role);
    }
}
