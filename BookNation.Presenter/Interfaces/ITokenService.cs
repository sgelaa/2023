using BookNation.DataAccess.Entities;

namespace BookNation.Presenter.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
