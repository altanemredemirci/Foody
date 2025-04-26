using Foody.BLL.Abstract;
using Foody.CORE.Entities;
using Foody.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Concrete
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Injection: Farklı bir projedeki yapıyı içeriye dahil etme(enjekte)
        /// </summary>
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }

        public Product GetOne(int id)
        {
            return _productDal.GetOne(id);
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
