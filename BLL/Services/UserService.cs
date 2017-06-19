using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.IRepositories;
using BLL.Mappers;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public void AddRole(UserEntity user, RoleEntity role)
        {
            userRepository.AddRole(user.ToDalUser(), role.ToDalRole());
            uow.Save();
        }

        public void Create(UserEntity user, RoleEntity role = null)
        {
            userRepository.Create(user.ToDalUser());
            uow.Save();
            if (role != null)
                AddRole(user, role);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
            uow.Save();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserEntity GetById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }

        /// <summary>
        /// The method create list of roles for input user
        /// </summary>
        /// <param name="user">input user</param>
        /// <returns>list of roles</returns>
        public IEnumerable<RoleEntity> GetRoles(UserEntity user)
        {
            return userRepository.GetRoles(user.ToDalUser()).ToListBll();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email).ToBllUser();
        }

        public void RemoveUserFromRole(UserEntity user, RoleEntity role)
        {
            userRepository.RemoveUserFromRole(user.ToDalUser(), role.ToDalRole());
            uow.Save();
        }

        public void Update(UserEntity e)
        {
            userRepository.Update(e.ToDalUser());
            uow.Save();
        }

        void IService<UserEntity>.Create(UserEntity e)
        {
            Create(e);
        }

    }
}
