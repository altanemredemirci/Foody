using Foody.BLL.Abstract;
using Foody.CORE.Entities;
using Foody.CORE.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foody.WEBUI.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly ICartService _cartService;
		private readonly IProductService _productService;
		private readonly UserManager<ApplicationUser> _userManager;

		public CartController(ICartService cartService,IProductService productService,UserManager<ApplicationUser> userManager)
		{
			_cartService = cartService;
			_productService = productService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var cart = await _cartService.GetCartByUserIdAsync(_userManager.GetUserId(User));

			return View(cart);
		}


		public async Task<IActionResult> AddToCart(int quantity, int productId,int stock=1)
		{
			var product = _productService.GetOne(productId);
			var userId = _userManager.GetUserId(User);

			if (product != null)
			{
				var cart = _cartService.GetAll(i => i.ApplicationUserId == userId).FirstOrDefault();

				if (cart != null)
				{
					CartItem cartItem = new CartItem()
					{
						ProductId = product.Id,
						ListPrice = product.ListPrice,
						Quantity = quantity*stock,
						CartId = cart.Id
					};

					await _cartService.AddToCartAsync(cartItem);

					return RedirectToAction("Index", "Cart");
				}
				else
				{
					Cart userCart = new Cart();
					userCart.ApplicationUserId = userId;
					_cartService.Create(userCart);

					userCart = _cartService.GetAll(i => i.ApplicationUserId == userId).FirstOrDefault();

					if (userCart != null)
					{
						CartItem cartItem = new CartItem()
						{
							ProductId = product.Id,
							ListPrice = product.ListPrice,
							Quantity = quantity,
							CartId = userCart.Id
						};

						await _cartService.AddToCartAsync(cartItem);

						return RedirectToAction("Index", "Cart");
					}
				}
			}

			return View();
		}

		public async Task<IActionResult> DeleteFromCart(int productId)
		{
			if (productId==null)
			{
				TempData["message"] = "Ürün Bulunamadı";
				return RedirectToAction("Index");
			}
		}

    }
}
