using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ITopicService: IService<TopicEntity>
    {
        TopicEntity GetByName(string name);
        IEnumerable<MessageEntity> GetMessages(int topicId);
        IEnumerable<TopicEntity> Search(string name);
    }
}
