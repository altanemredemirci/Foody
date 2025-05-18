using Foody.CORE.Entities;
using Foody.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Abstract
{
	public interface ICartService : IRepositoryService<Cart>
	{
		Task<int> AddToCartAsync(CartItem cartItem);
		Task<Cart> GetCartByUserIdAsync(string userId);
	}
}
