using Foody.CORE.Entities;
using Foody.DAL.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Concrete
{
    public class ProductService
    {
        /// <summary>
        /// Injection: Farklı bir projedeki yapıyı içeriye dahil etme(enjekte)
        /// </summary>
        private readonly EfCoreProductDal _efCoreProductDal;

        public ProductService(EfCoreProductDal efCoreProductDal)
        {
            _efCoreProductDal = efCoreProductDal;
        }

        public List<Product> List()
        {
            return _efCoreProductDal.List();
        }

    }
}
