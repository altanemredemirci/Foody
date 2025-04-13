using Foody.CORE.Entities;
using Foody.DAL.Abstract;
using Foody.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Concrete.EfCore
{
    public class EfCoreAboutDal : IAboutDal
    {
        private readonly DataContext _context;

        public EfCoreAboutDal(DataContext context)
        {
            _context = context;
        }

        public About GetOne()
        {
            return _context.Abouts.Find(1);
        }
    }
}
