using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.IRepositories;

namespace BLL.Services
{
    public class PrivateMessageService : IService<PrivateMessageEntity>
    {
        private readonly IUnitOfWork uow;
        private readonly IPrivateMessageRepository privateMessageRepository;

        public PrivateMessageService(IUnitOfWork uow, IPrivateMessageRepository repository)
        {
            this.uow = uow;
            this.privateMessageRepository = repository;
        }

        public void Create(PrivateMessageEntity mess)
        {
            privateMessageRepository.Create(mess.ToDalPrivateMessage());
            uow.Save();
        }

        public void Delete(int id)
        {
            privateMessageRepository.Delete(id);
            uow.Save();
        }

        public IEnumerable<PrivateMessageEntity> GetAll()
        {
            return privateMessageRepository.GetAll().Select(mess => mess.ToBllPrivateMessage());
        }

        public PrivateMessageEntity GetById(int id)
        {
            return privateMessageRepository.GetById(id).ToBllPrivateMessage();
        }

        public void Update(PrivateMessageEntity e)
        {
            privateMessageRepository.Update(e.ToDalPrivateMessage());
        }
    }
}
