
using KCrafts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace Crafts.Controllers
{
    public class CartController : Controller
    {
        private readonly KcraftContext _context;

        public CartController(KcraftContext context)
        {
            _context = context;
        }

        private Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            // Retrieve cart data from session
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cart);

            // Remove the selected product from the cart
            var itemToRemove = cartItems.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.CartItems.Remove(itemToRemove);
            }

            // Save updated cart data to session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            // Retrieve cart data from session
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cart);

            // Fetch product information for each cart item
            foreach (var item in cartItems.CartItems.ToList())
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product == null)
                {
                    // Remove the cart item if the corresponding product does not exist
                    cartItems.CartItems.Remove(item);
                }
                else
                {
                    item.Product = product;
                }
            }

            // Save updated cart data to session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cart);

            // Check if the product is already in the cart
            var existingItem = cartItems.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                // If the product is already in the cart, increase its quantity
                existingItem.Quantity++;
            }
            else
            {
                // If the product is not in the cart, add it with quantity 1
                cartItems.CartItems.Add(new CartItem { ProductId = productId, Quantity = 1 });
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cart);

            var existingItem = cartItems.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                // Update the quantity of the existing product
                existingItem.Quantity = quantity;
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            return RedirectToAction("Index");
        }
    }
}
