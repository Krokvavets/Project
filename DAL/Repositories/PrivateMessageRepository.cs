using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using ORM;
using DAL.Interface.IRepositories;

namespace DAL.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly DbContext context;

        public PrivateMessageRepository(DbContext uow)
        {
            this.context = uow;
        }
        #region Get operations
        public IEnumerable<DalPrivateMessage> GetAll()
        {
            return context.Set<PrivateMessage>().Select(message => new DalPrivateMessage()
            {
                Id = message.Id,
                Preview = message.Preview,
                RecipientId = message.RecipientId,
                SenderId = message.SenderId,
                Status = message.Status,
                Text = message.Text
            });
        }

        public DalPrivateMessage GetById(int key)
        {
            var ormmess = context.Set<PrivateMessage>().FirstOrDefault(user => user.Id == key);
            return new DalPrivateMessage()
            {
                Id = ormmess.Id,
                Preview = ormmess.Preview,
                RecipientId = ormmess.RecipientId,
                SenderId = ormmess.SenderId,
                Status = ormmess.Status,
                Text = ormmess.Text
            };            
        }

        public DalPrivateMessage GetByPredicate(Expression<Func<DalPrivateMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Create(DalPrivateMessage e)
        {
            var ormmess = new PrivateMessage()
            {
                Id = e.Id,
                Preview = e.Preview,
                RecipientId = e.RecipientId,
                SenderId = e.SenderId,
                Status = e.Status,
                Text = e.Text
            };
            context.Set<PrivateMessage>().Add(ormmess);
        }

        public void Delete(int id)
        {
            var ormmess= context.Set<PrivateMessage>().Single(u => u.Id == id);
            context.Set<PrivateMessage>().Remove(ormmess);
        }

        public void Update(DalPrivateMessage e)
        {
            var ormmessage = context.Set<PrivateMessage>().Single(u => u.Id == e.Id);
            ormmessage.Id = e.Id;
            ormmessage.Preview = e.Preview;
            ormmessage.RecipientId = e.RecipientId;
            ormmessage.SenderId = e.SenderId;
            ormmessage.Status = e.Status;
            ormmessage.Text = e.Text;
            context.Entry(ormmessage).State = EntityState.Modified;
        }
    }
}
