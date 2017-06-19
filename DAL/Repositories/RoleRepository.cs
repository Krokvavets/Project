using DAL.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Linq.Expressions;
using System.Data.Entity;
using ORM;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;
        
        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        #region Get
        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
            });
        }

        public DalRole GetById(int key)
        {
            var ormrole = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            if (ReferenceEquals(ormrole, null)) return null;
            return new DalRole()
            {
                Id = ormrole.Id,
                Name = ormrole.Name
            };
        }

        /// <summary>
        /// The method Finds a role by name
        /// </summary>
        /// <param name="name">name of role</param>
        /// <returns>role</returns>
        public DalRole GetByName(string name)
        {
            var ormrole = context.Set<Role>().FirstOrDefault(user => user.Name == name);
            if (ReferenceEquals(ormrole, null)) return null;
            return new DalRole()
            {
                Id = ormrole.Id,
                Name = ormrole.Name
            };
        }
        #endregion

        public void Create(DalRole e)
        {
            var ormrole = new Role()
            {
                Id = e.Id,
                Name = e.Name
            };
            context.Set<Role>().Add(ormrole);
        }

        public void Delete(int id)
        {
            var ormrole = context.Set<Role>().Single(u => u.Id == id);
            context.Set<Role>().Remove(ormrole);
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<DalUser> GetUsers(DalRole role)
        {
            UserRepository ur = new UserRepository(context);
            List<DalUser> users = new List<DalUser>();
            var ormrole = context.Set<Role>().FirstOrDefault(e => e.Id == role.Id);
            var ormusers = context.Set<User>().Where(e => e.Roles.Contains( ormrole));
            foreach (var user in ormusers)
                users.Add(ur.GetById(user.Id));
            return users;
        }

        public void Update(DalRole e)
        {
            var ormrole = context.Set<Role>().Single(u => u.Id == e.Id);
            ormrole.Id = e.Id;
            ormrole.Name = e.Name;
            context.Entry(ormrole).State = EntityState.Modified;
        }
    }
}
