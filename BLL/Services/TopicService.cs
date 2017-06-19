using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork uow;
        private readonly ITopicRepository topicRepository;

        public TopicService(IUnitOfWork uow, ITopicRepository repository)
        {
            this.uow = uow;
            this.topicRepository = repository;
        }

        public void Create(TopicEntity topic)
        {
            topicRepository.Create(topic.ToDalTopic());
            uow.Save();
        }

        public void Delete(int id)
        {
            topicRepository.Delete(id);
            uow.Save();
        }

        public IEnumerable<TopicEntity> GetAll()
        {
            return topicRepository.GetAll().Select(topic => topic.ToBllTopic());
        }

        public TopicEntity GetById(int id)
        {
            return topicRepository.GetById(id).ToBllTopic();
        }

        public TopicEntity GetByName(string name)
        {
            return topicRepository.GetByName(name).ToBllTopic();
        }

        public IEnumerable<MessageEntity> GetMessages(int topicId)
        {
            return topicRepository.GetMessages(topicId).ToBllMessageList();
        }

        public IEnumerable<TopicEntity> Search(string name)
        {
            return topicRepository.Search(name).ToBllTopicList();
        }

        public void Update(TopicEntity e)
        {
            topicRepository.Update(e.ToDalTopic());
            uow.Save();
        }
    }
}
