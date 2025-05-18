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
	public class EfCoreCartDal:EfCoreGenericRepositoryDal<Cart,DataContext>,ICartDal
	{
		private readonly DataContext _context;
		public EfCoreCartDal(DataContext context) : base(context)
		{
			_context = context;
		}

		public async Task<int> AddToCartAsync(CartItem cartItem)
		{
			var cart = _context.Carts.Include(i=> i.CartItems).FirstOrDefault(i=> i.Id==cartItem.CartId);

			var item = cart.CartItems.FirstOrDefault(i => i.ProductId == cartItem.ProductId);
			
			if (item != null)
			{
				item.Quantity += cartItem.Quantity;
			}
			else
			{
				cart.CartItems.Add(cartItem);
			}

			return await _context.SaveChangesAsync();
		}

		public async Task<Cart> GetCartByUserIdAsync(string userId)
		{
			var cart = await _context.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).ThenInclude(i => i.Images).FirstOrDefaultAsync(i=> i.ApplicationUserId==userId);
			if (cart != null)
				return cart;
			return null;
		}
	}
}
