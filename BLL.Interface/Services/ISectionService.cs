using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ISectionService: IService<SectionEntity>
    {
        IEnumerable<TopicEntity> GetTopics(int id);
        void AddTopic(int id, TopicEntity topic);
    }
}
