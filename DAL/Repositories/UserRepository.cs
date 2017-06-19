using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interface.IRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }
        #region Get operarions

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Nickname = user.Nickname,
                Password = user.Password,
                Photo = user.Photo,
                CreationDate = user.CreationDate,
                NumberOfPosts = user.NumberOfPosts,
                AboutMe = user.AboutMe
            });
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            if (ReferenceEquals(ormuser, null)) return null;
            return new DalUser()
            {
                Id = ormuser.Id,
                Email = ormuser.Email,
                FirstName = ormuser.FirstName,
                LastName = ormuser.LastName,
                Nickname = ormuser.Nickname,
                Password = ormuser.Password,
                Photo = ormuser.Photo,
                CreationDate = ormuser.CreationDate,
                NumberOfPosts = ormuser.NumberOfPosts,
                AboutMe = ormuser.AboutMe
            };
        }

        /// <summary>
        /// The method Finds a user by email
        /// </summary>
        /// <param name="email">Input email</param>
        /// <returns>User</returns>
        public DalUser GetUserByEmail(string email)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Email == email);
            if (ReferenceEquals(ormuser, null)) return null;
            return new DalUser()
            {
                Id = ormuser.Id,
                Email = ormuser.Email,
                FirstName = ormuser.FirstName,
                LastName = ormuser.LastName,
                Nickname = ormuser.Nickname,
                Password = ormuser.Password,
                Photo = ormuser.Photo,
                CreationDate = ormuser.CreationDate,
                NumberOfPosts = ormuser.NumberOfPosts,
                AboutMe = ormuser.AboutMe
            };
        }
        #endregion

        #region CDU operations
        public void Create(DalUser user)
        {
            if (ReferenceEquals(user.Nickname, null)) user.Nickname = user.FirstName;
            var ormuser = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Nickname = user.Nickname,
                Password = user.Password,
                Photo = user.Photo,
                CreationDate = user.CreationDate,
                NumberOfPosts = user.NumberOfPosts,
                AboutMe = user.AboutMe
            };

            context.Set<User>().Add(ormuser);
        }

        public void Delete(int id)
        {
            var ormuser = context.Set<User>().Single(u => u.Id == id);
            if (ormuser == null) return;
            context.Set<User>().Remove(ormuser);
        }

        public void Update(DalUser user)
        {
            var ormuser = context.Set<User>().Single(u => u.Id == user.Id);
            ormuser.Email = user.Email;
            ormuser.FirstName = user.FirstName;
            ormuser.LastName = user.LastName;
            ormuser.Nickname = user.Nickname;
            ormuser.Password = user.Password;
            ormuser.Photo = user.Photo;
            ormuser.CreationDate = user.CreationDate;
            ormuser.NumberOfPosts = user.NumberOfPosts;
            ormuser.AboutMe = user.AboutMe;
            context.Entry(ormuser).State = EntityState.Modified;
        }
        #endregion

        /// <summary>
        /// The method adds input role to intput user
        /// </summary>
        /// <param name="user">input user</param>
        /// <param name="role">input role</param>
        public void AddRole(DalUser user, DalRole role)
        {
            var ormuser = context.Set<User>().FirstOrDefault(e => e.Email == user.Email);
            var ormrole = context.Set<Role>().FirstOrDefault(e => e.Name == role.Name);
            if (ormrole.Users == null)
                ormrole.Users = new List<User> { ormuser };
            else
                ormrole.Users.Add(ormuser);
        }

        public void AddMessage(DalUser user, DalMessage message)
        {
            throw new NotImplementedException();
        }

        public void AddPrivateMessage(DalUser user, DalPrivateMessage message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetRoles(DalUser user)
        {
            List<DalRole> roles = new List<DalRole>();
            var ormuser = context.Set<User>().FirstOrDefault(e => e.Id == user.Id);
            if (ReferenceEquals(ormuser, null)) return null;
            var ormroles = ormuser.Roles.ToList();
            foreach (var role in ormroles)
                roles.Add(new DalRole() { Id = role.Id, Name = role.Name });
            return roles;
        }


        public IEnumerable<DalMessage> GetMessage(DalUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromRole(DalUser user, DalRole role)
        {
            var ormuser = context.Set<User>().FirstOrDefault(e => e.Id == user.Id);
            ormuser.Roles.Remove(ormuser.Roles.FirstOrDefault(e => e.Id == role.Id));
        }
    }
}
