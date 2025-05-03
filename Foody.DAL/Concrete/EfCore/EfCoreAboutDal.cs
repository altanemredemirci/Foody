using Foody.CORE.Entities;
using Foody.CORE.Repositories;
using Foody.DAL.Abstract;
using Foody.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Concrete.EfCore
{
    public class EfCoreAboutDal : EfCoreGenericRepositoryDal<About, DataContext>,IAboutDal
    {
        private readonly DataContext _context;

        public EfCoreAboutDal(DataContext context):base(context)
        {
            _context = context;
        }
               
    }
}
