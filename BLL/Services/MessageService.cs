using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.IRepositories;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using System;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork uow;
        private readonly IMessageRepository messageRepository;
        private readonly IUserService service;

        public MessageService(IUnitOfWork uow, IMessageRepository repository, IUserService service)
        {
            this.uow = uow;
            this.messageRepository = repository;
            this.service = service;
        }

        public void Create(MessageEntity mess)
        {
            if (ReferenceEquals(mess, null)) return;
            messageRepository.Create(mess.ToDalMessage());
            UserEntity user = service.GetById(mess.UserId);
            user.NumberOfPosts++;
            service.Update(user);
            if (ReferenceEquals(user, null)) return;
            uow.Save();
        }

        public void Delete(int id)
        {
            messageRepository.Delete(id);
            uow.Save();
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return messageRepository.GetAll().Select(mess => mess.ToBllMessage());
        }

        public MessageEntity GetById(int id)
        {
            return messageRepository.GetById(id).ToBllMessage();
        }

        public MessageEntity GetByText(string text)
        {
            return messageRepository.GetByText(text).ToBllMessage();
        }

        public void Update(MessageEntity e)
        {
            messageRepository.Update(e.ToDalMessage());
            uow.Save();
        }
    }
}
