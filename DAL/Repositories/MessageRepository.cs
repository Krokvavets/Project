using DAL.Interface.DTO;
using DAL.Interface.IRepositories;
using DAL.Interface.Repositories;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public class MessageRepository : IMessageRepository
    {
        private readonly DbContext context;

        public MessageRepository(DbContext uow)
        {
            this.context = uow;
        }

        #region Get operations
        public IEnumerable<DalMessage> GetAll()
        {
            return context.Set<Message>().Select(message => new DalMessage()
            {
                Id = message.Id,
                Footer = message.Footer,
                Note = message.Note,
                Quote = message.Quote,
                UserId = message.UserId,
                Text = message.Text,
                TopicId = message.TopicId,
                CreationDate = message.CreationDate
            });
        }

        public DalMessage GetById(int key)
        {
            var ormmess = context.Set<Message>().FirstOrDefault(e => e.Id == key);
            if (ReferenceEquals(ormmess, null)) return null;
            return new DalMessage()
            {
                Id = ormmess.Id,
                Footer = ormmess.Footer,
                Note = ormmess.Note,
                Quote = ormmess.Quote,
                UserId = ormmess.UserId,
                Text = ormmess.Text,
                TopicId = ormmess.TopicId,
                CreationDate = ormmess.CreationDate
            };
        }

        public DalMessage GetByPredicate(Expression<Func<DalMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Create(DalMessage e)
        {
            var ormmess = new Message()
            {
                Footer = e.Footer,
                Note = e.Note,
                Quote = e.Quote,
                UserId = e.UserId,
                Text = e.Text,
                TopicId = e.TopicId,
                CreationDate = e.CreationDate
            };
            context.Set<Message>().Add(ormmess);
        }

        public void Delete(int id)
        {
            var ormmess = context.Set<Message>().Single(u => u.Id == id);
            context.Set<Message>().Remove(ormmess);
        }

        public void Update(DalMessage e)
        {
            var ormmessage = context.Set<Message>().Single(u => u.Id == e.Id);
            ormmessage.Id = e.Id;
            ormmessage.Note = e.Note;
            ormmessage.Footer = e.Footer;
            ormmessage.Quote = e.Quote;
            ormmessage.UserId = e.UserId;
            ormmessage.Text = e.Text;
            ormmessage.TopicId = e.TopicId;
            ormmessage.CreationDate = e.CreationDate;
            context.Entry(ormmessage).State = EntityState.Modified;
            context.Entry(ormmessage).State = EntityState.Modified;
        }

        public DalMessage GetByText(string text)
        {
            var ormmess = context.Set<Message>().FirstOrDefault(e => e.Text == text);
            if (ReferenceEquals(ormmess, null)) return null;
            return new DalMessage()
            {
                Id = ormmess.Id,
                Footer = ormmess.Footer,
                Note = ormmess.Note,
                Quote = ormmess.Quote,
                UserId = ormmess.UserId,
                Text = ormmess.Text,
                TopicId = ormmess.TopicId,
                CreationDate = ormmess.CreationDate
            };
        }
    }
}
