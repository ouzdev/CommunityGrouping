
namespace JWTAuth.Core
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User account);

    }
}
