using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class AddressesController : BaseApiController
    {
        private readonly DataContext _context;

        public AddressesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AppAddress>>> GetAddressList()
        {
            var users = await _context.AppAddresses.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppAddress>> GetAddress(int id)
        {
            var user = await _context.AppAddresses.FindAsync(id);
            return user;
        }

        [HttpDelete("removeId")]
        public async Task<ActionResult<AppAddressDto>> RemoveId(int removeId)
        {
            if (removeId == 0)
            {
                return BadRequest("Please enter a positive id");
            }

            var address = await _context.AppAddresses.FirstOrDefaultAsync(x => x.Id == removeId);

            if (address == null)
            {
                return BadRequest("Author with provided id does not exist.");
            }

            _context.AppAddresses.Remove(address);
            await _context.SaveChangesAsync();

            return new AppAddressDto
            {
                ReceipientName = address.ReceipientName,
                Type = address.Type,
                ReceipientNumber = address.ReceipientNumber,
                StreetAddress = address.StreetAddress,
                BuildingComplex = address.BuildingComplex,
                Suburb = address.Suburb,
                CityTown = address.CityTown,
                Province = address.Province,
                PostalCode = address.PostalCode,
            };
        }


        

    }
}