using DAL.Interface.DTO;
using DAL.Interface.IRepositories;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DbContext context;

        public TopicRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalTopic> GetAll()
        {
            return context.Set<Topic>().Select(topic => new DalTopic()
            {
                Id = topic.Id,
                Name = topic.Name,
                SectionId = topic.SectionId
            });
        }

        public DalTopic GetById(int key)
        {
            var ormtopic = context.Set<Topic>().FirstOrDefault(Topic => Topic.Id == key);
            return new DalTopic()
            {
                Id = ormtopic.Id,
                Name = ormtopic.Name,
                SectionId = ormtopic.SectionId
            };
        }

        public void Create(DalTopic e)
        {
            if (context.Set<Topic>().FirstOrDefault(en => en.Name == e.Name) != null) return;
            var topic = new Topic()
            {
                Id = e.Id,
                Name = e.Name,
                SectionId = e.SectionId
            };
            context.Set<Topic>().Add(topic);
        }

        public void Delete(int id)
        {
            var ormtopic = context.Set<Topic>().Single(section => section.Id == id);
            context.Set<Topic>().Remove(ormtopic);
        }
        public void Update(DalTopic topic)
        {
            var ormtopic = context.Set<Topic>().Single(e => e.Id == topic.Id);
            if (ormtopic == null) return;
            ormtopic.Id = topic.Id;
            ormtopic.Name = topic.Name;
            ormtopic.SectionId = topic.SectionId;
            context.Entry(ormtopic).State = EntityState.Modified;
        }

        public DalTopic GetByName(string name)
        {
            var ormtopic = context.Set<Topic>().FirstOrDefault(Topic => Topic.Name == name);
            if (ReferenceEquals(ormtopic, null)) return null;
            return new DalTopic()
            {
                Id = ormtopic.Id,
                Name = ormtopic.Name,
                SectionId = ormtopic.SectionId
            };
        }

        public IEnumerable<DalMessage> GetMessages(int topicId)
        {
            List<DalMessage> messages = new List<DalMessage>();
            var ormtopic = context.Set<Topic>().FirstOrDefault(e => e.Id == topicId);
            if (ReferenceEquals(ormtopic, null)) return null;
            var ormmessages = ormtopic.Messages.ToList();
            foreach (var mess in ormmessages)
                messages.Add(new DalMessage()
                {
                    Id = mess.Id,
                    CreationDate = mess.CreationDate,
                    Footer = mess.Footer,
                    Note = mess.Note,
                    Text = mess.Text,
                    Quote = mess.Quote,
                    TopicId = mess.TopicId,
                    UserId = mess.UserId
                });
            return messages;
        }

        public IEnumerable<DalTopic> Search(string name)
        {
            List<DalTopic> topics = new List<DalTopic>();
            var ormtopics = context.Set<Topic>().Where(e => e.Name.Contains(name));
            if (ReferenceEquals(ormtopics, null)) return null;
            foreach (var ormtopic in ormtopics)
                topics.Add(new DalTopic()
                {
                    Id = ormtopic.Id,
                    Name = ormtopic.Name,
                    SectionId = ormtopic.SectionId
                });
            return topics;
        }
    }
}
