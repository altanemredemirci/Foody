using Foody.CORE.Entities;
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
    public class EfCoreCategoryDal : EfCoreGenericRepositoryDal<Category, DataContext>
    {
        private readonly DataContext _context;
        public EfCoreCategoryDal(DataContext context) : base(context)
        {
            _context = context;
        }

        public Category GetByCategoryId(int catId)
        {
            return _context.Categories.Where(i => i.Id == catId).Include(i => i.Products).FirstOrDefault();
        }
    }
}
