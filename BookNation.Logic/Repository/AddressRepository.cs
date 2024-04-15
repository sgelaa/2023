using BookNation.DataAccess;
using BookNation.DataAccess.Data;
using BookNation.DataAccess.DTO;
using BookNation.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Logic;

public class AddressRepository : IAddressRepository
{

    private readonly DataContext _context;

    public AddressRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<AppAddress> AddAddressAsync(AppAddressDto appAddressDto)
    {
        var address = new AppAddress
        {
            BuildingComplex = appAddressDto.BuildingComplex,
            CityTown = appAddressDto.CityTown,
            Province = appAddressDto.Province,
            PostalCode = appAddressDto.PostalCode,
            ReceipientName = appAddressDto.ReceipientName,
            ReceipientNumber = appAddressDto.ReceipientNumber,
            StreetAddress = appAddressDto.StreetAddress,
            Suburb = appAddressDto.Suburb,
            Type = appAddressDto.Type,
        };

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        // add resource link here.
        return address;
    }

    public async Task<IEnumerable<AppAddress>> GetAddressesAsync()
    {
        return await _context.Addresses.ToListAsync();
    }

    public Task<AppAddress> GetAddressesAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AppAddress> RemoveAddressAsync(int removeId)
    {
        throw new NotImplementedException();
    }
}
