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

        [HttpGet("All")]
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

        [HttpPost("Add")]
        public async Task<ActionResult<AppAddressDto>> Add(AppAddressDto appAddressDto)
        {
            var address = new AppAddress
            {
                ReceipientName = appAddressDto.ReceipientName,
                Type = appAddressDto.Type,
                ReceipientNumber = appAddressDto.ReceipientNumber,
                StreetAddress = appAddressDto.StreetAddress,
                BuildingComplex = appAddressDto.BuildingComplex,
                Suburb = appAddressDto.Suburb,
                CityTown = appAddressDto.CityTown,
                Province = appAddressDto.Province,
                PostalCode = appAddressDto.PostalCode,
                AppUserId = 1
            };

            _context.AppAddresses.Add(address);
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
                AppUserId = address.AppUserId
            };
        }

        [HttpDelete("{removeId}")]
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
                PostalCode = address.PostalCode
            };
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<AppAddressDto>> Update(int id, AppAddressDto appAddressDto)
        {
            var entry = await _context.AppAddresses.Where(auth => auth.Id == id).FirstOrDefaultAsync();

            entry.ReceipientName = appAddressDto.ReceipientName;
            entry.Type = appAddressDto.Type;
            entry.ReceipientNumber = appAddressDto.ReceipientNumber;
            entry.StreetAddress = appAddressDto.StreetAddress;
            entry.BuildingComplex = appAddressDto.BuildingComplex;
            entry.Suburb = appAddressDto.Suburb;
            entry.CityTown = appAddressDto.CityTown;
            entry.Province = appAddressDto.Province;
            entry.PostalCode = appAddressDto.PostalCode;

            _context.AppAddresses.Update(entry);
            await _context.SaveChangesAsync();

            return new AppAddressDto
            {
                ReceipientName = entry.ReceipientName,
                Type = entry.Type,
                ReceipientNumber = entry.ReceipientNumber,
                StreetAddress = entry.StreetAddress,
                BuildingComplex = entry.BuildingComplex,
                Suburb = entry.Suburb,
                CityTown = entry.CityTown,
                Province = entry.Province,
                PostalCode = entry.PostalCode,
            };
        }
    }
}
