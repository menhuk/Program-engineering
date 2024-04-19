using AntiBook.Models;

namespace AntiBook.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
