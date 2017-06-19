using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IRepositories
{
    public interface ITopicRepository: IRepository<DalTopic>
    {
        DalTopic GetByName(string name);
        IEnumerable<DalMessage> GetMessages(int topicId);
        IEnumerable<DalTopic> Search(string name);
    }
}
