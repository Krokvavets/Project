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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public void Create(RoleEntity role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Save();
        }
        public void Create(string name)
        {
            if (String.IsNullOrEmpty(name)) return;
            Create(new RoleEntity() { Name = name });
        }

        public void Delete(int id)
        {
            roleRepository.Delete(id);
            uow.Save();
        }

        public RoleEntity GetByName(string name)
        {
            return roleRepository.GetByName(name).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public RoleEntity GetById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }

        public void Update(RoleEntity e)
        {
            roleRepository.Update(e.ToDalRole());
        }

        public List<string> GetNames(IEnumerable<RoleEntity> roles)
        {
            List<string> list = new List<string>();
            foreach (var element in roles)
                list.Add(element.Name);
            return list;
        }
    }
}
