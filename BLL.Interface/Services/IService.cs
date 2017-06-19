using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IService<TEntity> where TEntity : class 
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity e);
        void Delete(int id);
        void Update(TEntity e);
    }
}
