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
    public class EfCoreOrderDal:EfCoreGenericRepositoryDal<Order, DataContext>, IOrderDal
    {
        private readonly DataContext _context;
        public EfCoreOrderDal(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
