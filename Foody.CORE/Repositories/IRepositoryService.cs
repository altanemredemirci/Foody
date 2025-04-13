using Foody.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.CORE.Repositories
{
    public interface IRepositoryService<T>
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetOne(int id);
        int Create(T entity);
        int Update();
        int Delete(int id);
    }
}
