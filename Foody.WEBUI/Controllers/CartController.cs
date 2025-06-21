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
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService,IProductService productService,UserManager<ApplicationUser> userManager,IOrderService orderService)
		{
			_cartService = cartService;
			_productService = productService;
			_userManager = userManager;
            _orderService = orderService;
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

		public IActionResult DeleteFromCart(int productId)
		{
			if (productId==null)
			{
				TempData["message"] = "Ürün Bulunamadı";
				return RedirectToAction("Index");
			}

			return View();
		}

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart/Checkout" });
            }

            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null || cart.CartItems.Count == 0)
            {
                TempData["error"] = "Sepetinizde ürün bulunmamaktadır.";
                return RedirectToAction("Index");
            }

            ViewBag.Cart = cart;
            return View(new Order() 
            { 
                OrderNumber= GenerateOrderNumber(),
                ApplicationUserId=userId
            });
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(Order order)
        {
            ModelState.Remove("ApplicationUser");
            if (!ModelState.IsValid)
            {
                var cart = await _cartService.GetCartByUserIdAsync(_userManager.GetUserId(User));
                ViewBag.Cart = cart;
                return View("Checkout", order);
            }

            var userId = _userManager.GetUserId(User);
            var userCart = await _cartService.GetCartByUserIdAsync(userId);

            if (userCart == null || userCart.CartItems.Count == 0)
            {
                TempData["error"] = "Sepetinizde ürün bulunmamaktadır.";
                return RedirectToAction("Index");
            }

            // Create a new order
            order.ApplicationUserId = userId;
            order.OrderNumber = GenerateOrderNumber();
            order.OrderDate = DateTime.Now;
            order.OrderState = OrderState.Pending;

            // Create order items from cart items
            foreach (var cartItem in userCart.CartItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    ListPrice = cartItem.ListPrice
                };

                order.OrderItems.Add(orderItem);
            }

            // Save order to database (assuming you have an order service)
            _orderService.Create(order);

            // Clear the cart
            _cartService.ClearCart(userCart.Id);

            TempData["success"] = "Siparişiniz başarıyla oluşturuldu.";
            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

        private string GenerateOrderNumber()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999).ToString();
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            // Get order details
            // var order = _orderService.GetOne(orderId);

            return View();
        }

    }
}
