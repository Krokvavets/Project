using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ORM;
using DAL.Interface.IRepositories;

namespace DAL.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DbContext context;

        public SectionRepository(DbContext uow)
        {
            this.context = uow;
        }
        #region Get operations
        public IEnumerable<DalSection> GetAll()
        {
            return context.Set<Section>().Select(section => new DalSection()
            {
                Id = section.Id,
                Name = section.Name,
            });
        }

        public DalSection GetById(int key)
        {
            var ormsection = context.Set<Section>().FirstOrDefault(section => section.Id == key);
            if (ormsection == null) return null;
            return new DalSection()
            {
                Id = ormsection.Id,
                Name = ormsection.Name,
            };
        }

        public DalSection GetByPredicate(System.Linq.Expressions.Expression<Func<DalSection, bool>> filter)
        {
            throw new NotImplementedException();
        }
        #endregion
        public void Create(DalSection e)
        {
            var section = new Section()
            {
                Id = e.Id,
                Name = e.Name
            };
            context.Set<Section>().Add(section);
        }

        public void Delete(int id)
        {
            var ormsection = context.Set<Section>().Single(e => e.Id == id);
            if (ormsection == null) return;
            context.Set<Section>().Remove(ormsection);
        }

        public void Update(DalSection section)
        {
            var ormsection = context.Set<Section>().Single(otherSection => otherSection.Id == section.Id);
            ormsection.Id = section.Id;
            ormsection.Name = section.Name;
            context.Entry(ormsection).State = EntityState.Modified;
        }

        public DalSection GetByName(string name)
        {
            var ormsection = context.Set<Section>().FirstOrDefault(section => section.Name == name);
            if (ormsection == null) return null;
            return new DalSection()
            {
                Id = ormsection.Id,
                Name = ormsection.Name,
            };
        }

        public IEnumerable<DalTopic> GetTopics(int id)
        {
            List<DalTopic> topics = new List<DalTopic>();
            var ormsection = context.Set<Section>().FirstOrDefault(section => section.Id == id);
            if (ReferenceEquals(ormsection, null)) return null;
            var ormtopics = ormsection.Topics.ToList();
            foreach (var topic in ormtopics)
                topics.Add(new DalTopic() { Id = topic.Id, Name = topic.Name, SectionId = topic.SectionId});
            return topics;

        }

        public void AddTopic(int id, DalTopic topic)
        {
            var ormsection = context.Set<Section>().FirstOrDefault(section => section.Id == id);
            if (ReferenceEquals(ormsection, null)) return;
            ormsection.Topics.Add(new Topic() { Id = topic.Id, Name = topic.Name, SectionId = id});
        }
    }
}
