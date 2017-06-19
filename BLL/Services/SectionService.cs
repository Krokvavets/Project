using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork uow;
        private readonly ISectionRepository sectionRepository;

        public SectionService(IUnitOfWork uow, ISectionRepository repository)
        {
            this.uow = uow;
            this.sectionRepository = repository;
        }

        public void AddTopic(int id, TopicEntity topic)
        {
            sectionRepository.AddTopic(id, topic.ToDalTopic());
            uow.Save();
        }

        public void Create(SectionEntity section)
        {
            if (sectionRepository.GetById(section.Id) != null) return;
            sectionRepository.Create(section.ToDalSection());
            uow.Save();
        }

        public void Delete(int id)
        {
            sectionRepository.Delete(id);
            uow.Save();
        }

        public IEnumerable<SectionEntity> GetAll()
        {
            return sectionRepository.GetAll().Select(section => section.ToBllSection());
        }

        public SectionEntity GetById(int id)
        {
            return sectionRepository.GetById(id).ToBllSection();
        }

        public IEnumerable<TopicEntity> GetTopics(int id)
        {
            return sectionRepository.GetTopics(id).ToBllTopicList();
        }

        public void Update(SectionEntity e)
        {
            if (sectionRepository.GetByName(e.Name) != null) return;
            sectionRepository.Update(e.ToDalSection());
            uow.Save();
        }
    }
}
