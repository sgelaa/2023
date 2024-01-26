using BookNation.Entities;

namespace BookNation.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (AppUser user);
    }
}