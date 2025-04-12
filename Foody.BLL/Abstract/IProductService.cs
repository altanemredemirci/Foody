using Foody.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product GetOne(int id);
        int Create(Product entity);
        int Update();
        int Delete(int id);

    }
}
