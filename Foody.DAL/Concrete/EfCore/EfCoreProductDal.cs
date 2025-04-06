using Foody.CORE.Entities;
using Foody.DAL.Abstract;
using Foody.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepositoryDal<Product, DataContext>,IProductDal
    {
        private readonly DataContext _context;

        public EfCoreProductDal(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}
