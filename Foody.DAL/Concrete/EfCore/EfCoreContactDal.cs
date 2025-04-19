using Foody.CORE.Entities;
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
    public class EfCoreContactDal : IContactDal
    {
        private readonly DataContext _context;

        public EfCoreContactDal(DataContext context)
        {
            _context = context;
        }

        public Contact GetById()
        {
            return _context.Contacts.Find(1);
        }
    }
}
