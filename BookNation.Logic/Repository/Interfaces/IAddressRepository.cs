
using BookNation.DataAccess;
using BookNation.DataAccess.DTO;

namespace BookNation.Logic.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AppAddress>> GetAddressesAsync();
        Task<AppAddress> GetAddressesAsync(int id);
        Task<AppAddress> AddAddressAsync(AppAddressDto appAddressDto);
        Task<AppAddress> RemoveAddressAsync(int removeId);

    }
}
