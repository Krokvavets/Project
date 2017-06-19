using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.IRepositories
{
    public interface ISectionRepository : IRepository<DalSection>
    {
        DalSection GetByName(string name);
        IEnumerable<DalTopic> GetTopics(int id);
        void AddTopic(int id, DalTopic topic);
    }
}
