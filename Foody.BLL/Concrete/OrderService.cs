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
    public class OrderService : IOrderService
    {
        public readonly IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int Create(Order entity)
        {
            return _orderDal.Create(entity);
        }

        public int Delete(int id)
        {
            return _orderDal.Delete(id);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetAll(filter);
        }

        public Order GetOne(int id)
        {
            return _orderDal.GetOne(id);
        }

        public int Update()
        {
           return _orderDal.Update();
        }
    }
}
