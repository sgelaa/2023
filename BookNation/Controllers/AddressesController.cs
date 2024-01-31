using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookNation.Data;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Controllers 
{
    public class AddressesController : BaseApiController
    {
        private readonly DataContext _context;

        public AddressesController(DataContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<AppAddress>>> GetUsers()
        // {
        //     var users = await _context.AppAddresses.ToListAsync();
        //     return users;
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     var user = await _context.Users.FindAsync(id);
        //     return user;
        // }
    }
}