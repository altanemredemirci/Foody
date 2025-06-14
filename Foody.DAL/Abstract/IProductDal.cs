using Foody.CORE.Entities;
using Foody.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Abstract
{
    public interface IProductDal : IRepositoryService<Product>
    {
        int Update(Product updateProduct,List<Image> images);
    }
}
