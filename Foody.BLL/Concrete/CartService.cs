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
	public class CartService : ICartService
	{
		private readonly ICartDal _cartDal;

		public CartService(ICartDal cartDal)
		{
			_cartDal = cartDal;
		}

		public async Task<int> AddToCartAsync(CartItem cartItem)
		{
			return await _cartDal.AddToCartAsync(cartItem);
		}

		public int Create(Cart entity)
		{
			return _cartDal.Create(entity);
		}

		public int Delete(int id)
		{
			return _cartDal.Delete(id);

		}

		public List<Cart> GetAll(Expression<Func<Cart, bool>> filter = null)
		{
			return _cartDal.GetAll(filter);

		}

		public Task<Cart> GetCartByUserIdAsync(string userId)
		{
			return _cartDal.GetCartByUserIdAsync(userId);
		}

		public Cart GetOne(int id)
		{
			return _cartDal.GetOne(id);

		}

		public int Update()
		{
			return _cartDal.Update();

		}
	}
}
