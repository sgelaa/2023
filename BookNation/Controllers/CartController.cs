using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCart(int userId)
        {
            var cart = await _context.Carts.Where(cart => cart.AppUserId == userId).FirstOrDefaultAsync();
            cart.CartItems = await _context.CartItems.Where(item => item.CartId == cart.Id).ToListAsync();
            return cart;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<CartItem>> AddtoCart(int userId, CartItemDto cartItemDto)
        {
            // get cart belonging to userId
            var cart = await _context.Carts.Where(cart => cart.AppUserId == userId).FirstOrDefaultAsync();

            // get all cartItems for user's cart.
            // this might be needed if the cartItems are not populated already.
            // cart.CartItems = await _context.CartItems.Where(item => item.CartId == cart.Id).ToListAsync();

            // var product = cart.CartItems.Where(item => item.ProductId == cartItemDto.ProductId).FirstOrDefault();

            var cartItem = new CartItem
            {
                CartId = cartItemDto.CartId,
                ProductId = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity,
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return new CartItem
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity
            };
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<CartItemDto>> RemoveById(int productId)
        {
            if (productId == 0)
            {
                return BadRequest("Please enter a positive id");
            }

            var product = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == productId);

            if (product == null)
            {
                return BadRequest("Field with provided id does not exist.");
            }

            _context.CartItems.Remove(product);
            await _context.SaveChangesAsync();

            return new CartItemDto
            {
                CartId = product.CartId,
                ProductId  = product.ProductId,
                Quantity =product.Quantity
            };
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CartItemDto>> Update(int id, CartItemDto cartItemDto)
        {
            var product = await _context.CartItems.Where(prod => prod.Id == id).FirstOrDefaultAsync();

            product.CartId = cartItemDto.CartId;
            product.ProductId = cartItemDto.ProductId;
            product.Quantity = cartItemDto.Quantity;

            _context.CartItems.Update(product);
            await _context.SaveChangesAsync();

            return new CartItemDto
            {
                CartId = product.CartId,
                ProductId = product.ProductId,
                Quantity = product.Quantity
            };
        }

        private async Task<bool> ProductinUserCart(Cart cart, CartItemDto cartItemDto)
        {
            return await _context.CartItems.AnyAsync(
                cartItem => cartItem.CartId == cartItemDto.CartId &&
                cartItem.ProductId == cartItemDto.ProductId
                );
        }
    }
}
