using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // [HttpGet("all")]
        // public async Task<ActionResult<IEnumerable<AppAddress>>> GetAddressList()
        // {
        //     var users = await _context.AppAddresses.ToListAsync();
        //     return users;
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int userId)
        {
            var cart = await _context.Carts.Where(cart => cart.AppUserId == userId).FirstOrDefaultAsync();
            cart.CartItems = await _context.CartItems.Where(item => item.CartId == cart.Id).ToListAsync();
            return cart;
        }



        [HttpPost("{id}")]
        public async Task<ActionResult<Cart>> AddtoCart(int userId, CartItemDto cartItemDto)
        {
            var cart = await _context.Carts.Where(cart => cart.AppUserId == userId).FirstOrDefaultAsync();

            cart.CartItems = await _context.CartItems.Where(item => item.CartId == cart.Id).ToListAsync();

            var product = cart.CartItems.Where(item => item.ProductId == cartItemDto.ProductId).FirstOrDefault();



            return cart;
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