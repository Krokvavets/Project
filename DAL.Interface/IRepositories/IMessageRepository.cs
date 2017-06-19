using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IRepositories
{
    public interface IMessageRepository : IRepository<DalMessage>
    {
        DalMessage GetByText(string text);
    }
}
